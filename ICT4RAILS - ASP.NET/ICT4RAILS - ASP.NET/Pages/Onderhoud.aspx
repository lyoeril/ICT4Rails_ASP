<%@ Page Title="Onderhoud" Language="C#" MasterPageFile="~/Pages/SubMasterPage.master" AutoEventWireup="true" CodeBehind="Onderhoud.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.Onderhoud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link rel="stylesheet" href="/css/Onderhoud.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
        <form runat="server">
            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <h1>Onderhoud</h1>
                        <div class="form-group">
                            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Vul eerst alle velden correct in."
                                DisplayMode="BulletList" ValidationGroup="1" EnableClientScript="true" ForeColor="Red" runat="server" />
                            <label>Tramnummer:</label>
                            <asp:DropDownList ID="ddlOnderhoudsIDs" CssClass="form-control" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlOnderhoudsIDs_OnSelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                            <label>Onderhoud vanwege:</label>
                            <asp:DropDownList ID="ddlOnderhoudSoort" CssClass="form-control" ValidationGroup="1" runat="server">
                            </asp:DropDownList>
                            <br />
                            <label>MedewerkerID:</label>
                            <asp:DropDownList ID="ddlMedewerkers" CssClass="form-control" runat="server" />
                            <br />
                            <label>Verwachte Einddatum:</label>
                            <asp:TextBox type="number" ID="tbxEndDay" Width="40px" runat="server"></asp:TextBox>
                            <asp:TextBox type="number" ID="tbxEndMonth" Width="40px" runat="server"></asp:TextBox>
                            <asp:TextBox type="number" ID="tbxEndYear" Width="60px" runat="server"></asp:TextBox>
                            <label>Verwachte Eindtijd:</label>
                            <asp:TextBox type="number" ID="tbxEndHour" Width="40px" runat="server"></asp:TextBox>
                            <label>:</label>
                            <asp:TextBox type="number" ID="tbxEndMinute" Width="40px" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="btnBevestigOnderhoud" CssClass="btn btn-default" Text="Bevestig Onderhoud" runat="server" OnClick="btnBevestigOnderhoud_OnClick" />
                        </div>
                        <h1>Huidige onderhouden</h1>
                        <div class="form-group">
                            <asp:Table ID="Table1"
                                GridLines="Both"
                                HorizontalAlign="Center"
                                Font-Names="Verdana"
                                Font-Size="8pt"
                                CellPadding="15"
                                CellSpacing="0"
                                runat="server" />
                            <label>Te voltooien onderhoudID:</label>
                            <asp:TextBox runat="server" type="number" CssClass="form-control" ID="tbxOnderhoudIdToEnd"></asp:TextBox> 
                            <asp:Button ID="btnBevestigEindOnderhoud" Text="Bevestig geslaagd onderhoud" CssClass="btn btn-default" runat="server" OnClick="btnBevestigEindOnderhoud_OnClick" />
                        </div>
                        
                        <div class="form-group">
                            <label>Geschiedenis</label>
                            <asp:Table ID="tableGeschiedenis"
                                GridLines="Both"
                                HorizontalAlign="Center"
                                Font-Names="Verdana"
                                Font-Size="8pt"
                                CellPadding="15"
                                CellSpacing="0"
                                runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </form>
</asp:Content>
