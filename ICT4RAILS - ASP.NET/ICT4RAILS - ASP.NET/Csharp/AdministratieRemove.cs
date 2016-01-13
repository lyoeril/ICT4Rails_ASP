using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public partial class Administratie
    {
        public bool RemoveMedewerker(Medewerker medewerker)
        {
            if (FindMedewerker(medewerker.ID) != null)
            {
                data.RemoveMedewerker(medewerker);
                Refresh();
                return true;
            }
            return false;
        }

        public bool RemoveReservering(Reservering reservering)
        {
            if (FindReservering(reservering.ID) != null)
            {
                data.RemoveReservering(reservering);
                Refresh();
                return true;
            }
            return false;
        }
    }
}