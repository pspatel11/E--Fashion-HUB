using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null && Session["UserId"].ToString() != "")
        {
            lblName.Text = (Session["Name"].ToString() == null) ? "" : Session["Name"].ToString();
        }
        else
        {
            Response.Redirect("login.aspx", false);
        }

    }
}
