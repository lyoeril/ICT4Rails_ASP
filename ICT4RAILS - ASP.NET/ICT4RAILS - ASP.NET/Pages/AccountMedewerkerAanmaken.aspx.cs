using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;

namespace ICT4RAILS___ASP.NET.Pages.AccountBeheer
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private Administratie _admin;
        private ActiveDirectory _active;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _admin = new Administratie();
                _active = new ActiveDirectory();
            }
            catch (Exception en)
            {
                Console.WriteLine(en.Message);
            }
            
        }

        protected void MedewerkerBevestig_OnClick(object sender, EventArgs e)
        {
            try
            {
                bool gelukt = _active.AddUser(txtMederwerkerNaam.Text, txtMederwerkerNaam.Text, tbxAchternaam.Text, txtMederwerkerWachtwoord1.Text);
                if (gelukt)
                {
                    Medewerker medewerker = new Medewerker(0, txtMederwerkerNaam.Text, Convert.ToInt32(dllFuncties.SelectedItem.Value));
                    bool databaseGelukt = _admin.AddMedeweker(medewerker);

                    if (databaseGelukt)
                    {
                        Response.Write("<script language=\"javascript\">alert('" + " Het account" + txtMederwerkerNaam.Text + " is toegevoegd aan het systeem" + "');</script>");

                        txtMederwerkerNaam.Text = "";
                        txtMederwerkerWachtwoord1.Text = "";
                        txtMederwerkerWachtwoord2.Text = "";
                        tbxAchternaam.Text = "";
                        dllFuncties.SelectedIndex = 0;
                    }
                }
            }
            catch
            {
                Response.Write("<script language=\"javascript\">alert('" + "Het systeem kan geen verbinding maken met de Active Directory. Vraag naar uw beheerders." + "');</script>");
            }
        }

        protected void AccountAanmaken_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AccountAanmaken.aspx");
        }
    }
}