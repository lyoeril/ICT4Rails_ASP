<%@ Page Title="Overzicht" Language="C#" MasterPageFile="~/Pages/SubMasterPage.master" AutoEventWireup="true" CodeBehind="Overzicht.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.Overzicht" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link rel="stylesheet" href="/css/Overzicht.css" />
    <link rel="script" href="/JS/Overzicht.js" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
    <div class="tableStyle">
        <asp:Table ID="OverzichtTable" runat="server" style="text-align: center" CellPadding="10" HorizontalAlign="Center"/>
    </div>
    <form runat="server">
        <asp:TextBox ID="tbxBarcode" clientidmode="Static" runat="server" onkeypress="return EnterEvent(event)" autofocus="true"/>    
        <asp:Button ID="btnBarcode" runat="server" style="display:none" Text="Button" OnClick="btnBarcode_Click" />
    </form>
</asp:Content>