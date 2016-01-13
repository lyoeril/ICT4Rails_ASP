using ICT4RAILS___ASP.NET.Csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class Overzicht : System.Web.UI.Page
    {
        private Administratie admin;

        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Administratie();
            OverzichtTable = admin.CreateTable(OverzichtTable);
            admin.OverzichtInit();
            foreach (Tram t in admin.Remise.Trams)
            {
                if (t.Nummer == 2001)
                {
                    admin.SorteerTram(t);
                }
            }
            admin.VulTrams();
        }
    }
}