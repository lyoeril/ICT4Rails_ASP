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
        public bool UpdateTramStatus(int tramnummer, string status)
        {
            using (OracleConnection connection = Connection)
            {
                string query = "UPDATE TRAM SET \"Status\" = :STATUS WHERE ID = :TRAMID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("STATUS", status));
                    command.Parameters.Add(new OracleParameter("TRAMID", tramnummer));
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }


        public bool UpdateTramToOnderhoud(int tramnummer, string onderhoud)
        {

            using (OracleConnection connection = Connection)
            {
                if (onderhoud.ToUpper() == "VERVUILD")
                {
                    string query = "UPDATE TRAM SET \"Vervuild\" = 1 WHERE \"Nummer\" = :TRAMNUMMER";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("TRAMNUMMER", tramnummer));
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                else
                {
                    string query = "UPDATE TRAM SET \"Defect\" = 1 WHERE \"Nummer\" = :TRAMNUMMER";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("TRAMNUMMER", tramnummer));
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
        }

        public List<Tram> GetAllOnderhoudTrams()
        {
            List<Tram> tramlistTrams = new List<Tram>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT T.*, TL.\"Lijn_ID\" FROM TRAM T, TRAM_LIJN TL WHERE TL.\"Tram_ID\" = T.ID AND T.\"Defect\" = 1 OR T.\"Vervuild\" = 1";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    List<TramType> tramtypes = GetAllTramtypes();
                    List<Lijn> lijnen = GetAllLijnen();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tramlistTrams.Add(CreateTramFromReader(reader, tramtypes, lijnen));
                        }
                    }
                }
            }
            return tramlistTrams;
        }
    }
}

