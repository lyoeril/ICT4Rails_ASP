<%@ Page Title="Remisebeheer" Language="C#" MasterPageFile="~/Pages/SubMasterPage.master" AutoEventWireup="true" CodeBehind="Remisebeheer.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.Remisebeheer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link rel="stylesheet" href="/CSS/Remisebeheer.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
    <form runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <h1>Trambeheer</h1>
                    <div class="form-group">
                        <label for="RemiseLabelTramnr">Tramnummer:</label>
                        <input type="text" class="form-control" id="RemiseInputTramnr">
                    </div>
                    <div class="form-group">
                        <label for="RemiseLabelBewerking">Bewerking:</label>
                        <asp:DropDownList ID="ddlTrambeheer" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Schoonmaak" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Reparatie" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Remise" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Dienst" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="RemiseLabelLijn">Lijn:</label>
                        <asp:DropDownList ID="ddlLijnen" CssClass="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="RemiseLabelType">Type:</label>
                        <asp:DropDownList ID="ddlTypes" CssClass="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="trambeheerbevestig" CssClass="btn btn-default" runat="server" Text="Bevestig" />
                    </div>
                    <br />
                    <hr />
                    <h1>Spoorbeheer</h1>
                    <div class="form-group">
                        <label for="RemiseLabelspoornr">Spoornummer:</label>
                        <input type="text" class="form-control" id="RemiseInputSpoornr">
                    </div>
                    <div class="form-group">
                        <label for="RemiseLabellijnnr">Lijnnummer:</label>
                        <input type="text" class="form-control" id="RemiseInputLijnnr">
                    </div>
                    <div class="form-group">
                        <label for="RemiseLabelTramnr2">Tramnummer:</label>
                        <input type="text" class="form-control" id="RemiseInputTramnr2">
                    </div>
                    <div class="form-group">
                        <label for="RemiseLabelBewerking2">Bewerking:</label>
                        <asp:DropDownList ID="ddlSpoorbeheer" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Beschikbaar" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Blokkeren" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Reserveren" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Dienst" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="spoorbeheerbevestig" CssClass="btn btn-default" runat="server" Text="Bevestig" />
                    </div>
                    <br />
                    <hr />
                    <h1>Nieuw Tram Type</h1>
                    <div class="form-group">
                        <label for="RemiseLabelnieuwtramtype">Type naam:</label>
                        <input type="text" class="form-control" id="RemiseInputTypeNaam">
                    </div>
                    <div class="form-group">
                        <label for="RemiseLabeltypebeschrijving">Beschrijving:</label>
                        <input type="text" class="form-control" id="RemiseInputTypeBeschrijving">
                    </div>
                    <div class="form-group">
                        <label for="RemiseLabeltypelengte">Lengte:</label>
                        <input type="number" class="form-control" id="RemiseInputTypeLengte">
                    </div>
                    <div class="form-group">
                        <asp:Button ID="typebevestig" CssClass="btn btn-default" runat="server" Text="Bevestig" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
