﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4RAILS___ASP.NET.Csharp;
using System.Configuration;

namespace ICT4RAILS___ASP.NET.Pages
{
    public partial class Accountbeheer : System.Web.UI.Page
    {
        private Administratie _admin;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _admin = new Administratie();

            if (!this.IsPostBack)
            {
                this.LoadInfo();
            }
        }

        public void LoadInfo()
        {
            GridMedewerker1.DataSource = _admin.Medewerkers;
            GridMedewerker1.DataBind();
        }

        protected void GridMedewerker1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void GridMedewerker1_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int medewerkerid = Convert.ToInt32(GridMedewerker1.DataKeys[e.RowIndex].Values[0]);

            _admin.RemoveMedewerker(_admin.FindMedewerker((medewerkerid)));
            this.LoadInfo();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridMedewerker1.EditIndex)
            {
                (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void GridMedewerker1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridMedewerker1.EditIndex = e.NewEditIndex; // turn to edit mode
            LoadInfo();
        }
    }
}