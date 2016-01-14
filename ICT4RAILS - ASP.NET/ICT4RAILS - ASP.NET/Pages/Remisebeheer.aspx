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
                        <asp:DropDownList ID="ddlTrams" CssClass="form-control" ValidationGroup="1" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlTrams" InitialValue="0" ForeColor="Red" ValidationGroup="1" runat="server" ErrorMessage="" />
                    </div>
                    <div class="form-group">
                        <label>Tram Bewerking:</label>
                        <asp:DropDownList ID="ddlTrambeheerBewerking" CssClass="form-control" ValidationGroup="1" runat="server">
                            <asp:ListItem Text="--Kies Bewerking--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dienst" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Remise" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="0" ControlToValidate="ddlTrambeheerBewerking" ForeColor="Red" ValidationGroup="1" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Vervuild</label>
                        <asp:CheckBox ID="cbVervuild" runat="server" />
                    </div>
                    <div class="form-group">
                        <label>Defect</label>
                        <asp:CheckBox ID="cbDefect" runat="server" />
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
                        <label>Spoor Bewerking:</label>
                        <asp:DropDownList ID="ddlSpoorbeheerBewerking" CssClass="form-control" ValidationGroup="2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSpoorbeheerBewerking_SelectedIndexChanged">
                            <asp:ListItem Text="--Kies Bewerking--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Blokkeren" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Reserveren" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Deblokkeren" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlSpoorbeheerBewerking" ForeColor="Red" InitialValue="0" ValidationGroup="2" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Spoor:</label>
                        <asp:DropDownList ID="ddlSporen" CssClass="form-control" ValidationGroup="2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSporen_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" ControlToValidate="ddlSporen" ForeColor="Red" ValidationGroup="2" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Sector:</label>
                        <asp:DropDownList ID="ddlSectoren" CssClass="form-control" ValidationGroup="2" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" ControlToValidate="ddlSectoren" ForeColor="Red" ValidationGroup="2" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Tramnummer:</label>
                        <asp:DropDownList ID="ddlSpoorTrams" CssClass="form-control" ValidationGroup="2" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" InitialValue="0" ControlToValidate="ddlSpoorTrams" ForeColor="Red" ValidationGroup="2" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="spoorbeheerbevestig" CssClass="btn btn-default" ValidationGroup="2" runat="server" Text="Bevestig" OnClick="spoorbeheerbevestig_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
