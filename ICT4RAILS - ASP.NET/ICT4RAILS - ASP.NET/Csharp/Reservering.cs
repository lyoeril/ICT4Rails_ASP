using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class Reservering
    {
        public int ID { get; private set; }

        public Reservering(int id)
        {
            this.ID = id;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}