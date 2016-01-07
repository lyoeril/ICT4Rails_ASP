using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public partial class Administratie
    {
        private Remise remise;
        private List<Functie> functies;
        private List<Lijn> lijnen;
        private List<Medewerker> medewerkers;
        private List<Recht> rechten;
        private List<Reservering> reserveringen;
        private List<Spoor> sporen;
        private List<Tram> trams;
        private List<TramOnderhoud> onderhoudsbeurten;
        private List<TramType> typen;

        //public Remise Remise { get { return remise; } }
        //public List<Functie> Functies { get { return functies; } }
        //public List<Lijn> Lijnen { get { return lijnen; } }
        //public List<Medewerker> Medewerkers { get { return medewerkers; } }
        //public List<Recht> Rechten { get { return rechten; } }
        //public List<Reservering> Reserveringen { get { return reserveringen; } }
        //public List<Spoor> Sporen { get { return sporen; } }
        //public List<Tram> Trams { get { return trams; } }
        //public List<TramOnderhoud> Onderhoudsbeurten { get { return onderhoudsbeurten; } }
        //public List<TramType> Typen { get { return typen; } }

        public Administratie()
        {
            //remise = new Remise();
            functies = new List<Functie>();
            lijnen = new List<Lijn>();
            medewerkers = new List<Medewerker>();
            rechten = new List<Recht>();
            reserveringen = new List<Reservering>();
            sporen = new List<Spoor>();
            trams = new List<Tram>();
            onderhoudsbeurten = new List<TramOnderhoud>();
            typen = new List<TramType>();
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