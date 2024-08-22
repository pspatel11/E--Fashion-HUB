using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

public partial class Fertilizer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Role"] != null && Session["Role"].ToString() != "" && (Session["Role"].ToString() == ConstantVariable.AdminRole || Session["Role"].ToString() == ConstantVariable.HolderRole))
            {
                if (Session["HolderId"] != null)
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;

                    getData();
                    getCategory();
                }
            }
            else
            {
                Response.Redirect("login.aspx", false);
            }
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

    public void getData()
    {
        int holderId;
        if (Session["HolderId"] != null)
        {
            holderId = Convert.ToInt32(Session["HolderId"].ToString());
            
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            string s = @"select plant_id,plant_name,p.Category_Id,c.category_name as category_name,Status_check,price,image1,image2
                        from Item_Details p
                        inner join Category c on p.Category_Id = c.Category_Id and c.category_type = 1 ";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(s);
            sb.AppendFormat("where holder_Id = {0}", holderId);
            sb.Append(" order by plant_id desc");


            SqlCommand cmd = new SqlCommand(sb.ToString(), cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cn.Close();
            grdFertilizer.DataSource = dt;
            grdFertilizer.DataBind();
        }
        else
        {
            Response.Redirect("login.aspx", false);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory.SelectedValue != null)
            {
                string newFileName1 = null;
                string image1path = null;
                string image1Db = null;
                if (Image1FileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(Image1FileUpload.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(fileName);
                    newFileName1 = txtFertilizerName.Text.Trim() + "_1_" + Guid.NewGuid() + fileExtension;
                    image1path = Server.MapPath("~/UploadPhoto/") + newFileName1;
                    image1Db = "UploadPhoto/" + newFileName1;
                    Image1FileUpload.PostedFile.SaveAs(image1path);
                }
                string newFileName2 = null;
                string image2path = null;
                string image2Db = null;
                if (Image2FileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(Image2FileUpload.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(fileName);
                    newFileName2 = txtFertilizerName.Text.Trim() + "_2_" + Guid.NewGuid() + fileExtension;
                    image2path = Server.MapPath("~/UploadPhoto/") + newFileName2;
                    image2Db = "UploadPhoto/" + newFileName2;
                    Image2FileUpload.PostedFile.SaveAs(image2path);
                }
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_insert_Item_Details", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Category_Id", (ddlCategory.SelectedValue == "") ? null : ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@plant_name", txtFertilizerName.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@care_info", txtChemicalInfo.Text.Trim());
                cmd.Parameters.AddWithValue("@plantation_info", txtFertilizerInfo.Text.Trim());
                cmd.Parameters.AddWithValue("@price", txtPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@Status_check", (ddlStatus.SelectedValue == "") ? null : ddlStatus.SelectedValue);
                cmd.Parameters.AddWithValue("@Holder_Id", Session["HolderId"]);
                cmd.Parameters.AddWithValue("@image1", image1Db);
                cmd.Parameters.AddWithValue("@image2", image2Db);
                cmd.ExecuteNonQuery();
                cn.Close();

                getData();

                Response.Write("<script>alert('Data is inserted.')</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message.ToString() + "')</script>");
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string newFileName1 = null;
            string image1path = null;
            string image1Db = null;
            if (Image1FileUpload.HasFile)
            {
                string fileName = Path.GetFileName(Image1FileUpload.PostedFile.FileName);
                string fileExtension = Path.GetExtension(fileName);
                newFileName1 = txtFertilizerName.Text.Trim() + "_1_" + Guid.NewGuid() + fileExtension;
                image1path = Server.MapPath("~/UploadPhoto/") + newFileName1;
                image1Db = "UploadPhoto/" + newFileName1;
                Image1FileUpload.PostedFile.SaveAs(image1path);
            }
            string newFileName2 = null;
            string image2path = null;
            string image2Db = null;
            if (Image2FileUpload.HasFile)
            {
                string fileName = Path.GetFileName(Image2FileUpload.PostedFile.FileName);
                string fileExtension = Path.GetExtension(fileName);
                newFileName2 = txtFertilizerName.Text.Trim() + "_2_" + Guid.NewGuid() + fileExtension;
                image2path = Server.MapPath("~/UploadPhoto/") + newFileName2;
                image2Db = "UploadPhoto/" + newFileName2;
                Image2FileUpload.PostedFile.SaveAs(image2path);
            }

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_update_Item_Details", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@plant_Id", hdnFertilizerId.Value.Trim());
            cmd.Parameters.AddWithValue("@Category_Id", (ddlCategory.SelectedValue == "") ? null : ddlCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@plant_name", txtFertilizerName.Text.Trim());
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@care_info", txtChemicalInfo.Text.Trim());
            cmd.Parameters.AddWithValue("@plantation_info", txtFertilizerInfo.Text.Trim());
            cmd.Parameters.AddWithValue("@price", txtPrice.Text.Trim());
            cmd.Parameters.AddWithValue("@Status_check", (ddlStatus.SelectedValue == "") ? null : ddlStatus.SelectedValue);
            cmd.Parameters.AddWithValue("@Holder_Id", Session["HolderId"]);
            cmd.Parameters.AddWithValue("@image1", image1Db);
            cmd.Parameters.AddWithValue("@image2", image2Db);

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
            string query = "delete from Item_Details where plant_Id = " + hdnFertilizerId.Value;
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
    protected void grdFertilizer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdFertilizer.PageIndex = e.NewPageIndex;
        getData();

        ClearALL();
    }

    protected void grdFertilizer_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSave.Visible = false;
        btnUpdate.Visible = true;
        btnDelete.Visible = true;

        GridViewRow row = grdFertilizer.SelectedRow;
        hdnFertilizerId.Value = grdFertilizer.SelectedDataKey.Value.ToString();

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        string s = @"select plant_Id,plant_name ,p.Category_Id ,Description,care_info,plantation_info, Status_check,price from Item_Details p where plant_Id = " + hdnFertilizerId.Value;
        SqlCommand cmd = new SqlCommand(s, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        if (dt != null && dt.Rows.Count > 0)
        {
            txtFertilizerName.Text = dt.Rows[0]["plant_name"].ToString();
            txtPrice.Text = dt.Rows[0]["price"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            txtChemicalInfo.Text = dt.Rows[0]["care_info"].ToString();
            txtFertilizerInfo.Text = dt.Rows[0]["plantation_info"].ToString();
            ddlCategory.SelectedValue = dt.Rows[0]["Category_Id"].ToString();
            ddlStatus.SelectedValue = dt.Rows[0]["Status_check"].ToString();
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
        txtFertilizerName.Text = "";
        txtDescription.Text = "";
        txtChemicalInfo.Text = "";
        txtFertilizerInfo.Text = "";
        txtPrice.Text = "";
        hdnFertilizerId.Value = null;
        ddlCategory.SelectedIndex = -1;
        ddlStatus.SelectedIndex = -1;
        lblError.Text = "";
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
    }

}