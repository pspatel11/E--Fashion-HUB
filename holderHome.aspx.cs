using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class holderHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["HolderId"] != null && Session["HolderId"].ToString() != "")
        {
            GetplantProducts();
            GetFertilizerProduct();
        }
        else
        {
            Response.Redirect("login.aspx", false);
        }
    }


    private void GetplantProducts()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        string sb = @"select plant_Id as PlantId,(cast(plant_name as nvarchar(20))+ case when len(plant_name) > 16 then '...' else '' end )as PlantName,price,image1 ,Holder_Id
from Item_Details 
where Holder_Id = " + Session["HolderId"] +
"and Category_Id in(select distinct Category_Id from Category where Category_Type = 0 ) Order by plant_Id desc";

        SqlCommand cmd = new SqlCommand(sb, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        rptProducts.DataSource = dt;
        rptProducts.DataBind();
    }

    private void GetFertilizerProduct()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        string sb = @"select plant_Id as PlantId,(cast(plant_name as nvarchar(20))+ case when len(plant_name) > 16 then '...' else '' end )as PlantName,price,image1 ,Holder_Id
from Item_Details 
where Holder_Id = " + Session["HolderId"] +
"and Category_Id in(select distinct Category_Id from Category where Category_Type = 1 ) Order by plant_Id desc";

        SqlCommand cmd = new SqlCommand(sb, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        rptFertilizer.DataSource = dt;
        rptFertilizer.DataBind();
    }

}