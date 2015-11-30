using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BLRadio
/// </summary>
public class BLRadio
{
    private static String _connectionString = "Server=mysql.labranet.jamk.fi;User ID=H3187;Password=MXeZprpTU0wAr52HpIv56sDgeUbT5NCw;Persist Security Info=True;Database=H3187";

    /**
     * Hakee kaikki asemat.
     * */
    public static DataTable GetStations()
    {
        return DBRadio.SelectStations(_connectionString);
    }

    /**
     * Hakee asemien tunnukset ja nimet.
     * */
    public static DataTable GetStationId()
    {
        return DBRadio.SelectStationId(_connectionString);
    }

    /**
     * Hakee asemat valitulta taajuusväliltä.
     */
    public static DataTable GetStationsByFrequency(double frequency_1, double frequency_2)
    {
        // Alkutaajuuden on oltava pienempi.
        if (frequency_1 < frequency_2)
        {
            return DBRadio.SelectStationsByFrequency(_connectionString, frequency_1, frequency_2);
        }
        else
        {
            return null;
        }
    }

    /**
     * Hakee valitun maan asemat.
     */
    public static DataTable GetStationsByCountry(String country)
    {
        return DBRadio.SelectStationsByCountry(_connectionString, country);
    }

    /**
     * Hakee valitun paikkakunnan asemat.
     */
    public static DataTable GetStationsByLocation(String country)
    {
        return DBRadio.SelectStationsByLocation(_connectionString, country);
    }

    /*
     * Hakee kaikki raportit.
     */
    public static DataTable GetReports()
    {
        return DBRadio.SelectReports(_connectionString);
    }

    /**
     * Hakee valittua asemaa koskevat raportit
     */
    public static DataTable GetReportsByStation(int stationId)
    {
        return DBRadio.SelectReportsByStation(_connectionString, stationId);
    }

    /**
     * Hakee raportit annetulta aikaväliltä.
     */
    public static DataTable GetReportsByDate(DateTime date_1, DateTime date_2)
    {
        // Alkupäivämäärän on oltava pienempi.
        if (date_1 < date_2)
        {
            return DBRadio.SelectReportsByDate(_connectionString, date_1, date_2);
        }
        else
        {
            return null;
        }
    }

    /**
     * Lisää asematietueen
     */
    public static bool AddStation(String stationName, double frequency, String country, String location)
    {
        return DBRadio.InsertStation(_connectionString, stationName, frequency, country, location);
    }

    /**
     * Lisää raporttitietueen.
     */
    public static bool AddReport(int stationId, String sinpo, DateTime date, String text)
    {
        return DBRadio.InsertReport(_connectionString, stationId, sinpo, date, text);
    } 
}