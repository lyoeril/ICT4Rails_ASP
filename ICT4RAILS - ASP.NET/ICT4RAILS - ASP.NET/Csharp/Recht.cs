using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Recht
    {
        public int ID { get; private set; }
        public string Omschrijving { get; set; }
        public int FunctieId { get; private set; }

        public Recht(int id, string omschrijving, int funtieid)
        {
            this.ID = id;
            this.Omschrijving = omschrijving;
            this.FunctieId = funtieid;
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

            string omschrijvingString;
            if (Omschrijving == "")
            {
                omschrijvingString = "Onbekend";
            }
            else
            {
                omschrijvingString = Omschrijving;
            }

            string info = "RechtID: " + idString
                 + ", Omschrijving: " + omschrijvingString;

            return info;
        }
    }
}