using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getData();
    }

    public void getData()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select Product_ID,Name,email_id,mobile_no,Product_name,subject from Contact_us", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            string query = "insert into Contact_us(Name,email_id,mobile_no,Product_name,subject) values('" + txtName.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtPhoneNo.Text.Trim() + "','" + txtProductName.Text.Trim() + "','" + txtSubject.Text.Trim() + "')";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cn.Close();
            getData();

            Response.Write("<script>alert('Data is inserted.')</script>");
        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('" + ex.Message.ToString() + "')</script>");
        }

    }
   
}