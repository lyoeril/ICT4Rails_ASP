﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class TramOnderhoud
    {
        public int ID { get; private set; }
        public DateTime DatumTijdstip { get; set; }
        public bool BeschikbaarDatum { get; set; }
        public string TypeOnderhoud { get; set; }

        public TramOnderhoud(int id, DateTime datumtijdstip, bool beschikbaardatum, string typeonderhoud)
        {
            this.ID = id;
            this.DatumTijdstip = datumtijdstip;
            this.BeschikbaarDatum = beschikbaardatum;
            this.TypeOnderhoud = typeonderhoud;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}