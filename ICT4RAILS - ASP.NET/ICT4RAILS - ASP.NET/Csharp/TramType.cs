using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class TramType
    {
        public int ID { get; private set; }
        public string Omschrijving { get; set; }

        public TramType(int id, string omschrijving)
        {
            this.ID = id;
            this.Omschrijving = omschrijving;
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

            string info = "TramTypeID: " + idString
                 + ", Omschrijving: " + omschrijvingString;

            return info;
        }
    }
}