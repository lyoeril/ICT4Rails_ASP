using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Remise
    {
        public int ID { get; private set; }
        public string Naam { get; set; }
        public int GroteServiceBeurtenPerDag { get; set; }
        public int KleineServiceBeurtenPerDag { get; set; }
        public int GroteSchoonmaakBeurtenPerDag { get; set; }
        public int KleineSchoonmaakBeurtenPerDag { get; set; }
        public List<Spoor> Sporen { get; set; }
        public List<Tram> Trams { get; set; }
        public List<Lijn> Lijnen { get; set; }
        public List<Reservering> Reserveringen { get; set; }

        public Remise(int id, string naam, int groteServiceBeurtenPerDag, int kleineServiceBeurtenPerDag, int groteSchoonmaakBeurtenPerDag, int kleineSchoonmaakBeurtenPerDag)
        {
            ID = id;
            Naam = naam;
            GroteServiceBeurtenPerDag = groteServiceBeurtenPerDag;
            KleineServiceBeurtenPerDag = kleineServiceBeurtenPerDag;
            GroteSchoonmaakBeurtenPerDag = groteSchoonmaakBeurtenPerDag;
            KleineSchoonmaakBeurtenPerDag = kleineSchoonmaakBeurtenPerDag;
            Sporen = new List<Spoor>();
            Trams = new List<Tram>();
            Lijnen = new List<Lijn>();
            Reserveringen = new List<Reservering>();
        }

        public Remise()
        {
            
        }

        public void AddTrams(List<Tram> trams)
        {
            Trams = new List<Tram>();
            Trams.AddRange(trams);
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

            string naamString;
            if (Naam == "")
            {
                naamString = "Onbekend";
            }
            else
            {
                naamString = Naam;
            }

            string info = "RemiseID: " + idString
                 + ", Naam: " + naamString;

            return info;
        }
    }
}