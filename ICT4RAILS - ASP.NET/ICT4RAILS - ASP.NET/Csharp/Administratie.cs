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

<<<<<<< HEAD
        //public Remise Remise { get { return remise; } }
        //public List<Functie> Functies { get { return functies; } }
        //public List<Lijn> Lijnen { get { return lijnen; } }
        public List<Medewerker> Medewerkers { get { return medewerkers; } }
        //public List<Recht> Rechten { get { return rechten; } }
        //public List<Reservering> Reserveringen { get { return reserveringen; } }
        //public List<Spoor> Sporen { get { return sporen; } }
        //public List<Tram> Trams { get { return trams; } }
        //public List<TramOnderhoud> Onderhoudsbeurten { get { return onderhoudsbeurten; } }
        //public List<TramType> Typen { get { return typen; } }
=======
        public List<Remise> Remises { get; private set; }
        public List<Functie> Functies { get; private set; }
        public List<Medewerker> Medewerkers { get; private set; }
        public List<TramOnderhoud> Onderhoudsbeurten { get; private set; }
        public List<TramType> Typen { get; private set; }
>>>>>>> 862ec7fb373141285339e892f09945f4d898ba4e

        public Administratie()
        {
            data = new Database();
            Typen = data.GetAllTramtypes();
            Functies = data.GetAllFuncties();
            Medewerkers = data.GetAllMedewerkers();
            Onderhoudsbeurten = new List<TramOnderhoud>();
            
            //Remises = data.GetAllRemises();
        }

        public Table CreateTable(Table t)
        {
            
            for (int row = 0; row < 23; row++)
            {
                TableRow r = new TableRow();
                for (int col = 0; col < 19; col++)
                {
                    TableCell c = new TableCell();
                    c.Text = col + ", " + row;
                    r.Cells.Add(c);
                }
                t.Rows.Add(r);
            }
            return t;
        }
    }
}