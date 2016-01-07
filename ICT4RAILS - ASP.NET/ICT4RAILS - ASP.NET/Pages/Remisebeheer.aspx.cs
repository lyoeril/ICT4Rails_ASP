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
        Administratie admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Administratie();

            //ddlLijnen.DataSource = admin.Lijnen;
            //ddlLijnen.DataBind();

            //ddlTypes.DataSource = admin.Typen;
            //ddlTypes.DataBind();

            ddlLijnen.Items.Insert(0, new ListItem("--Kies een Lijn--", "0"));
            ddlTypes.Items.Insert(0, new ListItem("--Kies een Type--", "0"));
        }
    }
}