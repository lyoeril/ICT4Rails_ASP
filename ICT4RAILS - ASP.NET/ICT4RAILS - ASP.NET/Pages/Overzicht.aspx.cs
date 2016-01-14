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
            try
            {
                admin = new Administratie();
                OverzichtTable = admin.CreateTable(OverzichtTable);
                admin.OverzichtInit();
            }
            catch (Exception en)
            {
                Console.WriteLine(en.Message);
            }

            //foreach (Tram t in admin.Remise.Trams)
            //{
            //    //if (t.Nummer == 2001)
            //    //{
            //    admin.SorteerTram(t);
            //    //}
            //}
            //admin.VulTrams();
        }

        protected void btnBarcode_Click(object sender, EventArgs e)
        {
            int barcode = 0;
            Int32.TryParse(tbxBarcode.Text, out barcode);
            tbxBarcode.Text = "";
            foreach (Tram t in admin.Remise.Trams)
            {
                if (t.Nummer == barcode)
                {
                    admin.SorteerTram(t);
                    admin.VulTrams();
                    return;
                }
            }
            Response.Write("<script language=\"javascript\">alert('" + "Ongeldig Tram Nummer!" + "');</script>");
        }
    }
}