using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            reloadOnderhoudlist();
            loadGeschiedenis();

            if (!IsPostBack)
            {
                SetTimeToday();
                reloadOnderhoudlist();
                List<Medewerker> medewerkers = admin.Medewerkers;
                List<string>medewerkerNaam = new List<string>();
                foreach (Medewerker medewerker in medewerkers)
                {
                    medewerkerNaam.Add(medewerker.Naam);   
                }
                ddlMedewerkers.DataSource = medewerkerNaam;
                ddlMedewerkers.DataBind();

                loadIdsAndSoorten();
                
                
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
            int onderhoudId = 0;
            if (!String.IsNullOrWhiteSpace(tbxOnderhoudIdToEnd.Text))
            {
                onderhoudId = Convert.ToInt32(tbxOnderhoudIdToEnd.Text);
            }
            foreach (TramOnderhoud tramOnderhoud in admin.Onderhoudsbeurten)
            {
                if (tramOnderhoud.ID == onderhoudId)
                {
                    admin.UpdateTramOnderhoudToDone(tramOnderhoud.ID, tramOnderhoud.TypeOnderhoud, tramOnderhoud.TramId);
                    reloadOnderhoudlist();
                    Response.Redirect(Request.RawUrl);
                }
            }
            
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

            try
            {
                TramOnderhoud tramOnderhoud = new TramOnderhoud(0, null, beschikbaarDatum, ddlOnderhoudSoort.SelectedValue, medewerker.ID, insertTram.ID);
                admin.AddTramOnderhoud(tramOnderhoud);
                Response.Redirect(Request.RawUrl);
                reloadOnderhoudlist();
            }
            catch
            {
                
            }
        }

        public void reloadOnderhoudlist()
        {
            List<TramOnderhoud> huidigeOnderhouden = new List<TramOnderhoud>();
            foreach (TramOnderhoud th in admin.Onderhoudsbeurten)
            {
                if (th.Tram.Defect || th.Tram.Vervuild)
                {
                    if (th.DatumTijdstip == null)
                    {
                        huidigeOnderhouden.Add(th);
                    }
                }
            }
            Table1.Rows.Clear();
            //TODO products[] niet hardcoded
            int numrows = huidigeOnderhouden.Count;
            int numcells = 1;

            for (int j = 0; j < numrows; j++)
            {
                TableRow r = new TableRow();
                for (int i = 0; i < numcells; i++)
                {
                    TableCell c = new TableCell();
                    TableCell d = new TableCell();
                    TableCell e = new TableCell();
                    TableCell f = new TableCell();
                    c.Controls.Add(new LiteralControl("OnderhoudID: " + huidigeOnderhouden[j].ID.ToString()));
                    d.Controls.Add(new LiteralControl("Tram: " + huidigeOnderhouden[j].Tram.Nummer));
                    e.Controls.Add(new LiteralControl("Medewerker: " + huidigeOnderhouden[j].Medewerker.Naam));
                    f.Controls.Add(new LiteralControl("Type: " + huidigeOnderhouden[j].TypeOnderhoud.ToString()));
                    r.Cells.Add(c);
                    r.Cells.Add(d);
                    r.Cells.Add(e);
                    r.Cells.Add(f);
                }
                Table1.Rows.Add(r);
            }

            


        }
        public void loadIdsAndSoorten()
        {
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
            if (tramIds.Count >= 1)
            {
                ddlOnderhoudsIDs.Items[0].Selected = true;
                RefreshOnderhoudsoortList();
                reloadOnderhoudlist();
            }
        }

        public void loadGeschiedenis()
        {
            List<TramOnderhoud> tramOnderhouden = new List<TramOnderhoud>();
            foreach (TramOnderhoud th in admin.Onderhoudsbeurten)
            {
                if (th.DatumTijdstip != null)
                {
                    tramOnderhouden.Add(th);
                }
            }

            if (tramOnderhouden.Count >= 1)
            {
                tableGeschiedenis.Rows.Clear();
                int rows = tramOnderhouden.Count;
                int cells = 1;

                for (int j = 0; j < rows; j++)
                {
                    TableRow r = new TableRow();
                    for (int i = 0; i < cells; i++)
                    {
                        TableCell c = new TableCell();
                        TableCell d = new TableCell();
                        TableCell e = new TableCell();
                        TableCell f = new TableCell();
                        TableCell g = new TableCell();
                        c.Controls.Add(new LiteralControl("OnderhoudID: " + tramOnderhouden[j].ID.ToString()));
                        d.Controls.Add(new LiteralControl("Tram: " + tramOnderhouden[j].Tram.Nummer));
                        e.Controls.Add(new LiteralControl("Medewerker: " + tramOnderhouden[j].Medewerker.Naam));
                        f.Controls.Add(new LiteralControl("Type: " + tramOnderhouden[j].TypeOnderhoud.ToString()));
                        g.Controls.Add(new LiteralControl("Afgesloten: " + tramOnderhouden[j].DatumTijdstip.ToString()));
                        r.Cells.Add(c);
                        r.Cells.Add(d);
                        r.Cells.Add(e);
                        r.Cells.Add(f);
                        r.Cells.Add(g);
                    }
                    tableGeschiedenis.Rows.Add(r);
                }


            }
        }
    }
}