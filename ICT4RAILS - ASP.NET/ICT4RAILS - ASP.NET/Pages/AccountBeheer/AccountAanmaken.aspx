<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AccountBeheer/AccountBeheerMaster.master" AutoEventWireup="true" CodeBehind="AccountAanmaken.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.AccountBeheer.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-5">
            <h1>Account aanmaken</h1>
            <h2>Inlog gegevens invullen:</h2>
            <form class="form-horizontal" role="form" runat="server">
            <div class="form-group">
                <label class="control-label col-sm-4">Voornaam medewerker:</label>
                <div class="col-sm-8">
                    <asp:TextBox type="text" CssClass="form-control" ID="tbxVoornaam" required="" runat="server"></asp:TextBox>
                 </div>
               </div>
                <div class="form-group">
                    <label class="control-label col-sm-4">Achternaam medewerker:</label>
                    <div class="col-sm-8">
                        <asp:TextBox type="text" CssClass="form-control" ID="tbxAchternaam" required="" runat="server"></asp:TextBox>
                    </div>
                 </div>
                <div class="form-group">
                    <label class="control-label col-sm-4">Login Naam:</label>
                    <div class="col-sm-8">
                        <asp:TextBox type="text" CssClass="form-control" ID="tbxLoginnaam" required="" runat="server"></asp:TextBox>
                    </div>
                </div>
             <div class="form-group">
                    <label class="control-label col-sm-4">Wachtwoord:</label>
                    <div class="col-sm-8">
                        <asp:TextBox type="text"  CssClass="form-control" ID="tbxWachtwoord" required="" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-4 col-sm-10">
                        <asp:Button type="submit" CssClass="btn btn-default" runat="server" Text="Bevestigen" OnClick="OnClick"/>
                    </div>
                </div>
            </form>
        </div>
    </div>
 </div>
</asp:Content>
