<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="title" Runat="Server">
    Etusivu
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="theme" Runat="Server">
    <asp:Label runat="server">Vaihda ulkoasun teemaa</asp:Label>
    <asp:DropDownList ID="ddlTheme" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged">
        <asp:ListItem Value="Red">Punainen</asp:ListItem>
        <asp:ListItem Value="Green">Vihreä</asp:ListItem>
        <asp:ListItem Value="Blue">Sininen</asp:ListItem>
    </asp:DropDownList>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="subTitle" Runat="Server">
    Sivuston tiedot
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="main" Runat="Server">
    <div class="article">
    </div>
</asp:Content>


