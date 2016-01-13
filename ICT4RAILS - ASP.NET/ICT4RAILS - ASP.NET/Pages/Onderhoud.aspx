<%@ Page Title="Onderhoud" Language="C#" MasterPageFile="~/Pages/SubMasterPage.master" AutoEventWireup="true" CodeBehind="Onderhoud.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.Onderhoud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link rel="stylesheet" href="/css/Onderhoud.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
    <div class="jumbotron">
        <form runat="server">
            <div class="container">
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <h1>Onderhoud</h1>
                        <div class="form-group">
                            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Vul eerst alle velden correct in."
                                DisplayMode="BulletList" ValidationGroup="1" EnableClientScript="true" ForeColor="Red" runat="server" />
                            <label>TramID:</label>
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
                            <label>Startdatum:</label>
                            <asp:TextBox type="number" ID="tbxStartDay" Width="40px" runat="server"></asp:TextBox>
                            <asp:TextBox type="number" ID="tbxStartMonth" Width="40px" runat="server"></asp:TextBox>
                            <asp:TextBox type="number" ID="tbxStartYear" Width="60px" runat="server"></asp:TextBox>
                            <label>Starttijd:</label>
                            <asp:TextBox type="number" ID="tbxStartHour" Width="40px" runat="server"></asp:TextBox>
                            <label>:</label>
                            <asp:TextBox type="number" ID="tbxStartMinute" Width="40px" runat="server"></asp:TextBox>
                            <br />
                            <label>Einddatum:</label>
                            <asp:TextBox type="number" ID="tbxEndDay" Width="40px" runat="server"></asp:TextBox>
                            <asp:TextBox type="number" ID="tbxEndMonth" Width="40px" runat="server"></asp:TextBox>
                            <asp:TextBox type="number" ID="tbxEndYear" Width="60px" runat="server"></asp:TextBox>
                            <label>Eindtijd:</label>
                            <asp:TextBox type="number" ID="tbxEndHour" Width="40px" runat="server"></asp:TextBox>
                            <label>:</label>
                            <asp:TextBox type="number" ID="tbxEndMinute" Width="40px" runat="server"></asp:TextBox>
                            <br/>
                            <br/>
                            <asp:Button ID="btnBevestigOnderhoud" CssClass="btn btn-default" Text="Bevestig Onderhoud" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
