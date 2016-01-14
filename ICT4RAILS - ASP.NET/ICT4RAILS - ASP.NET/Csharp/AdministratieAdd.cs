using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public partial class Administratie
    {
        public bool AddTramOnderhoud(TramOnderhoud tramOnderhoud)
        {
            data.InsertTramOnderhoud(tramOnderhoud);
            return true;
        }

        public bool AddMedeweker(Medewerker medewerker)
        {
            data.InsertMedewerker(medewerker);
            return true;
        }
    }
}