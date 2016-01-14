<%@ Page Title="Account Aanmaken" Language="C#" MasterPageFile="~/Pages/SubMasterPage.master" AutoEventWireup="true" CodeBehind="AccountAanmaken.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link rel="stylesheet" href="/css/Accountbeheer.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
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
                        <asp:TextBox CssClass="form-control" ID="tbxAchternaam" required="" runat="server"></asp:TextBox>
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
                        <label for="txtMederwerkerWachtwoord1">Medewerker wachtwoord:</label>
                        <asp:TextBox CssClass="form-control" ID="txtMederwerkerWachtwoord1" required="" runat="server" TextMode="password" ></asp:TextBox>
                        <label for="txtMederwerkerWachtwoord2">Bevestig wachtwoord:</label>
                        <asp:TextBox CssClass="form-control" ID="txtMederwerkerWachtwoord2" required="" runat="server" TextMode="password" ></asp:TextBox>
                        <asp:CompareValidator runat=server
                                controltovalidate="txtMederwerkerWachtwoord1"
                                controltocompare="txtMederwerkerWachtwoord2" 
                                CssClass="Error" errormessage="Wachtwoorden komen niet overheen."/>
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
