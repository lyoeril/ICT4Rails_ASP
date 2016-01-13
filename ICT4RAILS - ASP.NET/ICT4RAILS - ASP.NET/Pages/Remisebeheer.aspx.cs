using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class Remisebeheer : System.Web.UI.Page
    {
        private Administratie admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            VulLijsten();
            ddlSpoorTrams.Enabled = false;
            RequiredFieldValidator7.Enabled = false;
        }

        protected void trambeheerbevestig_Click(object sender, EventArgs e)
        {
            admin = new Administratie();
            Tram t = null;

            foreach (Tram tram in admin.Remise.Trams.Where(tram => tram.ID.ToString() == ddlTrams.SelectedItem.Value))
            {
                t = tram;
                t.Status = ddlTrambeheerBewerking.SelectedItem.Text;

                t.Defect = cbDefect.Checked == true;

                t.Vervuild = cbVervuild.Checked == true;

                admin.UpdateTram(t);
                break;
            }
        }

        protected void spoorbeheerbevestig_Click(object sender, EventArgs e)
        {
            admin = new Administratie();
            Tram _tram = admin.Remise.Trams.FirstOrDefault(tram => tram.ID.ToString() == ddlSpoorTrams.SelectedItem.Value);
            Spoor _spoor = admin.Remise.Sporen.FirstOrDefault(spoor => spoor.Nummer.ToString() == ddlSporen.SelectedItem.Value);
            List<Sector> _sectoren = new List<Sector>();
            Sector _sector = null;

            if (_spoor != null)
            {
                foreach (Sector sector in _spoor.Sectoren.Where(sector => sector.Nummer.ToString() == ddlSectoren.SelectedItem.Value))
                {
                    _sector = sector;
                }
            }

            if (ddlSpoorbeheerBewerking.SelectedItem.Text == "Blokkeren")
            {
                _sectoren.AddRange(_spoor.Sectoren.Where(sector => sector.Nummer <= _sector.Nummer));

                foreach (Sector sectorToUpdate in _sectoren)
                {
                    sectorToUpdate.Beschikbaar = false;
                    if (sectorToUpdate.Tram != null)
                    {
                        sectorToUpdate.Tram.Beschikbaar = true;
                        sectorToUpdate.Tram = null;
                        admin.UpdateTram(sectorToUpdate.Tram);
                    }
                    admin.UpdateSector(sectorToUpdate);
                }
            }
            else if (ddlSpoorbeheerBewerking.SelectedItem.Text == "Reserveren")
            {
                foreach (Sector sector in _spoor.Sectoren)
                {
                    if (sector.Nummer < _sector.Nummer && sector.Beschikbaar == true)
                    {
                        _sector = sector;
                    }
                }

                _sector.Beschikbaar = false;
                admin.UpdateSector(_sector);

                admin.InsertReservering(new Reservering(_tram, _spoor));
            }
            else if (ddlSpoorbeheerBewerking.SelectedItem.Text == "Deblokkeren")
            {
                _sectoren.AddRange(_spoor.Sectoren.Where(sector => sector.Nummer >= _sector.Nummer));

                foreach (Sector sectorToUpdate in _sectoren)
                {
                    sectorToUpdate.Beschikbaar = true;
                    sectorToUpdate.Tram = null;
                    admin.UpdateSector(sectorToUpdate);
                }
            }
        }

        private void VulLijsten()
        {
            admin = new Administratie();
            if (ddlTrams.Items.Count == 0)
            {
                ddlTrams.Items.Clear();
                ddlSporen.Items.Clear();
                ddlSpoorTrams.Items.Clear();

                foreach (Tram tram in admin.Remise.Trams)
                {
                    ddlTrams.Items.Insert(0, new ListItem(tram.ToString(), tram.ID.ToString()));
                    ddlSpoorTrams.Items.Insert(0, new ListItem(tram.ToString(), tram.ID.ToString()));
                }

                foreach (Spoor spoor in admin.Remise.Sporen)
                {
                    ddlSporen.Items.Insert(0, new ListItem(spoor.Nummer.ToString(), spoor.Nummer.ToString()));
                }

                ddlSectoren.Items.Insert(0, new ListItem("--Kies Sector--", "0"));
                ddlSporen.Items.Insert(0, new ListItem("--Kies Spoor--", "0"));
                ddlTrams.Items.Insert(0, new ListItem("--Kies Tram--", "0"));
                ddlSpoorTrams.Items.Insert(0, new ListItem("--Kies Tram--", "0"));
            }
        }

        protected void ddlSpoorbeheerBewerking_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSpoorTrams.Enabled = ddlSpoorbeheerBewerking.SelectedItem.Text == "Reserveren";
            RequiredFieldValidator7.Enabled = ddlSpoorbeheerBewerking.SelectedItem.Text == "Reserveren";
        }

        protected void ddlSporen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSectoren.Items.Clear();

            if (ddlSporen.SelectedItem.Value != "0")
            {
                ddlSectoren.Enabled = true;
                RequiredFieldValidator3.Enabled = true;

                foreach (Sector sector in admin.Remise.Sporen.Where(spoor => spoor.Nummer.ToString() == ddlSporen.SelectedItem.Value).SelectMany(spoor => spoor.Sectoren))
                {
                    ddlSectoren.Items.Add(new ListItem(sector.ToString(), sector.Nummer.ToString()));
                }
            }
            else
            {
                ddlSectoren.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
            }
        }
    }
}