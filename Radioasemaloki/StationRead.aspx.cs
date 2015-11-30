using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql.Web;
using System.Configuration;
using System.Data;

public partial class StationRead : System.Web.UI.Page
{
    public String theme;

    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Teeman vaihto ei toimi kunnolla.

        if (Request.QueryString["Theme"] != null)
        {
            theme = Request.QueryString["Theme"].ToString();

            if (theme == "Red")
            {
                Page.Theme = "Red";
            }
            else if (theme == "Green")
            {
                Page.Theme = "Green";
            }
            else if (theme == "Blue")
            {
                Page.Theme = "Blue";
            }
            else
            {
                Page.Theme = "Red";
            }
        }
        else
        {
            Page.Theme = "Red";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack) {
            FillControls();
        }

        FrequencyValidator_1.Enabled = false;
        FrequencyValidator_2.Enabled = false;
    }

    /**
     * Täyttää komponentit oletusarvoilla.
     */
    protected void FillControls()
    {
        ddlCountry.DataSource = srcCountries;
        ddlCountry.DataTextField = "name";
        ddlCountry.DataValueField = "name";
        ddlCountry.DataBind();

        ddlLocation.DataSource = srcLocations;
        ddlLocation.DataTextField = "name";
        ddlCountry.DataValueField = "name";
        ddlLocation.DataBind();
    }

    protected void btnGetAllStations_Click(object sender, EventArgs e)
    {
        gvData.DataSource = BLRadio.GetStations();
        gvData.DataBind();
    }

    protected void btnGetStationsByFrequency_Click(object sender, EventArgs e)
    {
        if (!IsDouble(txtFreq_1.Text, txtFreq_1))
        {
            return;
        }
        if (!IsDouble(txtFreq_2.Text, txtFreq_2))
        {
            return;
        }

        double frequency_1 = Double.Parse(txtFreq_1.Text);
        double frequency_2 = Double.Parse(txtFreq_2.Text);

        gvData.DataSource = BLRadio.GetStationsByFrequency(frequency_1, frequency_2);
        gvData.DataBind();
    }

    protected void btnGetStationsByCountry_Click(object sender, EventArgs e)
    {
        if (!IsSelected(ddlCountry))
        {
            return;
        }
        
        gvData.DataSource = BLRadio.GetStationsByCountry(ddlCountry.SelectedValue.ToString());
        gvData.DataBind();
    }

    protected void btnGetStationsByLocation_Click(object sender, EventArgs e)
    {
        if (!IsSelected(ddlLocation))
        {
            return;
        }

        gvData.DataSource = BLRadio.GetStationsByLocation(ddlLocation.SelectedValue.ToString());
        gvData.DataBind();
    }

    protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        theme = ddlTheme.SelectedValue;

        Server.Transfer("~/StationRead.aspx?Theme=" + theme);
    }

    /**
     * Tarkistaa, että pudotusvalikon alkio on valittu.
     */
    protected Boolean IsSelected(DropDownList sender)
    {
        if (sender == null)
        {
            return false;
        }

        if (sender.SelectedIndex >= 0 && sender.SelectedIndex < sender.Items.Count)
        {
            return true;
        }
        else
        {
            sender.Focus();
            return false;
        }
    }

    /**
     * Tarkistaa, onko syöte kokonaisluku ja olemassa.
     */
    protected Boolean IsInteger(String input, TextBox sender)
    {
        if (sender == null)
        {
            return false;
        }

        if (input == null)
        {
            sender.Focus();
            return false;
        }

        int number = 0;
        if (input.Length > 0 && Int32.TryParse(input, out number))
        {
            return true;
        }
        else
        {
            sender.Focus();
            return false;
        }
    }

    /**
     * Tarkistaa, onko syöte desimaalisluku ja olemassa.
     */
    protected Boolean IsDouble(String input, TextBox sender)
    {
        if (sender == null)
        {
            return false;
        }

        if (input == null)
        {
            sender.Focus();
            return false;
        }

        double number = 0;
        if (input.Length > 0 && Double.TryParse(input, out number))
        {
            return true;
        }
        else
        {
            sender.Focus();
            return false;
        }
    }

    /**
     * Tarkistaa, että tekstisyöte on annettu.
     */
    protected Boolean IsNotEmpty(String input, TextBox sender)
    {
        if (sender == null)
        {
            return false;
        }

        if (input == null)
        {
            sender.Focus();
            return false;
        }

        if (input.Length > 0)
        {
            return true;
        }
        else
        {
            sender.Focus();
            return false;
        }
    }
}