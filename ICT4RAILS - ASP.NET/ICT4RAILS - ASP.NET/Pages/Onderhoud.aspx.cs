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
                SetTimeToday();

                List<Medewerker> medewerkers = admin.Medewerkers;
                List<string>medewerkerNaam = new List<string>();
                foreach (Medewerker medewerker in medewerkers)
                {
                    medewerkerNaam.Add(medewerker.Naam);   
                }
                ddlMedewerkers.DataSource = medewerkerNaam;
                ddlMedewerkers.DataBind();

                List<Tram> datalijst = admin.Remise.Trams;
                List<int> tramIds = new List<int>();

                foreach (Tram t in datalijst)
                {
                    if (t.Defect || t.Vervuild)
                    {
                        tramIds.Add(t.Nummer);
                    }
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
            foreach (Tram tram in admin.Remise.Trams)
            {
                if (tram.Nummer.ToString() == ddlOnderhoudsIDs.SelectedValue)
                {
                    foreach (Tram tram2 in admin.GetAllOnderhoudTrams())
                    {
                        if (tram2.ID.ToString() == tram.ID.ToString())
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

        public void loadHuidigeOnderhoudenList()
        {
            foreach (TramOnderhoud to in admin.Onderhoudsbeurten)
            {
                
            }
        }

        public void SetTimeToday()
        {
            tbxEndDay.Text = DateTime.Today.Day.ToString();
            tbxEndMonth.Text = DateTime.Today.Month.ToString();
            tbxEndYear.Text = DateTime.Today.Year.ToString();
            tbxEndHour.Text = DateTime.Today.Hour.ToString();
            tbxEndMinute.Text = DateTime.Today.Minute.ToString();
        }

        protected void btnBevestigEindOnderhoud_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void btnBevestigOnderhoud_OnClick(object sender, EventArgs e)
        {
            int dag = Convert.ToInt32(tbxEndDay.Text);
            int maand = Convert.ToInt32(tbxEndMonth.Text);
            int jaar = Convert.ToInt32(tbxEndYear.Text);
            int hour = Convert.ToInt32(tbxEndHour.Text);
            int minute = Convert.ToInt32(tbxEndMinute.Text);
            DateTime beschikbaarDatum = new DateTime(jaar, maand, dag, hour, minute, 0);

            Tram insertTram = null;
            foreach (Tram tram in admin.Remise.Trams)
            {
                if (tram.Nummer.ToString() == ddlOnderhoudsIDs.SelectedValue)
                {
                    foreach (Tram tram2 in admin.GetAllOnderhoudTrams())
                    {
                        if (tram2.ID.ToString() == tram.ID.ToString())
                        {
                            insertTram = tram2;
                        }
                    }
                }
            }

            Medewerker medewerker = null;
            foreach (Medewerker m in admin.Medewerkers)
            {
                if (ddlMedewerkers.SelectedValue == m.Naam)
                {
                   medewerker = new Medewerker(m.ID, m.Naam, m.Functie.ID);
                }
            }

            TramOnderhoud tramOnderhoud = new TramOnderhoud(0, null, beschikbaarDatum, ddlOnderhoudSoort.SelectedValue, medewerker.ID, insertTram.ID);
            admin.AddTramOnderhoud(tramOnderhoud);
        }

        public void reloadOnderhoudlist()
        {
            foreach (TramOnderhoud th in admin.Onderhoudsbeurten)
            {
                lbHuidigeOnderhouden.Items.Add(th.ToString());
            }
        }
    }
}