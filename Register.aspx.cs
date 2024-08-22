using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getCountry();
            getState();
            getCity();
        }
    }

    public void getCountry()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select country_id,country_name from country", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        ddlCountry.DataSource = dt;
        ddlCountry.DataTextField = "country_name";
        ddlCountry.DataValueField = "country_id";
        ddlCountry.DataBind();
        ddlCountry.Items.Insert(0, "--Select Country--");
    }

    public void getState()
    {
        if (ddlCountry.SelectedValue != null && ddlCountry.SelectedValue != "" && ddlCountry.SelectedIndex != 0)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("select state_id,state_name from state where country_id = " + ddlCountry.SelectedValue, cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cn.Close();
            ddlState.DataSource = dt;
            ddlState.DataTextField = "state_name";
            ddlState.DataValueField = "state_id";
            ddlState.DataBind();
            ddlState.Items.Insert(0, "--Select State--");
        }
        else
        {
            DataTable dt = new DataTable();
            ddlState.DataSource = dt;
            ddlState.DataBind();
            ddlState.Items.Insert(0, "--Select State--");
        }
    }

    public void getCity()
    {
        if (ddlCountry.SelectedIndex != 0 && ddlState.SelectedIndex != 0)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            string query = "select city_id,city_name from city where state_id = " + ddlState.SelectedValue + " and country_id = " + ddlCountry.SelectedValue + " order by city_name";
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cn.Close();
            ddlCity.DataSource = dt;
            ddlCity.DataTextField = "city_name";
            ddlCity.DataValueField = "city_id";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, "--Select City--");
        }
        else
        {
            DataTable dt = new DataTable();
            ddlCity.DataSource = dt;
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, "--Select City--");
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtFirstName.Text.Length == 0)
                lblError.Text = "First name is required.";
            else if (txtSurname.Text.Length == 0)
                lblError.Text = "Lastname is required.";
            else if (txtEmail.Text.Length == 0)
                lblError.Text = "Email id is required";
            else if (txtPassword.Text.Length == 0)
                lblError.Text = "Password is required";
            else if (txtConfirmPassword.Text.Length == 0)
                lblError.Text = "confirm Password is required";
            else if (ddlCountry.SelectedIndex == 0)
                lblError.Text = "Country is required";
            else if (ddlState.SelectedIndex == 0)
                lblError.Text = "state is required";
            else if (ddlCity.SelectedIndex == 0)
                lblError.Text = "city is required";
            else
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_register", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@last_name", txtSurname.Text.Trim());
                cmd.Parameters.AddWithValue("@email_id", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@mobile_no", txtMobileNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@birthday", txtBirthday.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@city_id", (ddlCity.SelectedValue == "") ? null : ddlCity.SelectedValue);
                cmd.Parameters.AddWithValue("@state_id", (ddlState.SelectedValue == "") ? null : ddlState.SelectedValue);
                cmd.Parameters.AddWithValue("@country_id", (ddlCountry.SelectedValue == "") ? null : ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@postal_code", txtPostalCode.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@role", ConstantVariable.UserRole);
                cmd.ExecuteNonQuery();
                cn.Close();
                Response.Write("<script>alert('Data is inserted.')</script>");
                ClearAll();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message.ToString() + "')</script>");
        }
    }
    
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        getState();
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCity();
    }

    private void ClearAll()
    {
        txtFirstName.Text = string.Empty;

        getCountry();
        getState();
        getCity();

    }
}