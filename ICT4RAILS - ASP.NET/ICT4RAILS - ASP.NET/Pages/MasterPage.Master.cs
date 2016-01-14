using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private Administratie _admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            _admin = new Administratie();
        }

        
    }
}