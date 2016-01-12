using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Lijn
    {
        public int ID { get; private set; }
        public int RemiseId { get; private set; }
        public int Nummer { get; set; }
        public bool ConducteurRijdMee { get; set; }

        public Lijn(int id, int remiseid, int nummer, bool conducteurrijdmee)
        {
            this.ID = id;
            this.RemiseId = remiseid;
            this.Nummer = nummer;
            this.ConducteurRijdMee = conducteurrijdmee;
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

            string conducteurString;
            if (!ConducteurRijdMee)
            {
                conducteurString = "Nee";
            }
            else
            {
                conducteurString = "Ja";
            }

            string info = "LijnID: " + idString
                 + ", Nummer: " + nummerString
                 + ", ConducteurRijdMee: " + conducteurString;

            return info;
        }
    }
}