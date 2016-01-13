using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;
namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class Onderhoud : System.Web.UI.Page
    {
        private Administratie admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Administratie();

            if (!IsPostBack)
            {
                List<Medewerker> medewerkers = admin.Medewerkers;
                List<int>medewerkwerIds = new List<int>();
                foreach (Medewerker medewerker in medewerkers)
                {
                    medewerkwerIds.Add(medewerker.ID);   
                }
                ddlMedewerkers.DataSource = medewerkwerIds;
                ddlMedewerkers.DataBind();

                List<Tram> datalijst = admin.GetAllOnderhoudTrams();
                List<int> tramIds = new List<int>();

                foreach (Tram t in datalijst)
                {
                    tramIds.Add(t.ID);
                }
                ddlOnderhoudsIDs.DataSource = tramIds;
                ddlOnderhoudsIDs.DataBind();
                ddlOnderhoudsIDs.Items[0].Selected = true;
                RefreshOnderhoudsoortList();
            }
        }

        protected void ddlOnderhoudsIDs_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshOnderhoudsoortList();
        }

        public void RefreshOnderhoudsoortList()
        {
            ddlOnderhoudSoort.Items.Clear();
            foreach (Tram tram in admin.GetAllOnderhoudTrams())
            {
                if (ddlOnderhoudsIDs.SelectedValue == tram.ID.ToString())
                {
                    if (tram.Defect)
                    {
                        ddlOnderhoudSoort.Items.Add("DEFECT");
                        ddlOnderhoudSoort.Items[0].Selected = true;
                    }
                    if (tram.Vervuild)
                    {
                        ddlOnderhoudSoort.Items.Add("VERVUILD");
                        ddlOnderhoudSoort.Items[0].Selected = true;
                    }
                }
            }

        }
    }
}