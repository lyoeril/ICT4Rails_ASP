﻿using System;
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

        public Sector(int id, int nummer, bool beschikbaar, bool blokkade, Tram tram)
        {
            this.ID = id;
            this.Nummer = nummer;
            this.Beschikbaar = beschikbaar;
            this.Blokkade = blokkade;
            this.Tram = tram;
        }

        public override string ToString()
        {
            string idString;
            if (ID == 0)
            {
                idString = "Onbekend";
            }
            else
            {
                idString = ID.ToString();
            }

            string tramString;
            if (Tram == null)
            {
                tramString = "Onbekend";
            }
            else
            {
                tramString = Tram.ID.ToString();
            }

            string nummerString;
            if (Nummer == 0)
            {
                nummerString = "Onbekend";
            }
            else
            {
                nummerString = Nummer.ToString();
            }

            string blokkadeString;
            if (!Blokkade)
            {
                blokkadeString = "Nee";
            }
            else
            {
                blokkadeString = "Ja";
            }

            string beschikbaarString;
            if (!Beschikbaar)
            {
                beschikbaarString = "Nee";
            }
            else
            {
                beschikbaarString = "Ja";
            }

            string info = "SectorID: " + idString
                 + ", TramID: " + tramString
                 + ", Nummer: " + nummerString
                 + ", Beschikbaar: " + beschikbaarString
                 + ", Geblokkeerd:" + blokkadeString;

            return info;
        }
    }
}