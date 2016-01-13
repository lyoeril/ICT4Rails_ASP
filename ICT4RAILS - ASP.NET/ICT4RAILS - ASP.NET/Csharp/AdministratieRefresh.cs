using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public partial class Administratie
    {
        private void RefreshAll()
        {
            RefreshTypen();
            RefreshFuncties();
            RefreshMedewerkers();
            RefreshOnderhoud();
            RefreshRemises();
        }

        private void RefreshTypen()
        {
            Typen = data.GetAllTramtypes();
        }

        private void RefreshFuncties()
        {
            Functies = data.GetAllFuncties();
        }

        private void RefreshMedewerkers()
        {
            Medewerkers = data.GetAllMedewerkers();
        }

        private void RefreshOnderhoud()
        {
            Onderhoudsbeurten = data.GetAllOnderhoud();
        }

        private void RefreshRemises()
        {
            Remises = data.GetAllRemises();
        }
    }
}