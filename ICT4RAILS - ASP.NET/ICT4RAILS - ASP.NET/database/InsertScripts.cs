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
        public bool InsertTramOnderhoud(TramOnderhoud tramOnderhoud)
        {
            string dagstring = tramOnderhoud.BeschikbaarDatum.Day.ToString();
            if (dagstring.Length < 2)
            {
                dagstring = '0' + dagstring;
            }
            string datumString = dagstring +
                '-' + tramOnderhoud.BeschikbaarDatum.Month.ToString() +
                '-' + tramOnderhoud.BeschikbaarDatum.Year.ToString() +
                ' ' + tramOnderhoud.BeschikbaarDatum.Hour.ToString() +
                ':' + tramOnderhoud.BeschikbaarDatum.Minute.ToString() +
                ':' + tramOnderhoud.BeschikbaarDatum.Second.ToString();

            using (OracleConnection connection = Connection)
            {
                string insert = "INSERT INTO \"TRAM_ONDERHOUD\" VALUES (TRAM_ONDERHOUD_FCSEQ.nextval, :MedewerkerID, :TramID, null, TO_DATE(:BeschikbaarDatum, 'DD-MM-YYYY HH24:MI:SS'), :TypeOnderhoud)";
                using (OracleCommand command = new OracleCommand(insert, connection))
                {
                    command.Parameters.Add(new OracleParameter("MedewerkerID", tramOnderhoud.MedewerkerId));
                    command.Parameters.Add(new OracleParameter("TramID", tramOnderhoud.TramId));
                    command.Parameters.Add(new OracleParameter("BeschikbaarDatum", datumString));
                    command.Parameters.Add(new OracleParameter("TypeOnderhoud", tramOnderhoud.TypeOnderhoud));
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }
    }
}
