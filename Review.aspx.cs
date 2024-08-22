using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Review : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getData();
    }
    public void getData()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand("select Feedback_id,Feedback_Name as feedBackBy,Email_ID,Phone_no,Subject as Title,Your_feedback as msg,cast(Rating as nvarchar(5)) + ' Starts' as RatingView from feedback order by Feedback_id desc", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        cn.Close();
        rptReviews.DataSource = dt;
        rptReviews.DataBind();
    }
}