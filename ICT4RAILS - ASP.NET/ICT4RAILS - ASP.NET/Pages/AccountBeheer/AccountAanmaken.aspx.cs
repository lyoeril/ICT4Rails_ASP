using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;

namespace ICT4RAILS___ASP.NET.Pages.AccountBeheer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ActiveDirectory active;

        protected void Page_Load(object sender, EventArgs e)
        {
            active = new ActiveDirectory();
        }

        protected void OnClick(object sender, EventArgs e)
        {
            active.AddUser(tbxLoginnaam.Text, tbxVoornaam.Text, tbxAchternaam.Text, tbxWachtwoord.Text);
            try
            {
                bool gelukt = active.AddUser(tbxLoginnaam.Text, tbxVoornaam.Text, tbxAchternaam.Text, tbxWachtwoord.Text);
                if (gelukt)
                {
                    tbxLoginnaam.Text = "";
                    tbxVoornaam.Text = "";
                    tbxAchternaam.Text = "";
                    tbxWachtwoord.Text = "";
                }
            }
            catch
            {

            }
        }
    }
}