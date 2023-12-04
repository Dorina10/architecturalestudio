using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webFood.Admin
{
    public partial class kontakti : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["breadCrum"] = "kontakte";
                if (Session["Admin"] == null)
                {
                    Response.Redirect("../Perdoruesi/Login.aspx");
                }
                else
                {
                    GetKontaktet();
                }
            }
        }
        private void  GetKontaktet()
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Kontakti2", con);
            cmd.Parameters.AddWithValue("@veprimi", "SELECT");
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rKontakti.DataSource = dt;
            rKontakti.DataBind();
        }

        protected void rKontakti_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Fshi")
            {
                con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("Kontakti2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@veprimi", "DELETE");
                cmd.Parameters.AddWithValue("@kontaktId", e.CommandArgument);
               
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Fusha  u fshi me sukses";
                    lblMsg.CssClass = "alert alert-success";
                    GetKontaktet();
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