using System;
using System.Collections.Generic;
using System.Linq;
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

        public Remise(int id, string naam, int groteservice, int kleineservice, int groteschoonmaak, int kleineschoonmaak)
        {
            this.ID = id;
            this.Naam = naam;
            this.GroteServiceBeurtenPerDag = groteservice;
            this.KleineServiceBeurtenPerDag = kleineservice;
            this.GroteSchoonmaakBeurtenPerDag = groteschoonmaak;
            this.KleineSchoonmaakBeurtenPerDag = kleineschoonmaak;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}