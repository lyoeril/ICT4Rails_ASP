using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Lijn
    {
        public int ID { get; private set; }
        public int Nummer { get; set; }
        public bool ConducteurRijdMee { get; set; }

        public Lijn(int id, int nummer, bool conducteurrijdmee)
        {
            this.ID = id;
            this.Nummer = nummer;
            this.ConducteurRijdMee = conducteurrijdmee;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}