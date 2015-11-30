<%@ Page Title="" Language="C#" MasterPageFile="~/RadioMP.master" AutoEventWireup="true" CodeFile="ReportSave.aspx.cs" Inherits="ReportSave"%>

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
    Raportin lisäys
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="input" Runat="Server">
    <table>
        <tr>
            <td><asp:Label runat="server">Radiosema</asp:Label></td>
            <td><asp:DropDownList ID="ddlStation" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label runat="server">SINPO</asp:Label></td>
            <td>
                <asp:TextBox ID="txtSINPO" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="SINPO_Validator"
                    runat="server"
                    ControlToValidate="txtSINPO"
                    ErrorMessage="SINPO-koodi puuttuu"
                    ForeColor="red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Päivämäärä</asp:Label></td>
            <td><asp:Calendar ID="cldDate" runat="server"></asp:Calendar></td>
        </tr>
    </table>
    <div id="input-report">
        <br />
        <asp:Label runat="server">Anna raportti (vapaaehtoinen)</asp:Label>
        <br />
        <asp:TextBox ID="txtReport" Width="500" runat="server"></asp:TextBox>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="submit" Runat="Server">
    <asp:Button ID="btnCreateNew" Text="Luo uusi raportti" runat="server" OnClick="btnCreateNew_Click" />
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="result" Runat="Server">
    <asp:Label ID="lblMessages" runat="server">...</asp:Label>
</asp:Content>

