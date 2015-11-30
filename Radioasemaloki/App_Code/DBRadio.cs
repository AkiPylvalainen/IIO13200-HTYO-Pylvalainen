using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for DBRadio
/// </summary>
public class DBRadio
{
    /**
     * Hakee kaikki asemat.
     * */
    public static DataTable SelectStations(String connectionString)
    {
        if (connectionString == null)
        {
            return null;
        }

        DataTable dt = null;

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select StationName, Frequency, Country, Location from Station";

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }
        }
        catch (Exception ex) { }

        return dt;
    }

    /**
     * Hakee asemien tunnukset ja nimet.
     * */
    public static DataTable SelectStationId(String connectionString)
    {
        if (connectionString == null)
        {
            return null;
        }

        DataTable dt = null;

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select StationId, StationName from Station";

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }
        }
        catch (Exception ex) { }

        return dt;
    }

    /**
     * Hakee asemat valitulta taajuusväliltä.
     */
    public static DataTable SelectStationsByFrequency(String connectionString, double frequency_1, double frequency_2)
    {
        if (connectionString == null)
        {
            return null;
        }

        if (frequency_1 >= frequency_2)
        {
            return null;
        }

        DataTable dt = null;

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select StationName, Frequency, Country, Location from Station where Frequency >= @1 and Frequency <= @2";

                cmd.Parameters.AddWithValue("@1", frequency_1);
                cmd.Parameters.AddWithValue("@2", frequency_2);

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }
        }
        catch (Exception ex) { }

        return dt;
    }

    /**
     * Hakee valitun maan asemat.
     */
    public static DataTable SelectStationsByCountry(String connectionString, String country)
    {
        if (connectionString == null)
        {
            return null;
        }

        if (country == null)
        {
            return null;
        }
        if (country.Length <= 0 || country.Length > 50)
        {
            return null;
        }

        DataTable dt = null;

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select StationName, Frequency, Country, Location from Station where Country=@1";

                cmd.Parameters.AddWithValue("@1", country);

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }
        }
        catch (Exception ex) { }

        return dt;
    }

    /**
     * Hakee valitun paikkakunnan asemat.
     */
    public static DataTable SelectStationsByLocation(String connectionString, String location)
    {
        if (connectionString == null)
        {
            return null;
        }

        if (location == null)
        {
            return null;
        }
        if (location.Length <= 0 || location.Length > 50)
        {
            return null;
        }

        DataTable dt = null;

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select StationName, Frequency, Country, Location from Station where Location=@1";

                cmd.Parameters.AddWithValue("@1", location);

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }
        }
        catch (Exception ex) { }

        return dt;
    }

    /**
     * Hakee kaikki raportit.
     */
    public static DataTable SelectReports(String connectionString)
    {
        if (connectionString == null)
        {
            return null;
        }

        DataTable dt = null;

        String sqlCmd = String.Format("select Station.StationName, Report.SINPO, Report.ReportDate, Report.ReportText from Report inner join Station on Report.StationId = Station.StationId");

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlCmd;

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }
        }
        catch (Exception ex) { }

        return dt;
    }

    /**
     * Hakee valittua asemaa koskevat raportit
     */
    public static DataTable SelectReportsByStation(String connectionString, int stationId)
    {
        if (connectionString == null)
        {
            return null;
        }

        DataTable dt = null;

        String sqlCmd = String.Format("select Station.StationName, Report.SINPO, Report.ReportDate, Report.ReportText from Report inner join Station on Report.StationId = Station.StationId where Station.StationId = {0}", stationId);

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlCmd;

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }
        }
        catch (Exception ex) {}

        return dt;
    }

    /**
     * Hakee raportit annetulta aikaväliltä.
     */
    public static DataTable SelectReportsByDate(String connectionString, DateTime date_1, DateTime date_2)
    {
        if (connectionString == null)
        {
            return null;
        }

        if (date_1 == null || date_2 == null)
        {
            return null;
        }
        if (date_1 >= date_2)
        {
            return null;
        }

        DataTable dt = null;

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Station.StationName, Report.SINPO, Report.ReportDate, Report.ReportText from Report inner join Station on Report.StationId = Station.StationId where Report.ReportDate >= @1 and Report.ReportDate <= @2";

                cmd.Parameters.AddWithValue("@1", date_1);
                cmd.Parameters.AddWithValue("@2", date_2);

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adapter.Fill(dt);
                }

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }
        }
        catch (Exception ex) { }

        return dt;
    }

    /**
     * Lisää asematietueen
     */
    public static bool InsertStation(String connectionString, String stationName, double frequency, String country, String location)
    {
        if (connectionString == null)
        {
            return false;
        }

        if (stationName == null || country == null || location == null)
        {
            return false;
        }

        if ((stationName.Length <= 0 || stationName.Length > 50) ||
            (country.Length <= 0 || country.Length > 50) ||
            (location.Length <= 0 || location.Length > 50))
        {
            return false;
        }

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Station (StationName, Frequency, Country, Location) values (@1, @2, @3, @4)";

                cmd.Parameters.AddWithValue("@1", stationName);
                cmd.Parameters.AddWithValue("@2", frequency);
                cmd.Parameters.AddWithValue("@3", country);
                cmd.Parameters.AddWithValue("@4", location);

                conn.Open();
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    /**
     * Lisää raporttitietueen.
     */
    public static bool InsertReport(String connectionString, int stationId, String sinpo, DateTime date, String text)
    {
        if (connectionString == null)
        {
            return false;
        }

        if (sinpo == null || date == null)
        {
            return false;
        }

        if (sinpo.Length <= 0 || sinpo.Length > 80)
        {
            return false;
        }

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Report (StationId, SINPO, ReportDate, ReportText) values (@1, @2, @3, @4)";

                cmd.Parameters.AddWithValue("@1", stationId);
                cmd.Parameters.AddWithValue("@2", sinpo);
                cmd.Parameters.AddWithValue("@3", date);
                cmd.Parameters.AddWithValue("@4", text);

                conn.Open();
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                cmd = null;
                conn.Close();
            }

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}