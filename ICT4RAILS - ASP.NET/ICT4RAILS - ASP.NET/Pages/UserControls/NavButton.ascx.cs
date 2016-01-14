using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4RAILS___ASP.NET.Pages.UserControls
{
    public partial class NavButton : System.Web.UI.UserControl
    {
        private string title = "";

        public string Title { get { return title; } set { title = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            navLi.Attributes.Add("class", title.ToLower());
            HyperLink hyper = new HyperLink
            {
                Target = "/Pages/" + title + ".aspx",
                Text = title
            };
            navPH.Controls.Add(hyper);
        }
    }
}