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

        public Spoor(int nummer, int lengte, bool beschikbaar, bool inuitrijspoor, List<Sector> sectoren )
        {
            this.Nummer = nummer;
            this.Lengte = lengte;
            this.Beschikbaar = beschikbaar;
            this.InUitrijSpoor = inuitrijspoor;
            this.Sectoren = sectoren;
        }

        public override string ToString()
        {
            string nummerString;
            if (Nummer == 0)
            {
                nummerString = "Onbekend";
            }
            else
            {
                nummerString = Nummer.ToString();
            }

            string lengteString;
            if (Lengte == 0)
            {
                lengteString = "Onbekend";
            }
            else
            {
                lengteString = Lengte.ToString();
            }

            string inuitrijString;
            if (!InUitrijSpoor)
            {
                inuitrijString = "Nee";
            }
            else
            {
                inuitrijString = "Ja";
            }

            string beschikbaarString;
            if (!Beschikbaar)
            {
                beschikbaarString = "Nee";
            }
            else
            {
                beschikbaarString = "Ja";
            }

            string sectorenString = "";
            if (Sectoren == null)
            {
                sectorenString = "Onbekend";
            }
            else
            {
                foreach (Sector s in Sectoren)
                {
                    sectorenString = sectorenString + ", " + s.ID.ToString();
                }
            }

            string info = "SpoorNummer: " + nummerString
                 + ", Lengte: " + lengteString
                 + ", In-UitrijSpoor: " + inuitrijString
                 + ", Beschikbaar: " + beschikbaarString
                 + ", Sectoren:" + sectorenString;

            return info;
        }
    }
}