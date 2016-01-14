using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            if (Request.Url.ToString().EndsWith("?logout"))
            {
                Response.Write("<script language=\"javascript\">alert('" + "You have succesfully logged out!" + "');</script>");
            }
        }

        protected void bttnInloggen_Click(object sender, EventArgs e)
        {
            string Username = txtInputUsername.Text;
            string Password = txtInputPassword.Text;

            try
            {
                if (active.ValidateUser(Username, Password))
                {
                    Session["loginName"] = txtInputUsername.Text;
                    Response.Redirect("~/Pages/Overzicht.aspx");
                }
                else
                {
                    txtInputUsername.Text = "Username is verkeerd";
                }
            }
            catch
            {
                Response.Write("<script language=\"javascript\">alert('" + "Het systeem kan geen verbinding maken met de Active Directory. Vraag naar uw beheerders." + "');</script>");
            }

        }
    }
}