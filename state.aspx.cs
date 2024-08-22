using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;


public partial class STATE : System.Web.UI.Page
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

    public void getData()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        string s = @"select state_id,state_name,p.country_id,c.country_name as country_name,state_code 
                        from state p
                        left outer join country c on p.country_id = c.country_id";
        SqlCommand cmd = new SqlCommand(s, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        grdState.DataSource = dt;
        grdState.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCountry.SelectedValue != null)
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
                cn.Open();
                string query = "insert into State(State_name,country_id,state_code) values('"+ txtStateName.Text.Trim() +"',"+ ddlCountry.SelectedValue +",'"+ txtStateCode.Text.Trim() +"')";
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

    protected void grdState_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdState.PageIndex = e.NewPageIndex;
        getData();

        ClearALL();
    }

    protected void grdState_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSave.Visible = false;
        btnUpdate.Visible = true;
        btnDelete.Visible = true;

        GridViewRow row = grdState.SelectedRow;
        hdnStateId.Value = grdState.SelectedDataKey.Value.ToString();

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        string s = @"select state_id,state_name,p.country_id,state_code from state p where state_id = " + hdnStateId.Value;
        SqlCommand cmd = new SqlCommand(s, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        if (dt != null && dt.Rows.Count > 0)
        {
            txtStateName.Text = dt.Rows[0]["state_name"].ToString();
            txtStateCode.Text = dt.Rows[0]["state_code"].ToString();
            ddlCountry.SelectedValue = dt.Rows[0]["country_id"].ToString();
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
        txtStateName.Text = "";
        txtStateCode.Text = "";
        ddlCountry.SelectedIndex = -1;
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
            string query = "update state set state_name = '"+ txtStateName.Text.ToString() +"',state_code = '"+ txtStateCode.Text.ToString() +"', country_id = "+ ddlCountry.SelectedValue +" where state_id = " + hdnStateId.Value;
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
            string query = "delete from state where state_id = " + hdnStateId.Value;
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