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
                        <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Vul eerst alle velden correct in."
                            DisplayMode="BulletList" ValidationGroup="1" EnableClientScript="true" ForeColor="Red" runat="server" />
                        <label>Tramnummer:</label>
                        <input type="text" class="form-control" id="RemiseInputTramnr" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RemiseInputTramnr" ForeColor="Red" ValidationGroup="1" runat="server" ErrorMessage="" />
                    </div>
                    <div class="form-group">
                        <label>Tram Bewerking:</label>
                        <asp:DropDownList ID="ddlTrambeheer" CssClass="form-control" ValidationGroup="1" runat="server">
                            <asp:ListItem Text="--Kies Bewerking--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Reparatie" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Remise" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Dienst" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Schoonmaak" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="0" ControlToValidate="ddlTrambeheer" ForeColor="Red" ValidationGroup="1" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Lijn:</label>
                        <asp:DropDownList ID="ddlLijnen1" CssClass="form-control" ValidationGroup="1" runat="server">
                            <asp:ListItem Text="--Kies Lijn--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="5" Value="3"></asp:ListItem>
                            <asp:ListItem Text="10" Value="4"></asp:ListItem>
                            <asp:ListItem Text="13" Value="5"></asp:ListItem>
                            <asp:ListItem Text="17" Value="6"></asp:ListItem>
                            <asp:ListItem Text="16/24" Value="7"></asp:ListItem>
                            <asp:ListItem Text="OCV" Value="8"></asp:ListItem>
                            <asp:ListItem Text="RES" Value="9"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlLijnen1" InitialValue="0" ForeColor="Red" ValidationGroup="1" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Type:</label>
                        <asp:DropDownList ID="ddlTypes" CssClass="form-control" ValidationGroup="1" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlTypes" InitialValue="0" ForeColor="Red" ValidationGroup="1" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="trambeheerbevestig" CssClass="btn btn-default" ValidationGroup="1" runat="server" Text="Bevestig" OnClick="trambeheerbevestig_Click" />
                    </div>
                    <br />
                    <hr />
                    <h1>Spoorbeheer</h1>
                    <div class="form-group">
                        <asp:ValidationSummary ID="ValidationSummary2" HeaderText="Vul eerst alle velden correct in."
                            DisplayMode="BulletList" ValidationGroup="2" EnableClientScript="true" ForeColor="Red" runat="server" />
                        <label>Spoornummer:</label>
                        <input type="text" class="form-control" id="RemiseInputSpoornr" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="RemiseInputSpoornr" ForeColor="Red" ValidationGroup="2" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Lijnnummer:</label>
                        <asp:DropDownList ID="ddlLijnen2" CssClass="form-control" ValidationGroup="2" runat="server">
                            <asp:ListItem Text="--Kies Lijn--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="5" Value="3"></asp:ListItem>
                            <asp:ListItem Text="10" Value="4"></asp:ListItem>
                            <asp:ListItem Text="13" Value="5"></asp:ListItem>
                            <asp:ListItem Text="17" Value="6"></asp:ListItem>
                            <asp:ListItem Text="16/24" Value="7"></asp:ListItem>
                            <asp:ListItem Text="OCV" Value="8"></asp:ListItem>
                            <asp:ListItem Text="RES" Value="9"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" ControlToValidate="ddlLijnen2" ForeColor="Red" ValidationGroup="2" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Tramnummer:</label>
                        <asp:DropDownList ID="ddlTrams" CssClass="form-control" ValidationGroup="2" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" InitialValue="0" ControlToValidate="ddlTrams" ForeColor="Red" ValidationGroup="2" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Spoor Bewerking:</label>
                        <asp:DropDownList ID="ddlSpoorbeheer" CssClass="form-control" ValidationGroup="2" runat="server">
                            <asp:ListItem Text="--Kies Bewerking--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Blokkeren" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Reserveren" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Dienst" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Beschikbaar" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlSpoorbeheer" ForeColor="Red" InitialValue="0" ValidationGroup="2" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="spoorbeheerbevestig" CssClass="btn btn-default" ValidationGroup="2" runat="server" Text="Bevestig" OnClick="spoorbeheerbevestig_Click" />
                    </div>
                    <br />
                    <hr />
                    <h1>Nieuw Tram Type</h1>
                    <div class="form-group">
                        <asp:ValidationSummary ID="ValidationSummary3" HeaderText="Vul eerst alle velden correct in."
                            DisplayMode="BulletList" ValidationGroup="3" EnableClientScript="true" ForeColor="Red" runat="server" />
                        <label>Type naam:</label>
                        <input type="text" class="form-control" id="RemiseInputTypeNaam" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="RemiseInputTypeNaam" ForeColor="Red" ValidationGroup="3" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Beschrijving:</label>
                        <input type="text" class="form-control" id="RemiseInputTypeBeschrijving" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="RemiseInputTypeBeschrijving" ForeColor="Red" ValidationGroup="3" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Lengte:</label>
                        <input type="number" class="form-control" id="RemiseInputTypeLengte" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="RemiseInputTypeLengte" ForeColor="Red" ValidationGroup="3" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="typebevestig" CssClass="btn btn-default" ValidationGroup="3" runat="server" Text="Bevestig" OnClick="typebevestig_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
