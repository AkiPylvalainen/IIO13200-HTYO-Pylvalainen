<%@ Page Title="" Language="C#" MasterPageFile="~/RadioMP.master" AutoEventWireup="true" CodeFile="StationSave.aspx.cs" Inherits="StationSave"%>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Asemat
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
    Asemien lisäys
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="input" Runat="Server">

    <asp:XmlDataSource ID="srcCountries"
        DataFile="~/App_Data/Countries.xml"
        XPath="Countries/Country"
        runat="server">
    </asp:XmlDataSource>
    <asp:XmlDataSource ID="srcLocations"
        DataFile="~/App_Data/Countries.xml"
        XPath="Countries/Country/Location"
        runat="server">
    </asp:XmlDataSource>

    <table>
        <tr>
            <td><asp:Label runat="server">Aseman nimi</asp:Label></td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="NameValidator"
                    runat="server"
                    ControlToValidate="txtName"
                    ErrorMessage="Aseman nimi puuttuu"
                    ForeColor="red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Taajuus (kHz)</asp:Label></td>
            <td>
                <asp:TextBox ID="txtFreq" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="FrequencyValidator"
                    runat="server"
                    ControlToValidate="txtFreq"
                    ErrorMessage="Taajuus puuttuu"
                    ForeColor="red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Maa</asp:Label></td>
            <td><asp:DropDownList ID="ddlCountry" Class="dropdown" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Aseman paikkakunta</asp:Label></td>
            <td><asp:DropDownList ID="ddlLocation" runat="server" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="submit" Runat="Server">
    <asp:Button ID="btnCreateNew" Text="Luo uusi asema" runat="server" OnClick="btnCreateNew_Click" />
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="result" Runat="Server">
    <asp:Label ID="lblMessages" runat="server">...</asp:Label>
</asp:Content>

