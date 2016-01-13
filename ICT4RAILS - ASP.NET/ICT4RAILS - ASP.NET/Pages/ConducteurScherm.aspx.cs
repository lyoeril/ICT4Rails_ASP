using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class ConducteurScherm : System.Web.UI.Page
    {
        private Administratie admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                admin = new Administratie();
            }
            catch (Exception en)
            {
                Console.WriteLine(en.Message);
            }

        }

        protected void btnBevestig_OnClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbxTramnummer.Text))
            {
                int tramnummer = Convert.ToInt32(tbxTramnummer.Text);
                string status = ddlNieuweStatus.SelectedItem.Text;

                foreach (Tram t in admin.Remise.Trams)
                {
                    if (t.Nummer == tramnummer)
                    {
                        t.Defect = cbDefect.Checked;
                        t.Vervuild = cbVervuild.Checked;
                        string onderhoudSoort = ddlNieuweStatus.SelectedItem.Text;
                        t.Status = onderhoudSoort;
                        admin.UpdateTram(t);

                        lblGevondenStatus.Text = status;
                    }
                }
            }
        }

        protected void btnCheckStatus_OnClick_OnClick(object sender, EventArgs e)
        {
            int tramnummer;
            try
            {
                tramnummer = Convert.ToInt32(tbxTramnummer.Text);

                foreach (Tram t in admin.Remise.Trams)
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
    }
}