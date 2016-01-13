using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4RAILS___ASP.NET.Csharp;
using Oracle.ManagedDataAccess.Client;

namespace ICT4RAILS___ASP.NET.database
{
    public partial class Database
    {
        public List<Medewerker> GetAllMedewerkers()
        {
            List<Medewerker> medewerkers = new List<Medewerker>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM MEDEWERKER Order by Id";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medewerkers.Add(CreateMedewerkerFromReader(reader));
                        }
                    }
                }
            }
            foreach (Medewerker mede in medewerkers)
            {
                mede.Functie = SelectFunctie(mede.FunctieId);
            }
            
            return medewerkers;
        }

        private List<Recht> GetAllRechten()
        {
            List<Recht> rechtenList = new List<Recht>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT R.ID, R.\"Omschrijving\", FR.\"Functie_ID\" FROM FUNCTIE_RECHT FR, RECHT R WHERE R.ID = FR.\"Recht_ID\"";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rechtenList.Add(CreateRechtFromReader(reader));

                        }
                    }
                }
            }
            return rechtenList;
        }

        public List<Functie> GetAllFuncties()
        {
            List<Recht> rechten = GetAllRechten();
            List<Functie> functielList = new List<Functie>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT F.ID, F.\"Naam\" FROM FUNCTIE F";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            functielList.Add(CreateFunctieFromReader(reader));
                        }
                    }
                }
            }
            foreach (Functie functie in functielList)
            {
                functie.Rechten = SelectRechtenForFunctie(functie);
            }
            return functielList;
        }

        private List<Lijn> GetAllLijnen(int remiseid)
        {
            List<Lijn> lijnenList = new List<Lijn>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM LIJN L WHERE \"Remise_ID\"= :REMISEID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("REMISEID", remiseid));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lijnenList.Add(CreateLijnFromReader(reader));
                        }
                    }
                }
            }
            return lijnenList;
        }

        public List<Spoor> GetAllSporen(int remiseid)
        {
            List<Spoor> sporenlijst = new List<Spoor>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT S.ID, S.\"Remise_ID\", S.\"Nummer\", S.\"Lengte\", S.\"Beschikbaar\", S.\"InUitRijspoor\" FROM SPOOR S WHERE \"Remise_ID\" = :REMISEID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {

                    command.Parameters.Add(new OracleParameter("REMISEID", remiseid));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sporenlijst.Add(CreateSpoorFromReader(reader));
                        }
                    }
                }
            }
            foreach (Spoor spoor in sporenlijst)
            {
                spoor.Sectoren = GetAllSectoren(spoor.SpoorId);
            }
            return sporenlijst;
        }

        public List<Sector> GetAllSectoren(int spoorid)
        {
            List<Sector> sectorenlijst = new List<Sector>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT S.ID, S.\"Spoor_ID\", S.\"Tram_ID\", S.\"Nummer\", S.\"Beschikbaar\", S.\"Blokkade\" FROM Sector S WHERE S.\"Spoor_ID\" = :SPOORID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {

                    command.Parameters.Add("SPOORID", spoorid);
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sectorenlijst.Add(CreateSectorFromReader(reader));
                        }
                    }
                }
            }
            foreach (Sector sector in sectorenlijst)
            {
                if (sector.TramId != 0)
                {
                    sector.Tram = SelectTram(sector.TramId);
                }
                
            }
            return sectorenlijst;
        }

        public List<Tram> GetAllTrams(int remisestandplaats)
        {
            List<Tram> tramlijst = new List<Tram>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM TRAM WHERE \"Remise_ID_Standplaats\"= :REMISEID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    ;
                    command.Parameters.Add(new OracleParameter("REMISEID", remisestandplaats));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tramlijst.Add(CreateTramFromReader(reader));
                        }
                    }
                }
            }
            foreach (Tram tram in tramlijst)
            {
                ChangeLijnForTram(tram);
                ChangeTramTypeForTram(tram);
            }
            return tramlijst;
        }

        private void ChangeTramTypeForTram(Tram tram)
        {
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM TRAMTYPE WHERE ID = :TRAMTYPEID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("TRAMTYPEID", tram.Tramtypeid));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tram.TramType = new TramType(Convert.ToInt32(reader["ID"]), Convert.ToString(reader["Omschrijving"]));
                        }

                    }
                }
            }
        }

        public void ChangeLijnForTram(Tram tram)
        {
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT L.ID, L.\"Remise_ID\", TL.\"Tram_ID\",L.\"Nummer\",L.\"ConducteurRijdtMee\" FROM TRAM_LIJN TL, LIJN L WHERE \"Tram_ID\"=:TRAMID and TL.\"Lijn_ID\"=L.ID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("TRAMID", tram.ID));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bool conducteur = false || Convert.ToInt32(reader["ConducteurRijdtMee"]) == 1;
                            tram.Lijnen.Add(new Lijn(Convert.ToInt32(reader["ID"]),
                                                     Convert.ToInt32(reader["Remise_ID"]),
                                                     Convert.ToInt32(reader["Nummer"]),
                                                     conducteur));
                        }
                    }
                }
            }
        }

        public List<Remise> GetAllRemises()
        {
            List<Remise> remiselijst = new List<Remise>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM REMISE";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            remiselijst.Add(CreateRemiseFromReader(reader));
                        }
                    }
                }
            }
            foreach (Remise remise in remiselijst)
            {
                remise.Lijnen = GetAllLijnen(remise.ID);
                remise.Trams = GetAllTrams(remise.ID);
                remise.Sporen = GetAllSporen(remise.ID);
                remise.Reserveringen = GetAllReserveringen(remise.Trams, remise.Sporen);

            }
            return remiselijst;
        }

        public List<Reservering> GetAllReserveringen(List<Tram> trams, List<Spoor> sporen)
        {
            List<Reservering> reserveringslijst = new List<Reservering>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM RESERVERING R";
                using (OracleCommand command = new OracleCommand(query, connection))
                {

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reserveringslijst.Add(CreateReserveringFromReader(reader, trams, sporen));
                        }
                    }
                }

            }
            return reserveringslijst;
        }

        public List<TramType> GetAllTramtypes()
        {
            List<TramType> tramtypelist = new List<TramType>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM TRAMTYPE";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tramtypelist.Add(CreateTramTypeFromReader(reader));
                        }
                    }
                }

            }
            return tramtypelist;
        }

        public Functie SelectFunctie(int id)
        {
            List<Recht> rechten = GetAllRechten();
            Functie localFunctie = null;
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT F.ID, F.\"Naam\" FROM FUNCTIE F WHERE F.ID = :paraID and ROWNUM <=1";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("paraID", id));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            localFunctie = CreateFunctieFromReader(reader);
                        }
                        
                    }
                }
            }
            localFunctie.Rechten = SelectRechtenForFunctie(localFunctie);
            
            return localFunctie;
        }

        public List<Recht> SelectRechtenForFunctie(Functie functie)
        {
            List<Recht> rechten = new List<Recht>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM FUNCTIE_RECHT FR, RECHT R WHERE R.ID = FR.\"Recht_ID\" and FR.\"Functie_ID\" = :FUNCTIEID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("FUNCTIEID", functie.ID));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rechten.Add(CreateRechtFromReader(reader));
                        }
                    }
                }
            }
            return rechten;
        }

        public Medewerker SelectMedewerker(int id)
        {
            Medewerker medewerker = null;
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM MEDEWERKER WHERE ID = :ParaID and ROWNUM <=1";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("paraID", id));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medewerker = CreateMedewerkerFromReader(reader);
                        }
                    }
                }
            }
            medewerker.Functie = SelectFunctie(medewerker.FunctieId);
            return medewerker;
        }

        public TramType SelectTramType(int id)
        {
            TramType tramtype = null;
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM TRAMTYPE WHERE ID = :ParaID and ROWNUM <=1";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("paraID", id));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        tramtype = CreateTramTypeFromReader(reader);
                    }
                }
            }
            return tramtype;
        }

        public Lijn SelectLijn(int id)
        {
            Lijn lijn = null;
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT L.ID, L.\"Nummer\", L.\"ConducteurRijdtMee\" FROM TRAM_LIJN TL, LIJN L WHERE TL.\"Lijn_ID\" = L.ID and TL.\"Tram_ID\" = :ParaID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add((new OracleParameter("ParaID", id)));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        lijn = CreateLijnFromReader(reader);
                    }
                }
            }
            return lijn;
        }

        public Tram SelectTram(int id)
        {
            Tram tram = null;
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM TRAM WHERE ID = :ParaID and ROWNUM <=1";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add((new OracleParameter("ParaID", id)));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tram = CreateTramFromReader(reader);
                        }              
                    }
                }
            }
            ChangeLijnForTram(tram);
            ChangeTramTypeForTram(tram);
            return tram;
        }

        public Spoor SelectSpoor(int id)
        {
            Spoor spoor = null;
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT S.ID, S.\"Remise_ID\", S.\"Nummer\", S.\"Lengte\", S.\"Beschikbaar\", S.\"InUitRijspoor\" FROM SPOOR S WHERE S.ID = :ParaID and ROWNUM <=1";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add((new OracleParameter("ParaID", id)));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        spoor = CreateSpoorFromReader(reader);
                    }
                }
            }
            spoor.Sectoren = GetAllSectoren(spoor.SpoorId);
            return spoor;
        }

        public List<TramOnderhoud> GetAllOnderhoud()
        {
            List<TramOnderhoud> tramonderhoudslist = new List<TramOnderhoud>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM TRAM_ONDERHOUD";
                using (OracleCommand command = new OracleCommand(query, connection))
                {

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tramonderhoudslist.Add(CreateTramOnderhoudFromReader(reader));
                        }
                    }
                }

            }
            foreach (TramOnderhoud tramonderhoud in tramonderhoudslist)
            {
                tramonderhoud.Medewerker = SelectMedewerker(tramonderhoud.MedewerkerId);
                tramonderhoud.Tram = SelectTram(tramonderhoud.TramId);
            }
            return tramonderhoudslist;
        }
    }
}
