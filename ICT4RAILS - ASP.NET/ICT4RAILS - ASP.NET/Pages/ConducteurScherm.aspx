<%@ Page Title="Conducteursscherm" Language="C#" MasterPageFile="~/Pages/SubMasterPage.master" AutoEventWireup="true" CodeBehind="ConducteurScherm.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.ConducteurScherm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link rel="stylesheet" href="/css/ConducteurScherm.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">

    <form class="form-horizontal" role="form" runat="server">
        <div class="row">
            <div class="container">
                <div class="col-md-offset-1 col-md-5" style="border: 2px solid grey;">
                    <h2>Tramstatus aanpassen</h2>
                    <div class="form-group">
                        <label class="control-label col-sm-5">Tramnummer:</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="tbxTramnummer" type="number" CssClass="form-control col-sm-5" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:Button ID="btnCheckStatus_OnClick" runat="server" CssClass="btn btn-default" Text="Check" OnClick="btnCheckStatus_OnClick_OnClick" />
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
                        <label class="control-label col-sm-5">Vervuild:</label>
                        <div class="col-md-7">
                            <asp:CheckBox ID="cbVervuild" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5">Defect:</label>
                        <div class="col-md-7">
                            <asp:CheckBox ID="cbDefect" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class=" col-sm-5"></label>
                        <div class="col-md-7">
                            <asp:Button ID="btnBevestig" CssClass="btn btn-default" runat="server" Text="Bevestig" OnClick="btnBevestig_OnClick" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
