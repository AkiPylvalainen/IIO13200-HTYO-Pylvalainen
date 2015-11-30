<%@ Page Title="" Language="C#" MasterPageFile="~/RadioMP.master" AutoEventWireup="true" CodeFile="StationRead.aspx.cs" Inherits="StationRead"%>

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
    Asemien haku
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
            <td><asp:Label runat="server">Taajuus (kHz)</asp:Label></td>
            <td><asp:TextBox ID="txtFreq_1" Width="50" runat="server"></asp:TextBox> -
                <asp:TextBox ID="txtFreq_2" Width="50" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="FrequencyValidator_1"
                    runat="server"
                    ControlToValidate="txtFreq_1"
                    ErrorMessage="Taajuus 1 puuttuu"
                    ForeColor="red">
                </asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator
                    ID="FrequencyValidator_2"
                    runat="server"
                    ControlToValidate="txtFreq_2"
                    ErrorMessage="Taajuus 2 puuttuu"
                    ForeColor="red">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Maa</asp:Label></td>
            <td><asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Aseman paikkakunta</asp:Label></td>
            <td><asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList></td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="submit" Runat="Server">
    <asp:Button ID="btnGetAllStations" Text="Hae kaikki asemat" runat="server" OnClick="btnGetAllStations_Click" />
    <asp:Button ID="btnGetStationsByFrequency" Text="Hae asemat valitulta taajuusväliltä" runat="server" OnClick="btnGetStationsByFrequency_Click"/>
    <asp:Button ID="btnGetStationsByCountry" Text="Hae asemat valitusta maasta" runat="server" OnClick="btnGetStationsByCountry_Click"/>
    <asp:Button ID="btnGetStationsByLocation" Text="Hae asemat valitusta paikkakunnasta" runat="server" OnClick="btnGetStationsByLocation_Click" />
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="result" Runat="Server">
    <asp:Label ID="lblMessages" runat="server">...</asp:Label>
    <asp:GridView ID="gvData" runat="server"></asp:GridView>
</asp:Content>

