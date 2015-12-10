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
        /*
        private Medewerker CreateMedewerkerFromReader(OracleDataReader reader)
        {
            return new Medewerker(
                Convert.ToInt32(reader["ID"]),
                Convert.ToString(reader["Naam"])

                );
           
        }
        */

        private Recht CreateRechtFromReader(OracleDataReader reader)
        {
            return new Recht(
                Convert.ToInt32(reader["ID"]),
                Convert.ToString((reader["Omschrijving"]))
                );
        }

        private Functie CreateFunctieFromReader(OracleDataReader reader)
        {
            int functieid = Convert.ToInt32(reader["ID"]);
            List<Recht> rechtenList = GetAllRechten(functieid);
            return new Functie(
                Convert.ToInt32(reader["ID"]),
                Convert.ToString(reader["Naam"]), 
                rechtenList
                );
        }
    }
}
