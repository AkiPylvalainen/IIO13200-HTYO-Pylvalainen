using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportSave : System.Web.UI.Page
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

    protected void btnCreateNew_Click(object sender, EventArgs e)
    {
        if (!IsSelected(ddlStation))
        {
            return;
        }
        if (!IsNotEmpty(txtSINPO.Text, txtSINPO))
        {
            return;
        }

        int stationId = Int32.Parse(ddlStation.SelectedValue);
        String sinpo = txtSINPO.Text.ToString();
        DateTime date = cldDate.SelectedDate;
        String text = txtReport.Text.ToString();

        if (sinpo.Length > 80)
        {
            return;
        }

        if (BLRadio.AddReport(stationId, sinpo, date, text))
        {
            lblMessages.Text = "Raportin lisäys onnistui.";

            txtSINPO.Text = String.Empty;
        }
    }

    protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        theme = ddlTheme.SelectedValue;

        Server.Transfer("~/ReportSave.aspx?Theme=" + theme);
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