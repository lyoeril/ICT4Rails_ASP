<%@ Page Title="Statusbeheer" Language="C#" MasterPageFile="~/Pages/SubMasterPage.master" AutoEventWireup="true" CodeBehind="Statusbeheer.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.Statusbeheer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link rel="stylesheet" href="/css/Statusbeheer.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
    <form class="form-horizontal" role="form" runat="server">
         <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2>Tramstatus aanpassen</h2>
                    <div class="form-group">
                        <label class="control-label col-sm-5">Tramnummer:</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="tbxTramnummer" type="number" CssClass="form-control col-sm-5" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:Button ID="btnCheckStatus" runat="server" CssClass="btn btn-default" Text="Check" OnClick="btnCheckStatus_OnClick" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5">Huidig:</label>
                        <div class="col-md-5">
                            <asp:Label AssociatedControlID="tbxTramnummer" ID="lblGevondenStatus" CssClass="control-label" runat="server" Text="Zoek een tram"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5">Nieuw:</label>
                        <div class="col-md-7">
                            <asp:DropDownList ID="ddlNieuweStatus" class="form-control" runat="server">
                                <asp:ListItem Value="Remise"></asp:ListItem>
                                <asp:ListItem Value="Dienst"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class=" col-sm-5"></label>
                        <div class="col-md-7">
                            <asp:Button ID="btnBevestig" CssClass="btn btn-default" runat="server" Text="Bevestig" OnClick="btnBevestig_OnClick" />
                        </div>
                    </div>
                </div>
                <div class="col-md-offset-1 col-md-5" float: left"/>
                    <h2>Onderhoud toevoegen</h2>
                    <div class="form-group">
                        <label class="control-label col-sm-5">Tramnummer:</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="tbxTramnummerOnderhoud" type="number" CssClass="form-control col-sm-5" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <label class="control-label col-sm-5">Nieuw:</label>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlVervuildDefect" class="form-control" runat="server">
                            <asp:ListItem Value="Vervuild"></asp:ListItem>
                            <asp:ListItem Value="Defect"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class=" col-sm-5"></label>
                        <div class="col-md-7">
                            <asp:Button ID="btnBevestigOnderhoud" CssClass="btn btn-default" Width="100%" runat="server" Text="Bevestig" OnClick="btnBevestigOnderhoud_OnClick" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class=" col-sm-5 control-label">Trams in onderhoud:</label>
                        <div class="col-md-7">
                            <asp:ListBox ID="lbTramsOnderhoud" Width="100%" runat="server" />
                        </div>
                    </div>
                
            </div>
        </div>
    </form>
</asp:Content>
