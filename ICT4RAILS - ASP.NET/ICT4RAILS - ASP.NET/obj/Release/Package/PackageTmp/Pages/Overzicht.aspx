﻿<%@ Page Title="Overzicht" Language="C#" MasterPageFile="~/Pages/SubMasterPage.master" AutoEventWireup="true" CodeBehind="Overzicht.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.Overzicht" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link rel="stylesheet" href="/css/Overzicht.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
    <div class="tableStyle">
        <asp:Table ID="OverzichtTable" runat="server" GridLines="Both" CellPadding="10" HorizontalAlign="Center"></asp:Table>
    </div>
</asp:Content>
