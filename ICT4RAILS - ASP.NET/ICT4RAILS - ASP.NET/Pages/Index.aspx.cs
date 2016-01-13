using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        private ActiveDirectory active;

        protected void Page_Load(object sender, EventArgs e)
        {
            active = new ActiveDirectory();
        }

        protected void bttnInloggen_Click(object sender, EventArgs e)
        {
            string Username = txtInputUsername.Text;
            string Password = txtInputPassword.Text;

            
            if (active.ValidateUser(Username, Password))
            {
                Response.Redirect("~/Pages/Overzicht.aspx");
            }
            else
            {
                txtInputUsername.Text = "Username is verkeerd";
            }

        }
    }
}