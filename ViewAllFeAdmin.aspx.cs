using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewAllFertilizerAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getCategory();
        }
    }
    public void getCategory()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select Category_Id,category_name from Category  where category_type = 1", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        ddlCategory.DataSource = dt;
        ddlCategory.DataTextField = "category_name";
        ddlCategory.DataValueField = "Category_Id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, "--Select Category--");
    }
    private void GetProducts(int categoryId)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select plant_Id as PlantId,(cast(plant_name as nvarchar(10))+ case when len(plant_name) > 16 then '...' else '' end )as PlantName,price,image1 from Item_Details where category_id in(" + categoryId + ") Order by plant_Id desc", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        rptProducts.DataSource = dt;
        rptProducts.DataBind();
    }


    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedIndex != 0)
        {
            GetProducts(Convert.ToInt32(ddlCategory.SelectedValue));
        }
        else
        {
            DataTable dt = new DataTable();
            rptProducts.DataSource = dt;
            rptProducts.DataBind();
        }
    }
}