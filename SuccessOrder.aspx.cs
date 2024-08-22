using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class SuccessOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] != null)
            {
                //transType = "offline"; //online
                if (Request.QueryString["transType"] != null)
                {
                    string transType = Request.QueryString["transType"].ToString();
                    if (transType == "offline")
                    {
                        int regid = Convert.ToInt32(Request.QueryString["regid"].ToString());
                        int itemId = Convert.ToInt32(Request.QueryString["itemId"].ToString());
                        decimal price = Convert.ToDecimal(Request.QueryString["price"].ToString());
                        int quantity = Convert.ToInt32(Request.QueryString["quantity"].ToString());

                        generateOrder(regid, itemId, price, quantity);
                    }
                }
                else if (Request.QueryString["tkn"] != null)
                {
                    string token = Request.QueryString["tkn"].ToString();

                    string[] separators = { "PD", "PR", "QN" };
                    string[] word1s = token.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    List<string> data = new List<string>();
                    foreach (var word in word1s)
                    {
                        data.Add(word);
                    }

                    if (data.Count > 0)
                    {
                        int regid = Convert.ToInt32(data[0].ToString());
                        int itemId = Convert.ToInt32(data[1].ToString());
                        decimal price = Convert.ToDecimal(data[2].ToString());
                        int quantity = Convert.ToInt32(data[3].ToString());

                        generateOrder(regid, itemId, price, quantity);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = " Your Order is canceled";
        }
    }
    public void generateOrder(int regid, int itemId, decimal price, int quantity)
    {
        try
        {
            string guidnew = Convert.ToString(Guid.NewGuid());
            string ordeNo = "OD-" + guidnew.Substring(0, 8).ToUpper();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_insert_order", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@order_no", ordeNo);
            cmd.Parameters.AddWithValue("@reg_id", regid);
            cmd.Parameters.AddWithValue("@Order_amount", price);
            cmd.Parameters.AddWithValue("@plant_Id", itemId);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.ExecuteNonQuery();
            cn.Close();
            lblmsg.Text = "Your Order is confirmed.and order no is '" + ordeNo + "'.";
        }
        catch (Exception ex)
        {
           lblmsg.Text = ex.Message;
        }       
    }

    public DataTable getUserDetails(int regId)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NurseryConnection"].ConnectionString);
        cn.Open();
        string s = @"select registration_id, first_name, last_name, email_id, mobile_no, gender, 
			(Address +' ' + (Case when ci.city_name is null then '' else (','+upper(ci.city_name)) end) +
					(Case when st.state_name is null then '' else (','+upper(st.state_name)) end) + 
					(Case when con.country_name is null then '' else (','+upper(con.country_name)) end) + 
					(Case when h.Postal_Code is null then '' else (' - '+h.Postal_Code) end)) as Address
from registration h
	left outer join country con on h.Country_Id = con.country_id
	left outer join state st on h.State_Id = st.state_id
	left outer join city ci on h.City_Id = ci.city_id
where registration_id = " + regId;
        SqlCommand cmd = new SqlCommand(s, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        cn.Close();
        return dt;
    }
}