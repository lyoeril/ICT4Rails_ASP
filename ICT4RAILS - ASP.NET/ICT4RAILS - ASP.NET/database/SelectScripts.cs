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
            List<Functie> functies = GetAllFuncties();
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
                            medewerkers.Add(CreateMedewerkerFromReader(reader, functies));
                        }
                    }
                }
            }
            return medewerkers;
        }

        public List<Recht> GetAllRechten()
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
                            functielList.Add(CreateFunctieFromReader(reader, rechten));
                        }
                    }
                }
            }
            return functielList;
        }

        public List<Lijn> GetAllLijnenRemise(int remiseId)
        {
            List<Lijn> lijnenList = new List<Lijn>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT L.ID, L.\"Nummer\", L.\"ConducteurRijdtMee\" FROM LIJN L WHERE L.\"Remise_ID\" = :ParaID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        command.Parameters.Add(new OracleParameter("ParaID", remiseId));
                        while (reader.Read())
                        {
                            lijnenList.Add(CreateLijnFromReader(reader));
                        }
                    }
                }
            }
            return lijnenList;
        }

        public List<Spoor> GetAllSporenRemise(int remiseId)
        {
            List<Spoor> sporenlijst = new List<Spoor>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT S.ID, S.\"Nummer\", S.\"Lengte\", S.\"Beschikbaar\", S.\"InUitRijspoor\" FROM SPOOR S WHERE S.\"Remise_ID\" = :ParaID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        command.Parameters.Add(new OracleParameter("ParaID", remiseId));
                        while (reader.Read())
                        {
                            sporenlijst.Add(CreateSpoorFromReader(reader));
                        }
                    }
                }
            }
            return sporenlijst;
        }

        public List<Sector> GetAllSectorenRemise(int spoorId)
        {
            List<Sector> sectorenlijst = new List<Sector>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT S.ID, S.\"Spoor_ID\", S.\"Tram_ID\", S.\"Nummer\", S.\"Beschikbaar\", S.\"Blokkade\" FROM Sector S WHERE S.\"Spoor_ID\" = :ParaID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        command.Parameters.Add(new OracleParameter("ParaID", spoorId));
                        while (reader.Read())
                        {
                            sectorenlijst.Add(CreateSectorFromReader(reader));
                        }
                    }
                }
            }
            return sectorenlijst;
        }

        public List<Tram> GetAllTramsRemise(int remiseId)
        {
            List<Tram> sectorenlijst = new List<Tram>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM TRAM WHERE \"Remise_ID_Standplaats\" = :ParaID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        command.Parameters.Add(new OracleParameter("ParaID", remiseId));
                        while (reader.Read())
                        {
                            sectorenlijst.Add(CreateTramFromReader(reader));
                        }
                    }
                }
            }
            return sectorenlijst;
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
            return remiselijst;
        }

        public List<Reservering> GetAllReserveringenRemise(int remiseId)
        {
            List<Reservering> reserveringslijst = new List<Reservering>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM RESERVERING R WHERE R.\"Tram_ID\" IN (SELECT ID FROM TRAM T WHERE T.\"Remise_ID_Standplaats\" = :paraID) and R.\"Spoor_ID\" IN (SELECT ID FROM SPOOR S WHERE S.\"Remise_ID\" = :paraID)";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("paraID", remiseId));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reserveringslijst.Add(CreateReserveringFromReader(reader));
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
                        localFunctie = CreateFunctieFromReader(reader, rechten);
                    }
                }
            }
            return localFunctie;
        }

        public Medewerker SelectMedewerker(int id)
        {
            List<Functie> functies = GetAllFuncties();
            Medewerker medewerker = null;
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM MEDEWERKER WHERE ID = :ParaID and ROWNUM <=1";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("paraID", id));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        medewerker = CreateMedewerkerFromReader(reader, functies);
                    }
                }
            }
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
                        tram = CreateTramFromReader(reader);
                    }
                }
            }
            return tram;
        }

        public Spoor SelectSpoor(int id)
        {
            Spoor spoor = null;
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT S.ID, S.\"Nummer\", S.\"Lengte\", S.\"Beschikbaar\", S.\"InUitRijspoor\" FROM SPOOR S WHERE S.ID = :ParaID and ROWNUM <=1";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add((new OracleParameter("ParaID", id)));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        spoor = CreateSpoorFromReader(reader);
                    }
                }
            }
            return spoor;
        }
    }
}
