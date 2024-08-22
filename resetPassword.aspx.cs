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
            SavePassDiv.Visible = false;
            newPassDiv.Visible = false;
            newPassConfirmDiv.Visible = false;
        }
    }

    protected void btnValidateUser_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUserName.Text.Length == 0)
                throw new Exception("User name should not blank.");
            else
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select top 1 login_id from login where user_name = '" + txtUserName.Text.Trim() + "'", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cn.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["login_id"].ToString() != null || dt.Rows[0]["login_id"].ToString() != "")
                    {
                        hdnLoginId.Value = dt.Rows[0]["login_id"].ToString();

                        UserNameDiv.Visible = false;
                        newPassDiv.Visible = true;
                        newPassConfirmDiv.Visible = true;
                        SavePassDiv.Visible = true;
                        validateButtonDiv.Visible = false;
                        txtUserName.Text = "";
                        txtNewPassword.Text = "";
                        txtConfirmNewPassword.Text = "";
                    }
                    else
                        throw new Exception("user is not found");
                }
                else
                    throw new Exception("user is not found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message.ToString() + "')</script>");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //update login set password = '' where login_id =
            if (txtNewPassword.Text == null || txtNewPassword.Text == "")
            {
                throw new Exception("New password is required.");
            }
            if (txtConfirmNewPassword.Text == null || txtConfirmNewPassword.Text == "")
            {
                throw new Exception("Confirm new password is required.");
            }
            if (hdnLoginId.Value == null || hdnLoginId.Value == "")
            {
                throw new Exception("user is not found");
            }
            if (txtNewPassword.Text == txtConfirmNewPassword.Text)
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
                cn.Open();
                string query = "update login set password = convert(varbinary(50),'"+txtNewPassword.Text.Trim()+"') where login_id = " + hdnLoginId.Value;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cn.Close();

                hdnLoginId.Value = null;
                UserNameDiv.Visible = true;
                newPassDiv.Visible = false;
                newPassConfirmDiv.Visible = false;
                SavePassDiv.Visible = false;
                validateButtonDiv.Visible = true;
                txtUserName.Text = "";
                txtNewPassword.Text = "";
                txtConfirmNewPassword.Text = "";

                Response.Write("<script>alert('Successfully,Password is reset.Try login with new password.')</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message.ToString() + "')</script>");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        hdnLoginId.Value = null;
        UserNameDiv.Visible = true;
        newPassDiv.Visible = false;
        newPassConfirmDiv.Visible = false;
        SavePassDiv.Visible = false;
        validateButtonDiv.Visible = true;
        txtUserName.Text = "";
        txtNewPassword.Text = "";
        txtConfirmNewPassword.Text = "";

    }
    /*
     *     //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    lblError.Text = "";
    //    if (txtUserName.Text.Length == 0)
    //        lblError.Text = "User name should not blank.";          
    //    else if (txtPassword.Text.Length == 0)
    //        lblError.Text = "Password should not blank.";
    //    else
    //    {
    //        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
    //        cn.Open();
    //        SqlCommand cmd = new SqlCommand("sp_login", cn);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
    //        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
    //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        sda.Fill(dt);
    //        cn.Close();
    //        if(dt != null && dt.Rows.Count > 0)
    //        {
    //            string role = dt.Rows[0]["role"].ToString();
    //            string loginId = dt.Rows[0]["login_id"].ToString();
    //            string userId = dt.Rows[0]["registration_id"].ToString();
    //            string name = dt.Rows[0]["Name"].ToString();
    //            string holderId = dt.Rows[0]["Holder_id"].ToString();
    //            string holderName = dt.Rows[0]["HolderName"].ToString();
    //            string holderEmailId = dt.Rows[0]["ServiceEmail_Id"].ToString();

    //            Session["Name"] = name;
    //            Session["Role"] = role;
    //            Session["UserId"] = userId;
    //            Session["LoginId"] = loginId;
    //            Session["HolderId"] = holderId;
    //            Session["HolderName"] = holderName;
    //            Session["HolderEmailId"] = holderEmailId;

    //            if (role == ConstantVariable.AdminRole)
    //                Response.Redirect("Country.aspx", false);
    //            else if(role == ConstantVariable.UserRole)
    //                Response.Redirect("feedback.aspx", false);
    //        }
    //        else
    //        {
    //            lblError.Text = "Username and passowrd is incorrect.";
    //        }
    //    }
        
    //}
     */
}