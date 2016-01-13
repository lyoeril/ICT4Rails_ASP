using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class TramOnderhoud
    {
        public int ID { get; private set; }
        public DateTime? DatumTijdstip { get; set; }
        public DateTime BeschikbaarDatum { get; set; }
        public string TypeOnderhoud { get; set; }
        public int MedewerkerId { get; set; }
        public int TramId { get; set; }
        public Medewerker Medewerker { get; set; }
        public Tram Tram { get; set; }

        public TramOnderhoud(int id, DateTime? datumtijdstip, DateTime beschikbaardatum, string typeonderhoud, int medewerkerid, int tramid)
        {
            this.ID = id;
            this.DatumTijdstip = datumtijdstip;
            this.BeschikbaarDatum = beschikbaardatum;
            this.TypeOnderhoud = typeonderhoud;
            this.MedewerkerId = medewerkerid;
            this.TramId = tramid;
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

            string datumtijdString;
            if (DatumTijdstip == null)
            {
                datumtijdString = "Onbekend";
            }
            else
            {
                datumtijdString = DatumTijdstip.ToString();
            }

            string beschikbaarString;
            if (BeschikbaarDatum > DateTime.Now)
            {
                beschikbaarString = "Nee";
            }
            else
            {
                beschikbaarString = "Ja";
            }

            string typeString;
            if (TypeOnderhoud == "")
            {
                typeString = "Onbekend";
            }
            else
            {
                typeString = TypeOnderhoud;
            }

            string medewerkerString;
            if (Medewerker == null)
            {
                medewerkerString = "Onbekend";
            }
            else
            {
                medewerkerString = Medewerker.Naam;
            }

            string info = "OnderhoudID: " + idString
                 + ", Datum: " + datumtijdString
                 + ", Beschikbaar: " + beschikbaarString
                 + ", Type: " + typeString
                 + ", Medewerker:" + medewerkerString;

            return info;
        }
    }
}