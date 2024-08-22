using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["HolderId"] != null && Session["HolderId"].ToString() != "")
        {
            lblName.Text = (Session["HolderName"].ToString() == null) ? "" : Session["HolderName"].ToString();
        }
        else
        {
            Response.Redirect("login.aspx", false);
        }
    }
}
