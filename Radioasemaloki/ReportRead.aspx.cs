using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportRead : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            FillControls();
        }
    }

    /**
     * Täyttää komponentit oletusarvoilla.
     */
    protected void FillControls()
    {
        ddlStation.DataSource = BLRadio.GetStationId();
        ddlStation.DataTextField = "StationName";
        ddlStation.DataValueField = "StationId";
        ddlStation.DataBind();
    }

    protected void btnGetAllReports_Click(object sender, EventArgs e)
    {
        gvData.DataSource = BLRadio.GetReports();
        gvData.DataBind();
    }

    protected void btnGetReportsFromStation_Click(object sender, EventArgs e)
    {
        if (!IsSelected(ddlStation))
        {
            return;
        }

        int id = Int32.Parse(ddlStation.SelectedValue);

        gvData.DataSource = BLRadio.GetReportsByStation(id);
        gvData.DataBind();
    }

    protected void btnGetReportsByDate_Click(object sender, EventArgs e)
    {
        DateTime date_1 = cldDate_1.SelectedDate;
        DateTime date_2 = cldDate_2.SelectedDate;

        gvData.DataSource = BLRadio.GetReportsByDate(date_1, date_2);
        gvData.DataBind();
    }

    protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        theme = ddlTheme.SelectedValue;

        Server.Transfer("~/ReportRead.aspx?Theme=" + theme);
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