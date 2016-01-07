<%@ Page Title="Statusbeheer" Language="C#" MasterPageFile="~/Pages/SubMasterPage.master" AutoEventWireup="true" CodeBehind="Statusbeheer.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.Statusbeheer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link rel="stylesheet" href="/css/Statusbeheer.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
    <div class="row">
        <div class="col-md-4">
            <form class="form-horizontal" role="form" runat="server">
                <div class="form-group">
                    <label class="control-label col-sm-5">Tramnummer:</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="tbxTramnummer" type="number" CssClass="form-control col-sm-5" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="btnCheckStatus" runat="server" CssClass="btn btn-default" Text="Check Status" OnClick="btnCheckStatus_OnClick"/>
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
                        <asp:DropDownList id="ddlNieuweStatus" class="form-control" runat="server">
                            <asp:ListItem Value="Remise"></asp:ListItem>
                            <asp:ListItem Value="Dienst"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class=" col-sm-5"> </label>
                    <div class="col-md-7">
                        <asp:Button ID="btnBevestig" CssClass="btn btn-default" runat="server" Text="Bevestig"/>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
