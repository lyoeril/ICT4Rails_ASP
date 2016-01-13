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

        public Reservering(int id, Tram tram, Spoor spoor)
        {
            this.ID = id;
            this.Tram = tram;
            this.Spoor = spoor;
        }

        public Reservering(Tram tram, Spoor spoor)
        {
            this.Tram = tram;
            this.Spoor = spoor;
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

            string spoorString;
            if (Spoor == null)
            {
                spoorString = "Onbekend";
            }
            else
            {
                spoorString = Spoor.Nummer.ToString();
            }



            string info = "ReserveringID: " + idString
                          + ", TramID: " + tramString
                          + ", Spoornummer: " + spoorString;

            return info;        
        }
    }
}