using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Pages.UserControls;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class SubMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNav();
        }

        private void LoadNav()
        {
            //int functie = (int)Session["functieID"];
            int functie = 1;

            NavButton overzicht = (NavButton)LoadControl("~/Pages/UserControls/NavButton.ascx");
            overzicht.Title = "Overzicht";
            NavButton onderhoud = (NavButton)LoadControl("~/Pages/UserControls/NavButton.ascx");
            onderhoud.Title = "Onderhoud";
            NavButton status = (NavButton)LoadControl("~/Pages/UserControls/NavButton.ascx");
            status.Title = "StatusBeheer";
            NavButton account = (NavButton)LoadControl("~/Pages/UserControls/NavButton.ascx");
            account.Title = "AccountBeheer";
            NavButton remise = (NavButton)LoadControl("~/Pages/UserControls/NavButton.ascx");
            remise.Title = "RemiseBeheer";
            NavButton conducteur = (NavButton)LoadControl("~/Pages/UserControls/NavButton.ascx");
            conducteur.Title = "ConducteurScherm";

            if (functie != 0)
            {
                if (functie == 1)
                {
                    navBar.Controls.Add(overzicht);
                    navBar.Controls.Add(onderhoud);
                    navBar.Controls.Add(status);
                    navBar.Controls.Add(account);
                    navBar.Controls.Add(remise);
                }
                else if (functie == 2)
                {
                    navBar.Controls.Add(overzicht);
                    navBar.Controls.Add(onderhoud);
                    navBar.Controls.Add(status);
                    navBar.Controls.Add(remise);
                }
                else if (functie == 3)
                {
                    navBar.Controls.Add(conducteur);
                }
                else if (functie == 4 || functie == 5)
                {
                    navBar.Controls.Add(onderhoud);
                }
            }
        }
    }
}