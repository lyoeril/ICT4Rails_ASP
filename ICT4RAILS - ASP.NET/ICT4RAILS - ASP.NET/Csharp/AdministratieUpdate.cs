﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public partial class Administratie
    {
        public void UpdateTramStatus(int tramId, string status)
        {
            data.UpdateTramStatus(tramId, status);
        }

        public void UpdateTramToOnderhoud(int tramnummer, string onderhoudsoort)
        {
            data.UpdateTramToOnderhoud(tramnummer, onderhoudsoort);
        }

        public List<Tram> GetAllOnderhoudTrams()
        {
            foreach (Remise remise in Remises)
            {
                if (remise.ID == 1)
                {
                    List<Tram> trams = new List<Tram>();
                    foreach (Tram tram in remise.Trams)
                    {
                        if (tram.Defect == true || tram.Vervuild == true)
                        {
                            trams.Add(tram);
                        }
                    }
                    return trams;
                }
            }
            return null;
        }
    }
}