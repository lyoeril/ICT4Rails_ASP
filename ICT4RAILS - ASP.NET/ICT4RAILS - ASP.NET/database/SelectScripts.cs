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
            return medewerkers;
        }

        public List<Recht> GetAllRechten(int id)
        {
            List<Recht> rechtenList = new List<Recht>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT R.ID, R.\"Omschrijving\" FROM FUNCTIE_RECHT FR, RECHT R WHERE FR.\"Functie_ID\" = :paraID and R.ID = FR.\"Recht_ID\"";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("paraID", id));
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
            return functielList;
        }

        public List<Lijn> GetAllLijnenRemise(int remiseId)
        {
            List<Lijn> lijnenList = new List<Lijn>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT L.ID, L.\"Nummer\", L.\"ConducteurRijdtMee\" FROM LIJN L WHERE \"Remise_ID\" = :ParaID";
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
                string query = "SELECT S.ID, S.\"Nummer\", S.\"Lengte\", S.\"Beschikbaar\", S.\"InUitRijspoor\" FROM SPOOR S WHERE \"Remise_ID\" = :ParaID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        command.Parameters.Add(new OracleParameter("ParaID", remiseId));
                        while (reader.Read())
                        {
                            //sporenlijst.Add(create);
                        }
                    }
                }
            }
            return sporenlijst;
        }

        public Functie SelectFunctie(int id)
        {
            Functie localFunctie = null;
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT F.ID, F.\"Naam\" FROM FUNCTIE F WHERE F.ID = :paraID and ROWNUM <=1";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("paraID", id));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        localFunctie = CreateFunctieFromReader(reader);
                    }
                }
            }
            return localFunctie;
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
                        medewerker = CreateMedewerkerFromReader(reader);
                    }
                }
            }
            return medewerker;
        }

        public TramType SelecTramType(int id)
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
    }
}
