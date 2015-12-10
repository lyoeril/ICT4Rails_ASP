using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Sector
    {
        public int ID { get; private set; }
        public int Nummer { get; set; }
        public bool Beschikbaar { get; set; }
        public bool Blokkade { get; set; }
        public Tram Tram { get; set; }

        public Sector(int id, int nummer, bool beschikbaar, bool blokkade)
        {
            this.ID = id;
            this.Nummer = nummer;
            this.Beschikbaar = beschikbaar;
            this.Blokkade = blokkade;
            this.Tram = null;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}