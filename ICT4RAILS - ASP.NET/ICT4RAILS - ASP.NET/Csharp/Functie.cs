using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Functie
    {
        public int ID { get; private set; }
        public List<Recht> Rechten { get; set; }

        public Functie(int id, List<Recht> rechten)
        {
            this.ID = id;
            this.Rechten = rechten;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}