using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webFood.Admin
{
    public partial class perdoruesit : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["breadCrum"] = "perdoruesit";
                if (Session["Admin"] == null)
                {
                    Response.Redirect("../Perdoruesi/Login.aspx");
                }
                else
                {
                    GetUsers();
                }
            }
        }
        private void GetUsers()
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("perdoruesi_crud", con);
            cmd.Parameters.AddWithValue("@veprimi", "SELECT4ADMIN");
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rUsers.DataSource = dt;
            rUsers.DataBind();



        }

        protected void rUsers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Fshi")
            {
                con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("perdoruesi_crud", con);
                cmd.Parameters.AddWithValue("@veprimi", "DELETE");
                cmd.Parameters.AddWithValue("@perdoruesiId", e.CommandArgument);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Përdoruesi  u fshi me sukses";
                    lblMsg.CssClass = "alert alert-success";
                    GetUsers();
                }

                catch (Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error" + ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }


                finally
                {
                    con.Close();
                }

            }
        }
    }
}