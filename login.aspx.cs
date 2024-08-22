using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.ToString() != "")
            {
                if (Request.QueryString["type"].ToString() != null && Request.QueryString["id"].ToString() != null)
                {
                    hdnPlantId.Value = Request.QueryString["Id"].ToString();
                    hdnType.Value = Request.QueryString["type"].ToString();
                }
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (txtUserName.Text.Length == 0)
            lblError.Text = "User name should not blank.";
        else if (txtPassword.Text.Length == 0)
            lblError.Text = "Password should not blank.";
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_login", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
            txtPassword.Attributes.Add("autocomplete", "off");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cn.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                string role = dt.Rows[0]["role"].ToString();
                string loginId = dt.Rows[0]["login_id"].ToString();
                string userId = dt.Rows[0]["registration_id"].ToString();
                string name = dt.Rows[0]["Name"].ToString();
                string holderId = dt.Rows[0]["Holder_id"].ToString();
                string holderName = dt.Rows[0]["HolderName"].ToString();
                string holderEmailId = dt.Rows[0]["ServiceEmail_Id"].ToString();

                Session["Name"] = name;
                Session["Role"] = role;
                Session["UserId"] = userId;
                Session["LoginId"] = loginId;
                Session["HolderId"] = holderId;
                Session["HolderName"] = holderName;
                Session["HolderEmailId"] = holderEmailId;

                if (role == ConstantVariable.AdminRole)
                {
                    Response.Redirect("Country.aspx", false);
                }

                else if (role == ConstantVariable.UserRole)
                {
                    if (hdnType != null)
                    {
                        if (hdnType.Value == "order")
                            Response.Redirect("PlaceOrder.aspx?id=" + hdnPlantId.Value, false);
                        else
                            Response.Redirect("ViewAllPlUser.aspx", false);
                    }
                    else
                        Response.Redirect("ViewAllPlUser.aspx", false);
                }
                else if (role == ConstantVariable.HolderRole)
                {
                    Response.Redirect("holderHome.aspx", false);
                }
            }
            else
            {
                lblError.Text = "Username and passowrd is incorrect.";
            }
        }
    }
    
    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {

    }
}