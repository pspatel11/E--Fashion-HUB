using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class Country : System.Web.UI.Page
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
            }
            else
            {
                Response.Redirect("login.aspx", false);
            }
        }
    }

    public void getData()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select country_id,country_name,country_code from country", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        grdCountry.DataSource = dt;
        grdCountry.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            string query = "insert into country(country_name,country_code) values('" + txtName.Text.Trim() + "','" + txtCountryCode.Text.Trim() + "')";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cn.Close();
            getData();

            ClearALL();
            Response.Write("<script>alert('Data is inserted.')</script>");

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message.ToString() + "')</script>");
        }
    }

    protected void grdCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCountry.PageIndex = e.NewPageIndex;
        getData();
        ClearALL();
    }

    protected void grdCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSave.Visible = false;
        btnUpdate.Visible = true;
        btnDelete.Visible = true;

        GridViewRow row = grdCountry.SelectedRow;
        hdnCountryId.Value = grdCountry.SelectedDataKey.Value.ToString();

        txtName.Text = row.Cells[2].Text.ToString();
        txtCountryCode.Text = row.Cells[3].Text.ToString();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearALL();
    }

    private void ClearALL()
    {
        txtName.Text = "";
        txtCountryCode.Text = "";
        lblError.Text = "";
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            string query = "update country set country_name = '" + txtName.Text.ToString() + "',country_code = '" + txtCountryCode.Text.ToString() + "' where country_id = " + hdnCountryId.Value;
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
            string query = "delete from country where country_id = " + hdnCountryId.Value;
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
            Response.Write("<script>alert('It is used at another data.')</script>");
        }
    }
}