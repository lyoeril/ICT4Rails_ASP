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
            List<Medewerker> Medewerkers = new List<Medewerker>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM MEDEWERKER Order by Id";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            throw new NotImplementedException();
                            //Medewerkers.Add(CreateMedewerkerFromReader(reader));
                        }
                    }
                }
            }
            return Medewerkers;
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
                        while (reader.Read())
                        {
                            localFunctie = CreateFunctieFromReader(reader);
                        }
                    }
                }
            }
            return localFunctie;
        }
    }
}
