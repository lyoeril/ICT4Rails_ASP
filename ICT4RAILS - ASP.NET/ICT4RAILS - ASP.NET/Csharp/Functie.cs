using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Functie
    {
        public int ID { get; private set; }

        public string Recht { get; set; }
        public List<Recht> Rechten { get; set; }

        public Functie(int id, string recht,List<Recht> rechten)
        {
            this.ID = id;
            this.Recht = recht;
            this.Rechten = rechten;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}