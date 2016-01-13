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
            int id = Convert.ToInt32(reader["ID"]);
            string naam = Convert.ToString(reader["Naam"]);
            int functieid = Convert.ToInt32(reader["Functie_ID"]);
 

            return new Medewerker(id, naam, functieid);
        }


        private Recht CreateRechtFromReader(OracleDataReader reader)
        {
            return new Recht(
                Convert.ToInt32(reader["ID"]),
                Convert.ToString((reader["Omschrijving"])),
                Convert.ToInt32(reader["Functie_ID"])
                );
        }

        private Functie CreateFunctieFromReader(OracleDataReader reader)
        {
            int functieid = Convert.ToInt32(reader["ID"]);
            string naam = Convert.ToString(reader["Naam"]);
            return new Functie(
                functieid,
                naam
                );
        }

        private Spoor CreateSpoorFromReader(OracleDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int remiseid = Convert.ToInt32(reader["Remise_ID"]);
            int localnummer = Convert.ToInt32(reader["Nummer"]);
            int locallengte = Convert.ToInt32(reader["Lengte"]);
            int localbeschikbaar = Convert.ToInt32(reader["Beschikbaar"]);
            int localinuitrijspoor = Convert.ToInt32(reader["InUitRijspoor"]);
            bool beschikbaar;
            if (localbeschikbaar == 1)
            {
                beschikbaar = true;
            }
            else
            {
                beschikbaar = false;
            }
            bool inUitRijSpoor;
            if (localinuitrijspoor == 1)
            {
                inUitRijSpoor = true;
            }
            else
            {
                inUitRijSpoor = false;
            }

            return new Spoor(id, remiseid, localnummer, locallengte, beschikbaar, inUitRijSpoor);
        }
        private TramType CreateTramTypeFromReader(OracleDataReader reader)
        {
            return new TramType(Convert.ToInt32(reader["ID"]), Convert.ToString(reader["Omschrijving"]));
        }

        private Lijn CreateLijnFromReader(OracleDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int remiseid = Convert.ToInt32(reader["Remise_ID"]);
            int nummer = Convert.ToInt32(reader["Nummer"]);
            bool conducteurrijdtmee;
            if (Convert.ToInt32(reader["ConducteurRijdtMee"]) == 1)
            {
                conducteurrijdtmee = true;
            }
            else
            {
                conducteurrijdtmee = false; 
            }
            return new Lijn(id, remiseid, nummer, conducteurrijdtmee);
        }

        private TramOnderhoud CreateTramOnderhoudFromReader(OracleDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int medewerkerid = Convert.ToInt32(reader["Medewerker_ID"]);
            int tramid = Convert.ToInt32(reader["Tram_ID"]);
            var datetime = reader["DatumTijdstip"];
            DateTime beschikbaardatetime = Convert.ToDateTime( reader["BeschikbaarDatum"]);
            string typeonderhoud = Convert.ToString(reader["TypeOnderhoud"]);
            DateTime? localdatetime = null;
            if (datetime != DBNull.Value)
            {
                localdatetime = Convert.ToDateTime(datetime);
            }


            return new TramOnderhoud(id, localdatetime, beschikbaardatetime, typeonderhoud,medewerkerid, tramid);
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
            int tramtypeid = Convert.ToInt32(reader["Tramtype_ID"]);


            return new Tram(
                id,
                Convert.ToInt32(reader["Remise_ID_Standplaats"]),
                Convert.ToInt32(reader["Nummer"]),
                Convert.ToInt32(reader["Lengte"]),
                status,
                vervuild,
                defect,
                conducteurgeschikt,
                beschikbaar,
                tramtypeid
                );
        }

        private Sector CreateSectorFromReader(OracleDataReader reader)
        {
            int localid = Convert.ToInt32(reader["ID"]);

            int spoorid = Convert.ToInt32(reader["Spoor_ID"]);
            var tramid = reader["Tram_ID"];
            int localnummer = Convert.ToInt32(reader["Nummer"]);
            int localbeschikbaar = Convert.ToInt32(reader["Beschikbaar"]);
            int localblokkade = Convert.ToInt32(reader["Blokkade"]);
            bool beschikbaar;
            if (localbeschikbaar == 1)
            {
                beschikbaar = true;
            }
            else
            {
                beschikbaar = false;
            }
            bool blokkade;
            if (localblokkade == 1)
            {
                blokkade = true;
            }
            else
            {
                blokkade = false;
            }
            int localtram = 0;
            if (tramid != DBNull.Value)
            {
                localtram = Convert.ToInt32(tramid);
            }
            return new Sector(localid, spoorid, localnummer, beschikbaar, blokkade, localtram);
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
                 Convert.ToInt32(reader["KleineSchoonmaakBeurtenPerDag"])
                 );
        }

        private Reservering CreateReserveringFromReader(OracleDataReader reader, List<Tram> trams, List<Spoor> sporen)
        {
            int id = Convert.ToInt32(reader["Reservering_ID"]);
            int tramid = Convert.ToInt32(reader["Tram_ID"]);
            int spoorid = Convert.ToInt32(reader["Spoor_ID"]);
            Tram localTram = null;
            foreach (Tram tram in trams.Where(tram => tram.ID == tramid))
            {
                localTram = tram;
            }
            Spoor localSpoor = null;
            foreach (Spoor spoor in sporen.Where(spoor => spoor.SpoorId == spoorid))
            {
                localSpoor = spoor;
            }
            return new Reservering(id, localTram, localSpoor);

        }
    }
}
