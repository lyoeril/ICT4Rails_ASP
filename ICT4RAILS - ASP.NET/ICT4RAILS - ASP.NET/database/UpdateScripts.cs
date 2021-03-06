﻿using System;
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
        public bool UpdateTramOnderhoudToDone(int tramOnderhoudId, string status, int tramId)
        {
            
            string datumString = DateTime.Now.Day.ToString() +
                '-' + DateTime.Now.Month.ToString() +
                '-' + DateTime.Now.Year.ToString() +
                ' ' + DateTime.Now.Hour.ToString() +
                ':' + DateTime.Now.Minute.ToString() +
                ':' + DateTime.Now.Second.ToString();

            using (OracleConnection connection = Connection)
            {
                string query = "UPDATE TRAM_ONDERHOUD SET \"DatumTijdstip\" = TO_DATE(:Einddatum, 'DD-MM-YYYY HH24:MI:SS') WHERE ID = :TRAMONDERHOUDID";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("Einddatum", datumString));
                    command.Parameters.Add(new OracleParameter("TRAMONDERHOUDID", tramOnderhoudId));
                    command.ExecuteNonQuery();
                }
            }
            using (OracleConnection connection = Connection)
            {
                string query;
                if (status == "DEFECT")
                {
                    query = "UPDATE TRAM SET \"Defect\" = 0 WHERE ID = :ID";
                }
                else
                {
                    query = "UPDATE TRAM SET \"Vervuild\" = 0 WHERE ID = :ID";
                }
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("ID", tramId));
                    command.ExecuteNonQuery();
                    return true;
                }
            }

        }

        public bool UpdateTramStatus(int tramnummer, string status)
        {
            using (OracleConnection connection = Connection)
            {
                string query = "UPDATE TRAM SET \"Status\" = UPPER(:STATUS) WHERE ID = :TRAMID";
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
        public void UpdateTram(Tram tram)
        {
            using (OracleConnection connection = Connection)
            {

                string Update = "UPDATE TRAM SET \"Tramtype_ID\"=:TRAMTYPEID, \"Nummer\"=:NUMMER, \"Lengte\"=:LENGTE, \"Status\"= UPPER(:STATUS),\"Vervuild\"=:VERVUILD, \"Defect\"=:DEFECT,\"ConducteurGeschikt\"=:CONDUCTEUR,\"Beschikbaar\"=:BESCHIKBAAR WHERE \"ID\"=:ID";
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
                    command.Parameters.Add(new OracleParameter("ID", tram.ID));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSector(Sector sector)
        {
            using (OracleConnection connection = Connection)
            {
                string Update = "UPDATE SECTOR SET \"Tram_ID\" = :TRAMID, \"Beschikbaar\" = :BESCHIKBAAR, \"Blokkade\" = :BLOKKADE WHERE \"ID\" = :SECTORID";
                using (OracleCommand command = new OracleCommand(Update, connection))
                {
                    if (sector.Tram == null)
                    {
                        command.Parameters.Add(new OracleParameter("TRAMID", DBNull.Value));
                    }
                    else
                    {
                        command.Parameters.Add(new OracleParameter("TRAMID", sector.Tram.ID));
                    }
                    int beschikbaar = 0;
                    if (sector.Beschikbaar)
                    {
                        beschikbaar = 1;
                    }
                    command.Parameters.Add(new OracleParameter("BESCHIKBAAR", beschikbaar));
                    int blokkade = 0;
                    if (sector.Blokkade)
                    {
                        blokkade = 1;
                    }
                    command.Parameters.Add(new OracleParameter("BLOKKADE", blokkade));
                    command.Parameters.Add(new OracleParameter("SECTORID", sector.ID));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

