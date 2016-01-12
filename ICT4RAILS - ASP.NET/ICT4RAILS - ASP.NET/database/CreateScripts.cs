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
            foreach (Functie functie in functies.Where(functie => functie.ID == Convert.ToInt32(reader["Functie_ID"])))
            {
                localFunctie = functie;
            }

            return new Medewerker(id, naam, localFunctie);
        }


        private Recht CreateRechtFromReader(OracleDataReader reader)
        {
            return new Recht(
                Convert.ToInt32(reader["ID"]),
                Convert.ToString((reader["Omschrijving"])),
                Convert.ToInt32(reader["Functie_ID"])
                );
        }

        private Functie CreateFunctieFromReader(OracleDataReader reader, List<Recht> rechtenList)
        {
            int functieid = Convert.ToInt32(reader["ID"]);
            string naam = Convert.ToString(reader["Naam"]);
            List<Recht> rechten = rechtenList.Where(recht => recht.FunctieId == functieid).ToList();
            return new Functie(
                functieid,
                naam,
                rechten
                );
        }

        private Spoor CreateSpoorFromReader(OracleDataReader reader, List<Sector> sectoren)
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
            List<Sector> localsectorenList = sectoren.Where(sector => sector.SpoorId == id).ToList();
            return new Spoor(id, remiseid, localnummer, locallengte, beschikbaar, inUitRijSpoor, localsectorenList);
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

        private TramOnderhoud CreateTramOnderhoudFromReader(OracleDataReader reader, List<Medewerker> medewerkers, List<Tram> trams)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int medewerkerid = Convert.ToInt32(reader["Medewerker_ID"]);
            int tramid = Convert.ToInt32(reader["Tram_ID"]);
            var datetime = reader["DatumTijdstip"];
            var beschikbaardatetime = reader["BeschikbaarDatum"];
            string typeonderhoud = Convert.ToString(reader["TypeOnderhoud"]);
            DateTime localdatetime = new DateTime(0, 0, 0, 0, 0, 0);
            if (datetime != DBNull.Value)
            {
                localdatetime = Convert.ToDateTime(datetime);
            }
            DateTime localbeschikbaardatetime = new DateTime(0, 0, 0, 0, 0, 0);
            if (beschikbaardatetime != DBNull.Value)
            {
                localbeschikbaardatetime = Convert.ToDateTime(beschikbaardatetime);
            }
            Medewerker localMedewerker= null;
            foreach (Medewerker mede in medewerkers.Where(mede => mede.ID == medewerkerid))
            {
                localMedewerker = mede;
            }
            Tram localtram = null;
            foreach (Tram tram in trams.Where(tram => tram.ID == tramid))
            {
                localtram = tram;
            }
            return new TramOnderhoud(id, localdatetime,localbeschikbaardatetime,typeonderhoud,localMedewerker, localtram);
        }

        private Tram CreateTramFromReader(OracleDataReader reader, List<TramType> tramtypes)
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
            TramType localTramType = null;
            foreach (TramType tramtype in tramtypes.Where(tramtype => tramtype.ID == Convert.ToInt32(reader["Tramtype_ID"])))
            {
                localTramType = tramtype;
            }
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
                localTramType

                );
        }

        private Sector CreateSectorFromReader(OracleDataReader reader, List<Tram> trams)
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
            Tram localtram = null;
            if (tramid != DBNull.Value)
            {
                foreach (Tram tram in trams.Where(tram => Convert.ToInt32(tramid) == tram.ID))
                {
                    localtram = tram;
                }
            }
            return new Sector(localid, spoorid, localnummer, beschikbaar, blokkade, localtram);
        }

        private Remise CreateRemiseFromReader(OracleDataReader reader, List<Spoor> sporen, List<Tram> trams, List<Lijn> lijnen, List<Reservering> reserveringen)
        {
            int id = Convert.ToInt32(reader["ID"]);
            List<Spoor> localsporen = sporen.Where(spoor => spoor.RemiseId == id).ToList();
            List<Tram> localtrams = trams.Where(tram => tram.RemiseIdStandplaats == id).ToList();
            List<Lijn> locallijnen = lijnen.Where(lijn => lijn.RemiseId == id).ToList();
            List<Reservering> localreserveringen = new List<Reservering>();
            foreach (Reservering reserv in from reserv in reserveringen from t in localtrams.Where(t => t.ID == reserv.Tram.ID) select reserv)
            {
                localreserveringen.AddRange(from s in localsporen where s.SpoorId == reserv.Spoor.SpoorId select reserv);
            }
                reserveringen.Where(reserv => localtrams.Contains(reserv.Tram) && localsporen.Contains(reserv.Spoor)).ToList();
            return new Remise(
                id,
                Convert.ToString(reader["Naam"]),
                Convert.ToInt32(reader["GroteServiceBeurtenPerDag"]),
                Convert.ToInt32(reader["KleineServiceBeurtenPerDag"]),
                Convert.ToInt32(reader["GroteSchoonmaakBeurtenPerDag"]),
                Convert.ToInt32(reader["KleineSchoonmaakBeurtenPerDag"]),
                localsporen,
                localtrams,
                locallijnen,
                localreserveringen
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
