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
        private Medewerker CreateMedewerkerFromReader(OracleDataReader reader)
        {
            return new Medewerker(
                Convert.ToInt32(reader["ID"]),
                Convert.ToString(reader["Naam"]),
                SelectFunctie(Convert.ToInt32(reader["Functie_ID"]))
                );
        }


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

        private TramType CreateTramTypeFromReader(OracleDataReader reader)
        {
            return new TramType(Convert.ToInt32(reader["ID"]), Convert.ToString(reader["Omschrijving"]));
        }

        private Lijn CreateLijnFromReader(OracleDataReader reader)
        {
            bool conducteurrijdtmee;
            if (Convert.ToInt32(reader["ConducteurRijdtMee"]) == 1)
            {
                conducteurrijdtmee = true;
            }
            else
            {
                conducteurrijdtmee = false;
            }
            return new Lijn(Convert.ToInt32(reader["ID"]), Convert.ToInt32(reader["Nummer"]), conducteurrijdtmee);
        }

        private TramOnderhoud CreateTramOnderhoudFromReader(OracleDataReader reader)
        {
            bool beschikbaar;
            if (Convert.ToInt32(reader["BeschikbaarDatum"]) == 1)
            {
                beschikbaar = true;
            }
            else
            {
                beschikbaar = false;
            }
            return new TramOnderhoud(
                Convert.ToInt32(reader["ID"]),
                Convert.ToDateTime(reader["DatumTijdstip"]),
                beschikbaar,
                Convert.ToString(reader["TypeOnderhoud"]),
                SelectMedewerker(Convert.ToInt32(reader["Medewerker_ID"])),
                SelectTram(Convert.ToInt32(reader["Tram_ID"]))
                );
        }

        private Tram CreateTramFromReader(OracleDataReader reader)
        {
            string status = null;
            if (reader["Status"] != DBNull.Value)
            {
                status = Convert.ToString(reader["Status"]);
            }

            bool vervuild;
            if (Convert.ToInt32(reader["Vervuild"]) == 1)
            {
                vervuild = true;
            }
            else
            {
                vervuild = false;
            }
            bool defect;
            if (Convert.ToInt32(reader["Defect"]) == 1)
            {
                defect = true;
            }
            else
            {
                defect = false;
            }
            bool conducteurgeschikt;
            if (Convert.ToInt32(reader["ConducteurGeschikt"]) == 1)
            {
                conducteurgeschikt = true;
            }
            else
            {
                conducteurgeschikt = false;
            }
            bool beschikbaar;
            if (Convert.ToInt32(reader["Beschikbaar"]) == 1)
            {
                beschikbaar = true;
            }
            else
            {
                beschikbaar = false;
            }
            return new Tram(
                Convert.ToInt32(reader["ID"]),
                SelecTramType(Convert.ToInt32(reader["Tramtype_ID"])),
                Convert.ToInt32(reader["Nummer"]),
                Convert.ToInt32(reader["Lengte"]),
                status, 
                vervuild,
                defect, 
                conducteurgeschikt, 
                beschikbaar);
        }

        private Sector createSectorFromReader(OracleDataReader reader)
        {
            bool beschikbaar;
            if (Convert.ToInt32(reader["Beschikbaar"]) == 1)
            {
                beschikbaar = true;
            }
            else
            {
                beschikbaar = false;
            }
            bool blokkade;
            if (Convert.ToInt32(reader["Blokkade"]) == 1)
            {
                blokkade = true;
            }
            else
            {
                blokkade = false;
            }
            return new Sector(Convert.ToInt32(reader["ID"]),Convert.ToInt32(reader["Nummer"]), beschikbaar, blokkade, SelectTram(Convert.ToInt32(reader["Tram_ID"])));
        }
    }
}
