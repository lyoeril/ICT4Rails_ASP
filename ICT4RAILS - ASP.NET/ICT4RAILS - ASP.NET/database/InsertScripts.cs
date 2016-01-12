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
        public void UpdateTram(Tram tram)
        {
            using (OracleConnection connection = Connection)
            {

                string Update = "UPDATE TRAM SET \"Tramtype_ID\"=:TRAMTYPEID, \"Nummer\"=:NUMMER, \"Lengte\"=:LENGTE, \"Status\"=:STATUS,\"Vervuild\"=:VERVUILD, \"Defect\"=:DEFECT,\"ConducteurGeschikt\"=:CONDUCTEUR,\"Beschikbaar\"=:BESCHIKBAAR WHERE \"ID\"=:TRAMTYPEID";
                using (OracleCommand command = new OracleCommand(Update, connection))
                {
                    command.Parameters.Add(new OracleParameter("TRAMTYPEID", tram.TramType.ID));
                    command.Parameters.Add(new OracleParameter("NUMMER", tram.Nummer));
                    command.Parameters.Add(new OracleParameter("LENGTE", tram.Lengte));
                    command.Parameters.Add(new OracleParameter("STATUS", tram.Status));
                    int vervuild = 0;
                    if (tram.Vervuild)
                    {
                        vervuild = 1;
                    }
                    command.Parameters.Add(new OracleParameter("VERVUILD", vervuild));
                    int defect = 0;
                    if (tram.Defect)
                    {
                        defect = 1;
                    }
                    command.Parameters.Add(new OracleParameter("DEFECT", defect));
                    int conducteurgeschikt = 0;
                    if (tram.ConducteurGeschikt)
                    {
                        conducteurgeschikt = 1;
                    }
                    command.Parameters.Add(new OracleParameter("CONDUCTEUR", conducteurgeschikt));
                    int beschikbaar = 0;
                    if (tram.Beschikbaar)
                    {
                        beschikbaar = 1;
                    }
                    command.Parameters.Add(new OracleParameter("BESCHIKBAAR", beschikbaar));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSector(Sector sector)
        {
            using (OracleConnection connection = Connection)
            {

                string Update = "UPDATE SECTOR SET \"Tram_ID\" =:TRAMID,\"Beschikbaar\" =:BESCHIKBAAR,\"Blokkade\"=:BLOKKADE WHERE ID =:SECTORID";
                using (OracleCommand command = new OracleCommand(Update, connection))
                {
                    command.Parameters.Add(new OracleParameter("SECTORID", sector.ID));
                    command.Parameters.Add(new OracleParameter("TRAMID", sector.Tram.ID));
                    int beschikbaar = 0;
                    if (sector.Beschikbaar)
                    {
                        beschikbaar = 1;
                    }
                    int blokkade = 0;
                    if (sector.Blokkade)
                    {
                        beschikbaar = 1;
                    }
                    command.Parameters.Add(new OracleParameter("BESCHIKBAAR", beschikbaar));
                    command.Parameters.Add(new OracleParameter("BLOKKADE", blokkade));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
