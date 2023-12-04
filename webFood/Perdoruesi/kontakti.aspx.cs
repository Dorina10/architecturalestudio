using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Data.SqlClient;
using System.Data;

namespace webFood.Perdoruesi
{
    public partial class kontakti : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("Kontakti2", con);
                cmd.Parameters.AddWithValue("@veprimi", "INSERT");
                cmd.Parameters.AddWithValue("@emri", Txtemri.Text.Trim());
                cmd.Parameters.AddWithValue("@email", Txtemail.Text.Trim());
                cmd.Parameters.AddWithValue("@qellimi", Textqellim.Text.Trim());

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Visible = true;
                lblmsg.Text = "Faleminderit për mesazhin tuaj! Ju do të kontaktoheni së shpejti.";
                lblmsg.CssClass = "alert alert-success";
                clear();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " '); </script>");
            }
            finally
            {
                con.Close();
            }
        }
        private void clear()
        {
            Txtemri.Text = string.Empty;
            Txtemail.Text = string.Empty;
            Textqellim.Text = string.Empty;
        }
    }
}