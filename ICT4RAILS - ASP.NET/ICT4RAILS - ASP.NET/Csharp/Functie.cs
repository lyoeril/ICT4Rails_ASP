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

        public Functie(int id, string naam,List<Recht> rechten)
        {
            this.ID = id;
            this.Naam = naam;
            this.Rechten = rechten;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}