using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Tram
    {
        public int ID { get; private set; }
        public int Nummer { get; set; }
        public int Lengte { get; set; }
        public string Status { get; set; }
        public bool Vervuild { get; set; }
        public bool Defect { get; set; }
        public bool ConducteurGeschikt { get; set; }
        public bool Beschikbaar { get; set; }

        public Tram(int id, int nummer, int lengte, string status)
        {
            this.ID = id;
            this.Nummer = nummer;
            this.Lengte = lengte;
            this.Status = status;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}