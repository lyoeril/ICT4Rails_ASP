using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Functie
    {
        public int ID { get; private set; }
        public string Naam { get; set; }
        public List<Recht> Rechten { get; set; }

        public Functie(int id, string naam)
        {
            this.ID = id;
            this.Naam = naam;
            this.Rechten = new List<Recht>();
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

            string rechtenString = "";
            if (Rechten == null)
            {
                rechtenString = "Onbekend";
            }
            else
            {
                foreach (Recht r in Rechten)
                {
                    rechtenString = rechtenString + r.ID;
                }
            }

            string info = "FunctieID: " + idString
                 + ", RechtenID: " + rechtenString;

            return info;
        }
    }
}