using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class Remisebeheer : System.Web.UI.Page
    {
        private Administratie admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Administratie();
            
            List<ListItem> lijnen = new List<ListItem>();

            lijnen.Add(new ListItem("-- Kies een Lijn --", "0"));
            lijnen.Add(new ListItem("1", "1"));
            lijnen.Add(new ListItem("2", "2"));
            lijnen.Add(new ListItem("5", "5"));
            lijnen.Add(new ListItem("10", "10"));
            lijnen.Add(new ListItem("13", "13"));
            lijnen.Add(new ListItem("17", "17"));
            lijnen.Add(new ListItem("16/24", "16/24"));
            lijnen.Add(new ListItem("OCV", "OCV"));
            lijnen.Add(new ListItem("RES", "RES"));

            ddlLijnen1.DataSource = lijnen;
            ddlLijnen1.DataBind();
            ddlLijnen2.DataSource = lijnen;
            ddlLijnen2.DataBind();
            ddlTypes.DataSource = admin.Typen;
            ddlTypes.DataBind();
            ddlTrams.DataSource = admin.GetAllTrams(1);
            ddlTrams.DataBind();

            ddlTrams.Items.Insert(0, new ListItem("-- Kies een Tram --", "0"));
            ddlTypes.Items.Insert(0, new ListItem("-- Kies een Type --", "0"));
        }

        protected void trambeheerbevestig_Click(object sender, EventArgs e)
        {
            admin = new Administratie();

        }

        protected void spoorbeheerbevestig_Click(object sender, EventArgs e)
        {
            admin = new Administratie();

        }

        protected void typebevestig_Click(object sender, EventArgs e)
        {
            admin = new Administratie();

        }
    }
}