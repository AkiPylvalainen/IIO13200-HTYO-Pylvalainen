using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
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
    }

    protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        theme = ddlTheme.SelectedValue;
        
        Server.Transfer("~/Index.aspx?Theme="+theme);
    }

}