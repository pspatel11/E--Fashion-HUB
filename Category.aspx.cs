using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class Category : System.Web.UI.Page
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
        SqlCommand cmd = new SqlCommand("select Category_Id,category_name,Category_description, case when Category_Type = 0 then 'Gents' when Category_Type = 1 then 'Female' when Category_Type is null then 'Gents' end as Category_TypeName,isnull(Category_Type,0) as Category_Type from Category", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        grdCategory.DataSource = dt;
        grdCategory.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategoryType.SelectedValue != null && ddlCategoryType.SelectedValue != "")
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
                cn.Open();
                string query = "insert into Category(category_name,Category_description,Category_Type) values('" + txtName.Text.Trim() + "','" + txtDescription.Text.Trim() + "'," + ddlCategoryType.SelectedValue + ")";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cn.Close();
                getData();

                ClearALL();
                Response.Write("<script>alert('Data is inserted.')</script>");
            }
            else
            {
                throw new Exception("Please, select Caegory Type.");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message.ToString() + "')</script>");
        }
    }

    protected void grdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCategory.PageIndex = e.NewPageIndex;
        getData();
        ClearALL();
    }

    protected void grdCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSubmit.Visible = false;
        btnUpdate.Visible = true;
        btnDelete.Visible = true;

        GridViewRow row = grdCategory.SelectedRow;
        hdnCategoryId.Value = grdCategory.SelectedDataKey.Value.ToString();


        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select Category_Id,category_name,Category_description, case when Category_Type = 0 then 'Plant' when Category_Type = 1 then 'Fertilizer' when Category_Type is null then 'Plant' end as Category_TypeName,isnull(Category_Type,0) as Category_Type from Category where Category_Id = " + hdnCategoryId.Value, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        grdCategory.DataSource = dt;
        grdCategory.DataBind();
        if (dt.Rows != null && dt.Rows.Count > 0)
        {
            txtName.Text = dt.Rows[0]["category_name"].ToString();
            ddlCategoryType.SelectedValue = dt.Rows[0]["Category_Type"].ToString();
            txtDescription.Text = dt.Rows[0]["Category_description"].ToString();
        }
        getData();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearALL();
    }

    private void ClearALL()
    {
        txtName.Text = "";
        txtDescription.Text = "";
        ddlCategoryType.SelectedValue = "-1";
        lblError.Text = "";
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategoryType.SelectedValue != null && ddlCategoryType.SelectedValue != "")
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
                cn.Open();
                string query = "update Category set category_name = '" + txtName.Text.ToString() + "',Category_description = '" + txtDescription.Text.ToString() + "',Category_Type =" + ddlCategoryType.SelectedValue + " where Category_Id = " + hdnCategoryId.Value;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cn.Close();
                getData();

                ClearALL();
                Response.Write("<script>alert('Successfully,Data is updated.')</script>");
            }
            else
            {
                throw new Exception("Please, select Caegory Type.");
            }
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
            string query = "delete from Category where Category_Id = " + hdnCategoryId.Value;
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
