﻿<%@ Page Title="Accountbeheer" Language="C#" MasterPageFile="~/Pages/AccountBeheerMaster.master" AutoEventWireup="true" CodeBehind="AccountbeheerIndex.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.Accountbeheer" %>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">    
    <form runat="server">
        <div class="container">
            <div id="page-content-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <h1>Medewerkers:</h1>
                        <asp:GridView ID="GridMedewerker1" runat="server" DataKeyNames="id" DataMember="naamMedewerker" OnRowDataBound="OnRowDataBound" OnRowDeleting="GridMedewerker1_OnRowDeleting"
                            EmptyDataText="Er zijn geen medewerkers meer." AutoGenerateDeleteButton="true"  Width="50%" class="table table-striped">
                         </asp:GridView>
                     </div>
                </div>
            </div>
        </div>
      </div>
      </form>
    </asp:Content>
