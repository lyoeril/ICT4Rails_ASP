<%@ Page Title="Login" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link rel="stylesheet" href="/css/Login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <form class="form-signin" runat="server">
        <div class="container">
            <h2 class="form-signin-heading">Inloggen</h2>
            <label for="inputEmail" class="sr-only">Email address</label>
            <asp:TextBox ID="txtInputUsername" runat="server" CssClass="form-control" placeholder ="Gebruikersnaam" required="" autofocus=""></asp:TextBox>
            <label for="inputPassword" class="sr-only">Password</label>
            <asp:TextBox ID="txtInputPassword" runat="server" CssClass="form-control" placeholder ="Wachtwoord" required="" autofocus=""></asp:TextBox>
            <div class="checkbox">
            </div>
            <asp:Button ID="bttnInloggen" runat="server" Text="Inloggen" CssClass="btn btn-lg btn-primary btn-block" type ="submit"/>
        </div>
    </form>
</asp:Content>
