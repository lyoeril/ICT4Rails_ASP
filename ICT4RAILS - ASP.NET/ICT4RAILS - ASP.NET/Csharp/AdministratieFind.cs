using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ICT4RAILS___ASP.NET.database;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public partial class Administratie
    {
        public Functie FindFunctie(int id)
        {
            foreach (Functie f in functies)
            {
                if (f.ID == id)
                {
                    return f;
                }
            }
            return null;
        }

        public Lijn FindLijn(int id)
        {
            foreach (Lijn l in lijnen)
            {
                if (l.ID == id)
                {
                    return l;
                }
            }
            return null;
        }

        public Medewerker FindMedewerker(int id)
        {
            foreach (Medewerker m in medewerkers)
            {
                if (m.ID == id)
                {
                    return m;
                }
            }
            return null;
        }

       public Recht FindRecht(int id)
        {
            foreach (Recht r in rechten)
            {
                if (r.ID == id)
                {
                    return r;
                }
            }
            return null;
        }

        public Reservering FindReservering(int id)
        {
            foreach (Reservering r in reserveringen)
            {
                if (r.ID == id)
                {
                    return r;
                }
            }
            return null;
        }

        public Spoor FindSpoor(int nummer)
        {
            foreach (Spoor s in sporen)
            {
                if (s.Nummer == nummer)
                {
                    return s;
                }
            }
            return null;
        }

        public Sector FindSector(int spoorNummer, int sectorNummer)
        {
            Spoor sp = FindSpoor(spoorNummer);
            foreach (Sector se in sp.Sectoren)
            {
                if (se.Nummer == sectorNummer)
                {
                    return se;
                }
            }
            return null;
        }

        public Tram FindTram(int nummer)
        {
            foreach (Tram t in trams)
            {
                if (t.Nummer == nummer)
                {
                    return t;
                }
            }
            return null;
        }

        public TramOnderhoud FindOnderhoud(int id)
        {
            foreach (TramOnderhoud t in onderhoudsbeurten)
            {
                if (t.ID == id)
                {
                    return t;
                }
            }
            return null;
        }
    }
}