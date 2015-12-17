using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Tram
    {
        public int ID { get; private set; }
        public int Nummer { get; set; }
        public int Lengte { get; set; }
        public string Status { get; set; }
        public bool Vervuild { get; set; }
        public bool Defect { get; set; }
        public bool ConducteurGeschikt { get; set; }
        public bool Beschikbaar { get; set; }
        public TramType TramType { get; set; }
        public Lijn Lijn { get; set; }

        public Tram(int id, TramType tramtype, int nummer, int lengte, string status, bool vervuild, bool defect, bool conducteurgeschikt, bool beschikbaar)
        {
            this.ID = id;
            this.TramType = tramtype;
            this.Nummer = nummer;
            this.Lengte = lengte;
            this.Status = status;
            this.Vervuild = vervuild;
            this.Defect = defect;
            this.ConducteurGeschikt = conducteurgeschikt;
            this.Beschikbaar = beschikbaar;
        }



        public override string ToString()
        {
            string idString;
            if (ID == 0)
            {
                idString = "Onbekend";
            }
            else
            {
                idString = ID.ToString();
            }

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

            string statusString;
            if (Status == "")
            {
                statusString = "Onbekend";
            }
            else
            {
                statusString = Status;
            }

            string vervuildString;
            if (!Vervuild)
            {
                vervuildString = "Nee";
            }
            else
            {
                vervuildString = "Ja";
            }

            string defectString;
            if (!Defect)
            {
                defectString = "Nee";
            }
            else
            {
                defectString = "Ja";
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

            string conducteurString;
            if (!ConducteurGeschikt)
            {
                conducteurString = "Nee";
            }
            else
            {
                conducteurString = "Ja";
            }

            string info = "TramID: " + idString
                          + ", Nummer: " + nummerString
                          + ", Lengte: " + lengteString
                          + ", Status: " + statusString
                          + ", Vervuild: " + vervuildString
                          + ", Defect: " + defectString
                          + ", ConducteurGeschikt: " + conducteurString
                          + ", Beschikbaar: " + beschikbaarString;

            return info;
        }
    }
}