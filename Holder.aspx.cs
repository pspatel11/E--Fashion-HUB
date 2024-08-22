using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Holder : System.Web.UI.Page
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
                throw new Exception("name is required.");
            else if (txtWebsite.Text.Length == 0)
                throw new Exception("Website email is required.");
            else if (txtPersonName.Text.Length == 0)
                throw new Exception("Contact person Name is required");
            else if (txtPassword.Text.Length == 0)
                throw new Exception("Password is required");
            else if (txtConfirmPassword.Text.Length == 0)
                throw new Exception("Confirm Password is required");
            else if (txtContactNo.Text.Length == 0)
                throw new Exception("Contact person No is required");
            else if (txtServiceEmailId.Text.Length == 0)
                throw new Exception("service emailId is required");
            else if (ddlCountry.SelectedIndex == 0)
                throw new Exception("Country is required");
            else if (ddlState.SelectedIndex == 0)
                throw new Exception("state is required");
            else if (ddlCity.SelectedIndex == 0)
                throw new Exception("city is required");
            else
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_HolderRegistration", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());               
                cmd.Parameters.AddWithValue("@Country_Id", (ddlCountry.SelectedValue == "") ? null : ddlCountry.SelectedValue);                
                cmd.Parameters.AddWithValue("@State_Id", (ddlState.SelectedValue == "") ? null : ddlState.SelectedValue);
                cmd.Parameters.AddWithValue("@City_Id", (ddlCity.SelectedValue == "") ? null : ddlCity.SelectedValue);
                cmd.Parameters.AddWithValue("@postal_code", txtPostalCode.Text.Trim());
                cmd.Parameters.AddWithValue("@Office_No", texOfficeNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Extention_No", txtExtentionNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Fax_No", txtFaxNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                cmd.Parameters.AddWithValue("@Contact_Name", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactPerson_MobileNo", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@ServiceEmail_Id", txtServiceEmailId.Text.Trim());
                cmd.Parameters.AddWithValue("@InfoEmail_Id", txtInformation.Text.Trim());
                cmd.Parameters.AddWithValue("@Short_Info", txtShortInfo.Text.Trim());               
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@Is_Active", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Location", txtlocation.Text.Trim());
                cmd.Parameters.AddWithValue("@role", ConstantVariable.HolderRole);
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

        txtFirstName.Text = "";
        txtPersonName.Text = "";
        txtContactNo.Text = "";
        txtShortInfo.Text = "";
        txtAddress.Text = "";
        txtWebsite.Text = "";
        txtServiceEmailId.Text = "";
        txtInformation.Text = "";
        texOfficeNo.Text = "";
        txtExtentionNo.Text = "";
        txtFaxNo.Text = "";
        txtPostalCode.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        txtlocation.Text = "";
        ddlState.SelectedIndex = -1;
        ddlCountry.SelectedIndex = -1;
        ddlCity.SelectedIndex = -1;




        getCountry();
        getState();
        getCity();

    }
}