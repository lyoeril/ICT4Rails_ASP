using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Medewerker
    {
        public int ID { get; private set; }
        public string Naam { get; set; }
        public Functie Functie { get; set; }

        public Medewerker(int id, string naam)
        {
            this.ID = id;
            this.Naam = naam;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}