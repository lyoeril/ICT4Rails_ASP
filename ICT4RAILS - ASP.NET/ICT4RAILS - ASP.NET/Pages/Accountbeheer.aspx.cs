using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class Accountbeheer : System.Web.UI.Page
    {
        private Medewerker medewerker;
        private Administratie administratie;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        public void LoadInfo()
        {
            
            //GridMedewerker1.DataSource = list;
           // GridMedewerker1.DataBind();
            // Get all medewerkers 

        }

        protected void grdMedewerkerList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Medewerker entry = e.Row.DataItem as Medewerker;
                e.Row.Cells[0].Text = entry.ID.ToString();
                e.Row.Cells[1].Text = entry.Functie.ToString();
                e.Row.Cells[2].Text = entry.Naam;
            }
        }
    }
}