using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
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
                try
                {
                    admin = new Administratie();
                }
                catch (Exception en)
                {
                    Console.WriteLine(en.Message);
                }
                Tram t = null;

                foreach (Tram tram in admin.Remise.Trams)
                {
                    if (tram.Nummer.ToString() == tbxTramnummer.Text)
                    {
                        if (ddlNieuweStatus.SelectedItem.ToString() == "Remise" && tram.Status == "DIENST")
                        {
                            t = tram;
                            t.Status = ddlNieuweStatus.SelectedItem.Text;
                            t.Defect = cbDefect.Checked;
                            t.Vervuild = cbVervuild.Checked;
                            admin.LijnenInit();
                            admin.SorteerTram(t);
                            admin.UpdateTram(t);
                            foreach (Spoor spoor in admin.Remise.Sporen)
                            {
                                foreach (Sector sector in spoor.Sectoren)
                                {
                                    if (t.ID == sector.Tram?.ID)
                                    {
                                        Response.Write("<script>alert('De tram kan worden geplaatst op Spoor:" + spoor.Nummer + " en op Sector:" + sector.Nummer + "')</script>");
                                        break;
                                    }
                                }
                            }

                        }
                        else
                        {
                            Response.Write("<script>alert('De tram heeft al als status Remise!')</script>");
                        }
                        break;
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