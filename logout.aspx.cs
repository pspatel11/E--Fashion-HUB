using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Name"] = (Session["Name"].ToString() != null) ? string.Empty : string.Empty ;
        Session["Role"] = (Session["Role"].ToString() != null) ? string.Empty : string.Empty;
        Session["UserId"] = (Session["UserId"].ToString() != null) ? string.Empty : string.Empty;
        Session["LoginId"] = (Session["LoginId"].ToString() != null) ? string.Empty : string.Empty;
        Response.Redirect("login.aspx", false);
    }
}