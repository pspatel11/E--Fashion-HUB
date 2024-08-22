using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null && Session["UserId"].ToString() != "")
        {
            if (!IsPostBack)
            {
                int regId = Convert.ToInt32(Session["UserId"].ToString());
                GetUserOrderDetails(regId, "");
            }
        }
        else
        {
            Response.Redirect("login.aspx", false);
        }
    }
    private void GetUserOrderDetails(int regId, string orderNo)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        string query = "";
        if (orderNo != null && orderNo != "")
            query = "EXEC sp_get_user_order_detail @reg_id = " + regId + ",@orderno=" + orderNo;
        else
            query = "EXEC sp_get_user_order_detail @reg_id = " + regId;

        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        grdOrder.DataSource = dt;
        grdOrder.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null && Session["UserId"].ToString() != "")
        {
            int regId = Convert.ToInt32(Session["UserId"].ToString());
            GetUserOrderDetails(regId, txtSearch.Text.Trim());
        }
        else
        {
            Response.Redirect("login.aspx", false);
        }
    }
}