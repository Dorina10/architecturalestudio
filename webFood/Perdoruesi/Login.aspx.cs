using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webFood.Perdoruesi
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //nqs useri eshte loguar e con direkt tek default page dhe nuk e lejon te logohet perseri 
            if (Session["perdoruesId"] != null)
            {
                Response.Redirect("default.aspx");
            }


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {     
            //nqs futemi si admin ,diferenca midis admin dhe perdorues
            if (txtUsername.Text.Trim() == "Admin" && txtPassword.Text.Trim() == "123")
            {
                Session["admin"] = txtUsername.Text.Trim();
                Response.Redirect("../Admin/dashbord.aspx");
            }
            else
            {
                con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("perdoruesi_crud", con);
                cmd.Parameters.AddWithValue("@veprimi", "SELECT4LOGIN");
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@passwordi", txtPassword.Text.Trim());
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                //nqs useri ekziston  dhe futemi si perdorues

                if (dt.Rows.Count == 1)
                {
                    Session["username"] = txtUsername.Text.Trim();
                    Session["perdoruesId"] = dt.Rows[0]["perdoruesId"];
                    Response.Redirect("default.aspx");
                }
                else
                {
                    //nqs te dhenat jane gabim
                    lblmsg.Visible = true;
                    lblmsg.Text = "Te dhëna jo të sakta ";
                    lblmsg.CssClass = "alert alert-danger";
                }

            }
        }
    }
}