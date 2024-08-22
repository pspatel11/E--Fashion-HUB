using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class city : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Role"] != null && Session["Role"].ToString() != "" && (Session["Role"].ToString() == ConstantVariable.AdminRole))
            {

                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                getData();
                getCountry();
                getState();
            }
            else
            {
                Response.Redirect("login.aspx", false);
            }
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
    public void getData()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        string query = @"select city_id,city_name,City_code,city.state_id,state_name,city.country_id, country_name from city
                            left outer join country on city.country_id = country.country_id
                            left outer join state on city.state_id = state.state_id";
        SqlCommand cmd = new SqlCommand(query, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        grdCity.DataSource = dt;
        grdCity.DataBind();
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCountry.SelectedValue != null && (ddlState.SelectedValue != null))
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
                cn.Open();
                string query = "insert into city(city_name,City_code,country_id,state_id) values('" + TextBox1.Text.Trim() + "','" + txtCityCode.Text.Trim() + "'," + ddlCountry.SelectedValue + "," + ddlState.SelectedValue + ")";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cn.Close();
                getData();
                ClearALL();
                Response.Write("<script>alert('Data is inserted.')</script>");
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
        getData();
    }
    protected void grdCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCity.PageIndex = e.NewPageIndex;
        getData();

        ClearALL();
    }
    protected void grdCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSubmit.Visible = false;
        btnUpdate.Visible = true;
        btnDelete.Visible = true;

        GridViewRow row = grdCity.SelectedRow;
        hdnCityId.Value = grdCity.SelectedDataKey.Value.ToString();

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        string s = @"select city_id,city_name,City_code,p.state_id,p.country_id from city p where city_id = " + hdnCityId.Value;
        SqlCommand cmd = new SqlCommand(s, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        if (dt != null && dt.Rows.Count > 0)
        {
            TextBox1.Text = dt.Rows[0]["city_name"].ToString();
            txtCityCode.Text = dt.Rows[0]["City_code"].ToString();
            
            ddlCountry.SelectedValue = dt.Rows[0]["country_id"].ToString();
            ddlState.SelectedValue = dt.Rows[0]["state_id"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Data not found.')</script>");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearALL();
    }

    private void ClearALL()
    {
        TextBox1.Text = "";
        txtCityCode.Text = "";
        ddlState.SelectedIndex = -1;
        ddlCountry.SelectedIndex = -1;
        lblError.Text = "";
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            string query = "update city set city_name = '" + TextBox1.Text.ToString() + "',City_code = '" + txtCityCode.Text.ToString() + "',state_id = " + ddlState.SelectedValue + ",country_id =" + ddlCountry.SelectedValue + " where city_id = " + hdnCityId.Value;
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cn.Close();
            getData();

            ClearALL();
            Response.Write("<script>alert('Successfully,Data is updated.')</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message.ToString() + "')</script>");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            string query = "delete from city where city_id = " + hdnCityId.Value;
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cn.Close();
            getData();

            ClearALL();
            Response.Write("<script>alert('Successfully,Data is deleted.')</script>");
        }
        catch (Exception ex)
        {
            ClearALL();
            Response.Write("<script>alert('" + ex.Message.ToString() + "')</script>");
        }
    }

}


