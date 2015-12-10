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
        public TramOnderhoud Onderhoud { get; set; }
        public TramType TramType { get; set; }
        public Lijn Lijn { get; set; }

        public Tram(int id, int nummer, int lengte, string status)
        {
            this.ID = id;
            this.Nummer = nummer;
            this.Lengte = lengte;
            this.Status = status;
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

            string onderhoudString;
            if (Onderhoud == null)
            {
                onderhoudString = "Onbekend";
            }
            else
            {
                onderhoudString = Onderhoud.TypeOnderhoud.ToString();
            }

            string tramtypeString;
            if (Onderhoud == null)
            {
                tramtypeString = "Onbekend";
            }
            else
            {
                tramtypeString = TramType.Omschrijving.ToString();
            }

            string lijnString;
            if (Onderhoud == null)
            {
                lijnString = "Onbekend";
            }
            else
            {
                lijnString = Lijn.ID.ToString();
            }

            string info = "TramID: " + idString
                 + ", Nummer: " + nummerString
                 + ", Lengte: " + lengteString
                 + ", Status: " + statusString
                 + ", Vervuild: " + vervuildString
                 + ", Defect: " + defectString
                 + ", ConducteurGeschikt: " + conducteurString
                 + ", Beschikbaar: " + beschikbaarString
                 + ", Onderhoud: " + onderhoudString
                 + ", Tramtype: "+ tramtypeString
                 + ", Lijn: " + lijnString;

            return info;
        }
    }
}