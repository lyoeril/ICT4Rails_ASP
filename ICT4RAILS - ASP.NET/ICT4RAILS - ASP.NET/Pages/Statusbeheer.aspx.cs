using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class Statusbeheer : System.Web.UI.Page
    {

        private Administratie _administratie;
        protected void Page_Load(object sender, EventArgs e)
        {
            _administratie = new Administratie();

            if (!IsPostBack)
            {
                LoadOnderhoudList();
            }
        }


        protected void btnCheckStatus_OnClick(object sender, EventArgs e)
        {
            int tramnummer;
            try
            {
                tramnummer = Convert.ToInt32(tbxTramnummer.Text);

                foreach (Tram t in _administratie.Remise.Trams)
                {
                    if (t.Nummer == tramnummer)
                    {
                        lblGevondenStatus.Text = t.Status.ToString();
                    }
                }
                if (String.IsNullOrWhiteSpace(lblGevondenStatus.Text))
                {
                    Response.Write("<script>alert('Er is een fout tramnummer ingevuld')</script>");
                }

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Er is een fout tramnummer ingevuld')</script>");
            }
        }

        protected void btnBevestig_OnClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbxTramnummer.Text))
            {
                int tramnummer = Convert.ToInt32(tbxTramnummer.Text);
                string status = ddlNieuweStatus.SelectedItem.Text;

                foreach (Tram t in _administratie.Remise.Trams)
                {
                    if (t.Nummer == tramnummer)
                    {
                        _administratie.UpdateTramStatus(t.ID, status);
                        
                        lblGevondenStatus.Text = status;
                    }
                }
            }

        }

        protected void btnBevestigOnderhoud_OnClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbxTramnummerOnderhoud.Text))
            {
                int tramnummer = Convert.ToInt32(tbxTramnummerOnderhoud.Text);
                string onderhoudSoort = ddlVervuildDefect.SelectedItem.Text;
                _administratie.UpdateTramToOnderhoud(tramnummer, onderhoudSoort);
                    LoadOnderhoudList();
                    Response.Redirect(Request.RawUrl);
            }
            
        }

        public void LoadOnderhoudList()
        {
            
            lbTramsOnderhoud.Items.Clear();
            foreach (Tram t in _administratie.GetAllOnderhoudTrams())
            {
                if (t.Defect && t.Vervuild)
                {
                    lbTramsOnderhoud.Items.Add(t.Nummer + ", DEFECT & VERVUILD");
                }
                else if (t.Defect)
                {
                    lbTramsOnderhoud.Items.Add(t.Nummer + ", DEFECT");
                }
                else if (t.Vervuild)
                {
                    lbTramsOnderhoud.Items.Add(t.Nummer + ", VERVUILD");
                }
            }
        }

    }
}