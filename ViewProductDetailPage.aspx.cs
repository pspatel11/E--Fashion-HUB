using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewProductDetailPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string productId = Request.QueryString["productId"].ToString();
            if (productId != null || productId != "")
            {
                GetProductNameDetails(Convert.ToInt32(productId));
                GetAllCategory();
            }
            else
                Response.Redirect("index.aspx", false);

        }
    }

    private void GetProductNameDetails(int productId)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select plant_Id as PlantId,plant_name as PlantName,Description,care_info,plantation_info,price,image1,image2,Category_Id,Holder_Id from Item_Details where plant_Id =" + productId, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        if (dt != null && dt.Rows.Count > 0)
        {
            lblProductName.Text = dt.Rows[0]["PlantName"].ToString();
            lblPrice.Text = dt.Rows[0]["price"].ToString();
            images1.ImageUrl = dt.Rows[0]["image1"].ToString();
            images2.ImageUrl = dt.Rows[0]["image2"].ToString();
            lblDescription.InnerText = dt.Rows[0]["Description"].ToString();
            lblCareInfo.Text = dt.Rows[0]["care_info"].ToString();
            lblPlantationInfo.Text = dt.Rows[0]["plantation_info"].ToString();
            hdnProductId.Value = dt.Rows[0]["PlantId"].ToString();
            int categoryId = Convert.ToInt32(dt.Rows[0]["Category_Id"].ToString());
            GetCategotyWiseRelatedProduct(categoryId);
            int holderId = Convert.ToInt32(dt.Rows[0]["Holder_Id"].ToString());
            GetHolderDetails(holderId);
        }
    }


    private void GetHolderDetails(int holderId)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("get_HolderDetails_By_Id", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@holderId", holderId);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        if (dt != null && dt.Rows.Count > 0)
        {
            lblHDName.Text = (dt.Rows[0]["Name"].ToString() != null) ? "Name : " + dt.Rows[0]["Name"].ToString() : null;
            lblHDShortInfo.Text = (dt.Rows[0]["Short_Info"].ToString() != null) ? "Short Info : " + dt.Rows[0]["Short_Info"].ToString() : null;
            lblHDOfficeNo.Text = (dt.Rows[0]["Office_No"].ToString() != null) ? "Office No : " + dt.Rows[0]["Office_No"].ToString() : null;

            lblHDFaxNo.Text = (dt.Rows[0]["Fax_No"].ToString() != null) ? "Fax No : " + dt.Rows[0]["Fax_No"].ToString() : null;
            lblHDWebsite.Text = (dt.Rows[0]["Website"].ToString() != null) ? "Website : " + dt.Rows[0]["Website"].ToString() : null;
            lblHDAddress.Text = (dt.Rows[0]["Address"].ToString() != null) ? "Address : " + dt.Rows[0]["Address"].ToString() : null;

            lblHDServiceEmailId.Text = (dt.Rows[0]["ServiceEmail_Id"].ToString() != null) ? "Servic Email Id : " + dt.Rows[0]["ServiceEmail_Id"].ToString() : null;
            lblHDInfoEMailId.Text = (dt.Rows[0]["InfoEmail_Id"].ToString() != null) ? "Info Email Id : " + dt.Rows[0]["InfoEmail_Id"].ToString() : null;
            lblHDPerson.Text = (dt.Rows[0]["Contact_Name"].ToString() != null) ? "Person : " + dt.Rows[0]["Contact_Name"].ToString() : null;
        }
    }
    public void GetAllCategory()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select Category_Id,category_name from Category", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        rptCategories.DataSource = dt;
        rptCategories.DataBind();
    }
    private void GetCategotyWiseRelatedProduct(int categoryId)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select top 4 plant_Id as PlantId,(cast(plant_name as nvarchar(20))+ case when len(plant_name) > 16 then '...' else '' end ) as PlantName,price,image1,image2,Category_Id from Item_Details where Category_Id = " + categoryId + " order by plant_Id desc ;", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        rptProducts.DataSource = dt;
        rptProducts.DataBind();
    }

    protected void txtQuntity_TextChanged(object sender, EventArgs e)
    {
        if (txtQuntity.Text != null)
        {
            decimal? mainPrice = Convert.ToDecimal(lblPrice.Text);
            int? quantiy = Convert.ToInt32(txtQuntity.Text);
            lblFinalPrice.Text = Convert.ToString(((mainPrice != null) ? mainPrice : 0) * ((quantiy != null) ? quantiy : 0));
        }
    }

    protected void btnPlaceOrder_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["UserId"] != null && Session["UserId"].ToString() != "")
        {
            Response.Redirect("PlaceOrder.aspx?id=" + hdnProductId.Value, false);
        }
        else
        {
            Response.Redirect("login.aspx?type=order&id=" + hdnProductId.Value, false);
        }


    }
}