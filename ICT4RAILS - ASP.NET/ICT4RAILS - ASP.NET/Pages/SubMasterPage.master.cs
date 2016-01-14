using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;
using System.Web.UI.HtmlControls;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class SubMasterPage : System.Web.UI.MasterPage
    {
        private Administratie _admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            _admin = new Administratie();
            if (!IsPostBack)
            {
                //ShowName();
            }
        }

        //private void ShowName()
        //{
        //    string loginName = (string)Session["loginName"];
        //    if (loginName != null)
        //    {
        //        foreach (Medewerker m in _admin.Medewerkers)
        //        {
        //            if (m.Naam == loginName)
        //            {
        //                //HtmlGenericControl p = new HtmlGenericControl("p");
        //                //p.InnerText = "Logged in as: " + m.Naam + " - " + m.Functie.Naam;
        //                Labelname.Text = m.Naam + " - " + m.Functie.Naam;
        //                break;
        //            }
        //        }
        //    }
        //}
    }
}