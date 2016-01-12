using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.database;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public partial class Administratie
    {
        private Database data;
        public List<Remise> Remises { get; private set; }
        public List<Functie> Functies { get; private set; }
        public List<Medewerker> Medewerkers { get; private set; }
        public List<TramOnderhoud> Onderhoudsbeurten { get; private set; }
        public List<TramType> Typen { get; private set; }
        public List<Spoor> Sporen { get; private set; }


        public Administratie()
        {
            tableCells = new List<TableCell>();

            data = new Database();
            Typen = data.GetAllTramtypes();
            Functies = data.GetAllFuncties();
            Medewerkers = data.GetAllMedewerkers();
            Onderhoudsbeurten = new List<TramOnderhoud>();
            Sporen = data.GetAllSporen();
            Remises = data.GetAllRemises();
        }
    }
}