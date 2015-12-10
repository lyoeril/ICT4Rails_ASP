using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Spoor
    {
        public int Nummer { get; set; }
        public int Lengte { get; set; }
        public bool Beschikbaar { get; set; }
        public bool InUitrijSpoor { get; set; }
        public List<Sector> Sectoren { get; set; }

        public Spoor(int nummer, int lengte, bool beschikbaar, bool inuitrijspoor)
        {
            this.Nummer = nummer;
            this.Lengte = lengte;
            this.Beschikbaar = beschikbaar;
            this.InUitrijSpoor = inuitrijspoor;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}