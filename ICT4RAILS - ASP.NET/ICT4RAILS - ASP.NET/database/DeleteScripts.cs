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
        public void RemoveMedewerker(Medewerker mederwerker)
        {
            using (OracleConnection connection = Connection)
            {
                string Delete = "DELETE FROM MEDEWERKER WHERE \"ID\" =" + mederwerker.ID;

                using (OracleCommand command = new OracleCommand(Delete, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveReservering(Reservering reservering)
        {
            using (OracleConnection connection = Connection)
            {
                string Delete = "DELETE FROM RESERVERING WHERE \"Reservering_ID\" = " + reservering.ID;

                using (OracleCommand command = new OracleCommand(Delete, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}