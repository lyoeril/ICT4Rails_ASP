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
                bool gelukt = _active.AddUser(txtMederwerkerNaam.Text, txtMederwerkerNaam.Text, tbxAchternaam.Text, txtMederwerkerWachtwoord.Text);
                if (gelukt)
                {
                    //bool databaseGelukt = _admin.
                }
            }
            catch
            {

            }
        }
    }
}