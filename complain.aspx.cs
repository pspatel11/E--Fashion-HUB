using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;


public partial class COMPLAIN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getData();
    }
    public void getData()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select Complain_id,Complain_Name,Email_ID,Phone_no,Subject,Your_Complain from complain", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();

    }

    private void ClearALL()
    {
        txtName.Text = "";
        txtEmail.Text = "";
        txtPhoneNo.Text = "";
        txtSubject.Text = "";
        txtFeedback.Text = "";

       
        lblError.Text = "";

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            string query = "insert into complain(Complain_Name,Email_ID,Phone_no,Subject,Your_Complain) values('" + txtName.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtPhoneNo.Text.Trim() + "','" + txtSubject.Text.Trim() + "','" + txtFeedback.Text.Trim() + "')";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cn.Close();
            getData();
            ClearALL();
            Response.Write("<script>alert('Complain submitted.')</script>");
        }
        catch (Exception ex)
        {
            ClearALL();
            Response.Write("<script>alert('" + ex.Message.ToString() + "')</script>");
        }

    }

}