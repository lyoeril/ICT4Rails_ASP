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
        private Remise remise;
        public List<Remise> Remises { get; private set; }
        public List<Functie> Functies { get; private set; }
        public List<Medewerker> Medewerkers { get; private set; }
        public List<TramOnderhoud> Onderhoudsbeurten { get; private set; }
        public List<TramType> Typen { get; private set; }
        public Remise Remise { get { return remise; } }

        public Administratie()
        {
            tableCells = new List<TableCell>();
            data = new Database();
            RefreshAll();
            foreach (Remise r in Remises) { if (r.ID == 1) { remise = r; } }
        }
    }
}