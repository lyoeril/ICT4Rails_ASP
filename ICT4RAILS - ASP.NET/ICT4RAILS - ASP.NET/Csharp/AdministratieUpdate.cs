using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public partial class Administratie
    {
        private void UpdateTram(Tram tram)
        {
            data.UpdateTram(tram);
            //RefreshRemises();
        }

        private void UpdateSector(Sector sector)
        {
            data.UpdateSector(sector);
            //RefreshRemises();
        }

        //---------------------------------------------
        // Zooi van Laurent
        //---------------------------------------------
        public void UpdateTramStatus(int tramId, string status)
        {
            data.UpdateTramStatus(tramId, status);
        }

        public bool UpdateTramToOnderhoud(int tramnummer, string onderhoudsoort)
        {
            if (data.UpdateTramToOnderhoud(tramnummer, onderhoudsoort))
            {
                return true;
            };
            return false;
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