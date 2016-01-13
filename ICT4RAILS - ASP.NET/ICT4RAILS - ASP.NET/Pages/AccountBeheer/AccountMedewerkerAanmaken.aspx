﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AccountBeheer/AccountBeheerMaster.master" AutoEventWireup="true" CodeBehind="AccountMedewerkerAanmaken.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.AccountBeheer.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">
     <form runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h1>Medewerker aanmaken</h1>
                    <div class="form-group">
                        <label for="txtMederwerkerNaam">Voornaam:</label>
                        <asp:TextBox type="text" CssClass="form-control" ID="txtMederwerkerNaam" required="" runat="server"></asp:TextBox>
                    </div>
                     <div class="form-group">
                        <label for="txtMederwerkerAchternaam">Achternaam:</label>
                    </div>
                    <hr />
                     <div class="form-group">
                        <label for="dllFuncties">Functie:</label>
                        <asp:DropDownList ID="dllFuncties" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Beheerder" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Wagenparkbeheerder" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Bestuurder" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Technicus" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Schoonmaker" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                <div class="form-group">
                        <label for="txtMederwerkerWachtwoord">Medewerker wachtwoord:</label>
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Button ID="MedewerkerBevestig" CssClass="btn btn-default" runat="server" Text="Bevestig" OnClick="MedewerkerBevestig_OnClick"/>
                    </div>
                </div>
            </div>
         </div>
        </form>
</asp:Content>
