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

        public List<Lijn> GetAllLijnen()
        {
            List<Lijn> lijnenList = new List<Lijn>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM LIJN L";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
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

        public List<Spoor> GetAllSporen()
        {
            List<Spoor> sporenlijst = new List<Spoor>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT S.ID, S.\"Remise_ID\", S.\"Nummer\", S.\"Lengte\", S.\"Beschikbaar\", S.\"InUitRijspoor\" FROM SPOOR S";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    List<Sector> sectoren = GetAllSectoren();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sporenlijst.Add(CreateSpoorFromReader(reader, sectoren));
                        }
                    }
                }
            }
            return sporenlijst;
        }

        public List<Sector> GetAllSectoren()
        {
            List<Sector> sectorenlijst = new List<Sector>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT S.ID, S.\"Spoor_ID\", S.\"Tram_ID\", S.\"Nummer\", S.\"Beschikbaar\", S.\"Blokkade\" FROM Sector S";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    List<Tram> trams = GetAllTrams();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sectorenlijst.Add(CreateSectorFromReader(reader, trams));
                        }
                    }
                }
            }
            return sectorenlijst;
        }

        public List<Tram> GetAllTrams()
        {
            List<Tram> sectorenlijst = new List<Tram>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT T.*, TL.\"Lijn_ID\" FROM TRAM T, TRAM_LIJN TL WHERE TL.\"Tram_ID\" = T.ID ";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    List<TramType> tramtypes = GetAllTramtypes();
                    List<Lijn> lijnen = GetAllLijnen();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sectorenlijst.Add(CreateTramFromReader(reader, tramtypes, lijnen));
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
                    List<Tram> trams = GetAllTrams();
                    List<Lijn> lijnen = GetAllLijnen();
                    List<Spoor> sporen = GetAllSporen();
                    List<Reservering> reserveringen = GetAllReserveringen();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            remiselijst.Add(CreateRemiseFromReader(reader, sporen, trams, lijnen, reserveringen));
                        }
                    }
                }
            }
            return remiselijst;
        }

        public List<Reservering> GetAllReserveringen()
        {
            List<Reservering> reserveringslijst = new List<Reservering>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM RESERVERING R";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    List<Tram> trams = GetAllTrams();
                    List<Spoor> sporen = GetAllSporen();
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
                    List<TramType> tramtypes = GetAllTramtypes();
                    List<Lijn> lijnen = GetAllLijnen();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        tram = CreateTramFromReader(reader, tramtypes, lijnen);
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
                    List<Sector> sectoren = GetAllSectoren();
                    command.Parameters.Add((new OracleParameter("ParaID", id)));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        spoor = CreateSpoorFromReader(reader, sectoren);
                    }
                }
            }
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
                    List<Medewerker> medewerkers = GetAllMedewerkers();
                    List<Tram> tram = GetAllTrams();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tramonderhoudslist.Add(CreateTramOnderhoudFromReader(reader, medewerkers, tram));
                        }
                    }
                }

            }
            return tramonderhoudslist;
        }
    }
}
