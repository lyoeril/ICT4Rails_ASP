using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Reservering
    {
        public int ID { get; private set; }
        public Tram Tram { get; set; }
        public Spoor Spoor { get; set; }
        public Sector Sector { get; set; }

        public Reservering(int id, Tram tram, Spoor spoor, Sector sector)
        {
            this.ID = id;
            this.Tram = tram;
            this.Spoor = spoor;
            this.Sector = sector;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}