using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class Statusbeheer : System.Web.UI.Page
    {
        private Administratie _administratie;
        protected void Page_Load(object sender, EventArgs e)
        {
            _administratie = new Administratie();
        }

        protected void btnCheckStatus_OnClick(object sender, EventArgs e)
        {
            lblGevondenStatus.Text = "TEST";
        }
    }
}