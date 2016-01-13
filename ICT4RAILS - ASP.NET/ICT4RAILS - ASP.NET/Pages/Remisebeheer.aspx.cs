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
            VulLijsten();
        }

        protected void trambeheerbevestig_Click(object sender, EventArgs e)
        {
            admin = new Administratie();


        }

        protected void spoorbeheerbevestig_Click(object sender, EventArgs e)
        {
            admin = new Administratie();


        }

        private void VulLijsten()
        {
            admin = new Administratie();

            ddlTypes.DataSource = admin.Typen;
            ddlTypes.DataBind();
            ddlTrams.DataSource = admin.Remise.Trams;
            ddlTrams.DataBind();
            ddlTrambeheer.SelectedIndex = 0;

            ddlTrams.Items.Insert(0, new ListItem("--Kies Tram--", "0"));
            ddlTypes.Items.Insert(0, new ListItem("--Kies Type--", "0"));
        }
    }
}