<%@ Page Title="" Language="C#" MasterPageFile="~/RadioMP.master" AutoEventWireup="true" CodeFile="ReportRead.aspx.cs" Inherits="ReportRead"%>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Raportit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="theme" Runat="Server">
    <asp:Label runat="server">Vaihda ulkoasun teemaa</asp:Label>
    <asp:DropDownList ID="ddlTheme" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged">
        <asp:ListItem Value="Red">Punainen</asp:ListItem>
        <asp:ListItem Value="Green">Vihreä</asp:ListItem>
        <asp:ListItem Value="Blue">Sininen</asp:ListItem>
    </asp:DropDownList>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subTitle" Runat="Server">
    Raporttien haku
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="input" Runat="Server">
    <table>
        <tr>
            <td><asp:Label runat="server">Radiosema</asp:Label></td>
            <td><asp:DropDownList ID="ddlStation" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Päivämäärä 1</asp:Label></td>
            <td><asp:Calendar ID="cldDate_1" runat="server"></asp:Calendar></td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Päivämäärä 2</asp:Label></td>
            <td><asp:Calendar ID="cldDate_2" runat="server"></asp:Calendar></td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="submit" Runat="Server">
    <asp:Button ID="btnGetAllReports" Text="Hae kaikki Raportit" runat="server" OnClick="btnGetAllReports_Click" />
    <asp:Button ID="btnGetReportsFromStation" Text="Hae raportit valitusta asemasta" runat="server" OnClick="btnGetReportsFromStation_Click" />
    <asp:Button ID="btnGetReportsByDate" Text="Hae valitulla aikavälillä annetut raportit" runat="server" OnClick="btnGetReportsByDate_Click" />
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="result" Runat="Server">
    <asp:Label ID="lblMessages" runat="server">...</asp:Label>
    <asp:GridView ID="gvData" runat="server"></asp:GridView>
</asp:Content>

