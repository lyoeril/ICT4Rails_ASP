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
        private Medewerker CreateMedewerkerFromReader(OracleDataReader reader, List<Functie> functies)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string naam = Convert.ToString(reader["Naam"]);
            Functie localFunctie = null;
            foreach (Functie functie in functies)
            {
                if (functie.ID == Convert.ToInt32(reader["Functie_ID"]))
                {
                    localFunctie = functie;
                }
            }
            
            return new Medewerker(id,naam,localFunctie);
        }


        private Recht CreateRechtFromReader(OracleDataReader reader)
        {
            return new Recht(
                Convert.ToInt32(reader["ID"]),
                Convert.ToString((reader["Omschrijving"])),
                Convert.ToInt32(reader["Functie_ID"])
                );
        }

        private Functie CreateFunctieFromReader(OracleDataReader reader, List<Recht> rechtenList )
        {
            int functieid = Convert.ToInt32(reader["ID"]);
            string naam = Convert.ToString(reader["Naam"]);
            List<Recht> rechten = new List<Recht>();
            foreach (Recht recht in rechtenList)
            {
                if (recht.FunctieId == functieid)
                {
                    rechten.Add(recht);
                }
            }
            return new Functie(
                functieid,
                naam,
                rechten
                );
        }

        private Spoor CreateSpoorFromReader(OracleDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            bool beschikbaar;
            if (Convert.ToInt32(reader["Beschikbaar"]) == 1)
            {
                beschikbaar = true;
            }
            else
            {
                beschikbaar = false;
            }
            bool inUitRijSpoor;
            if (Convert.ToInt32(reader["InUitRijspoor"]) == 1)
            {
                inUitRijSpoor = true;
            }
            else
            {
                inUitRijSpoor = false;
            }
            return new Spoor(
                id, 
                Convert.ToInt32(reader["Nummer"]), 
                beschikbaar, 
                inUitRijSpoor, 
                GetAllSectorenRemise(id));
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
            return new Lijn(
                Convert.ToInt32(reader["ID"]), 
                Convert.ToInt32(reader["Nummer"]), 
                conducteurrijdtmee);
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
            int id = Convert.ToInt32(reader["ID"]);
            return new Tram(
                id,
                Convert.ToInt32(reader["Nummer"]),
                Convert.ToInt32(reader["Lengte"]),
                status, 
                vervuild,
                defect, 
                conducteurgeschikt, 
                beschikbaar,
                SelectTramType(Convert.ToInt32(reader["Tramtype_ID"])),
                SelectLijn(id)
                );
        }

        private Sector CreateSectorFromReader(OracleDataReader reader)
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
            return new Sector(
                Convert.ToInt32(reader["ID"]),
                Convert.ToInt32(reader["Nummer"]), 
                beschikbaar, 
                blokkade, 
                SelectTram(Convert.ToInt32(reader["Tram_ID"]))
                );
        }

        private Remise CreateRemiseFromReader(OracleDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            return new Remise(
                id,
                Convert.ToString(reader["Naam"]),
                Convert.ToInt32(reader["GroteServiceBeurtenPerDag"]),
                Convert.ToInt32(reader["KleineServiceBeurtenPerDag"]),
                Convert.ToInt32(reader["GroteSchoonmaakBeurtenPerDag"]),
                Convert.ToInt32(reader["KleineSchoonmaakBeurtenPerDag"]),
                GetAllSporenRemise(id),
                GetAllTramsRemise(id),
                GetAllLijnenRemise(id),
                GetAllReserveringenRemise(id)
                );
        }

        private Reservering CreateReserveringFromReader(OracleDataReader reader)
        {
            return new Reservering(
                Convert.ToInt32(reader["ID"]),
                SelectTram(Convert.ToInt32(reader["Tram_ID"])),
                SelectSpoor(Convert.ToInt32(reader["Spoor_ID"]))
                );
        }
    }
}
