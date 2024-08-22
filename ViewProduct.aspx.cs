using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string categoryId = Request.QueryString["categotyId"].ToString();
            if (categoryId != null || categoryId != "")
            {
                GetCategoryName(Convert.ToInt32(categoryId));
            }
            else
                Response.Redirect("index.aspx", false);

        }
    }
    
    private void GetCategoryName(int categoryId)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select Category_Id as CategoryId,category_name as CategoryName from Category where Category_Id =" + categoryId, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        if (dt != null && dt.Rows.Count > 0)
        {
            lblCategoryName.Text = dt.Rows[0]["CategoryName"].ToString();
            GetProducts(categoryId);
        }
    }
    private void GetProducts(int categoryId)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select plant_Id as PlantId,(cast(plant_name as nvarchar(20))+ case when len(plant_name) > 16 then '...' else '' end )as PlantName,price,image1 from Item_Details where Category_Id = " + categoryId+ " order by plant_Id desc", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        rptProducts.DataSource = dt;
        rptProducts.DataBind();
    }
}