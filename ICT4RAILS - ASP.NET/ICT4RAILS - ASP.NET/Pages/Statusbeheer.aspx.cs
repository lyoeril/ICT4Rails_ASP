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
        }
        /*

        protected void btnCheckStatus_OnClick(object sender, EventArgs e)
        {
            int tramnummer = Convert.ToInt32(tbxTramnummer.Text);
            Tram tram = _administratie.FindTram(tramnummer);
            string gevondenStatus = tram.Status.ToString();
            lblGevondenStatus.Text = gevondenStatus;
        }

        protected void btnBevestig_OnClick(object sender, EventArgs e)
        {
            int tramnummer = Convert.ToInt32(tbxTramnummer.Text);
            string status = ddlNieuweStatus.SelectedItem.Text;
            _administratie.UpdateTramStatus(tramnummer, status);
           
        }

        protected void btnBevestigOnderhoud_OnClick(object sender, EventArgs e)
        {
            int tramnummer = Convert.ToInt32(tbxTramnummerOnderhoud.Text);
            string opmerking = tbxOpmerkingOnderhoud.Text;
        }
        */
    }
}