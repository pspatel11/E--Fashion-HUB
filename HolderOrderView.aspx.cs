using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class HolderOrderView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["HolderId"] != null && Session["HolderId"].ToString() != "")
        {
            if (!IsPostBack)
            {
                int regId = Convert.ToInt32(Session["HolderId"].ToString());
                GetUserOrderDetails(regId);
            }
        }
        else
        {
            Response.Redirect("login.aspx", false);
        }
    }
    private void GetUserOrderDetails(int holderId)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();

        string query = "EXEC sp_get_orders_by_holder @holderId = " + holderId;

        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        grdOrder.DataSource = dt;
        grdOrder.DataBind();
    }    
}