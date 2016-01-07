<%@ Page Title="Accountbeheer" Language="C#" MasterPageFile="~/Pages/SubMasterPage.master" AutoEventWireup="true" CodeBehind="Accountbeheer.aspx.cs" Inherits="ICT4RAILS___ASP.NET.Pages.Accountbeheer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link href="../CSS/Accountbeheer.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
    <div id="wrapper">
        <div id="sidebar-wrapper">
            <ul class="sidebar-nav">
                <li>
                    <a href="#">Overzicht</a>
                </li>
                <li>
                    <a href="#">1</a>
                </li>
                <li>
                    <a href="#">2</a>
                </li>
                <li>
                    <a href="#">3</a>
                </li>
                <li>
                    <a href="#">4</a>
                </li>
            </ul>
        </div>
        <div id="page-content-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <h1>test</h1>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="50%" onrowdatabound="grdStudentList_RowDataBound">
                          <Columns>
                              <asp:TemplateField HeaderText="Medewerker ID" ItemStyle-HorizontalAlign="Center">
                              <ItemStyle HorizontalAlign="Center"></ItemStyle>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText=" Functie " ItemStyle-HorizontalAlign="Center">
                              <ItemStyle HorizontalAlign="Center"></ItemStyle>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText=" Rekt" ItemStyle-HorizontalAlign="Center">
                              <ItemStyle HorizontalAlign="Center"></ItemStyle>
                              </asp:TemplateField>
                          </Columns>
                         </asp:GridView>
                     </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
