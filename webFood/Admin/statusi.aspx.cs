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
    public partial class statusi : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["breadCrum"] = "statusi";
                if (Session["Admin"] == null)
                {
                    Response.Redirect("../Perdoruesi/Login.aspx");
                }
                else
                {
                    GetPorosiaStatus();

                }


            }
            lblMsg.Visible = false;
            pPerditesoStatusin.Visible = false;
        }
        private void GetPorosiaStatus()
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Fatura", con);
            cmd.Parameters.AddWithValue("@veprimi", "STATUSIp");
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rstatusiPorosise.DataSource = dt;
            rstatusiPorosise.DataBind();



        }
        protected void rstatusiPorosise_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            lblMsg.Visible = false;
            if (e.CommandName == "Edito")
            {
                con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("Fatura", con);
                cmd.Parameters.AddWithValue("@veprimi", "STATUSID");
                cmd.Parameters.AddWithValue("@detajetPorositeId", e.CommandArgument);
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                ddlDtatus.SelectedValue = dt.Rows[0]["statusi"].ToString();
                HiddenField1.Value = dt.Rows[0]["porosiId"].ToString();
                pPerditesoStatusin.Visible = true;
                LinkButton btn = e.Item.FindControl("LinkEdit") as LinkButton;
                btn.CssClass = " badge badge-warning ";

            }
        }

        /* protected void btnPerditeso_Click(object sender, EventArgs e)
         {
             int porosiId = Convert.ToInt32(HiddenField1.Value);
             con = new SqlConnection(Connection.GetConnectionString());
             cmd = new SqlCommand("Fatura", con);
             cmd.Parameters.AddWithValue("@veprimi", "STATUSIPERDITESIM");
             cmd.Parameters.AddWithValue("@detajetPorositeId", porosiId);
             cmd.Parameters.AddWithValue("@status", ddlDtatus.SelectedValue);
             cmd.CommandType = CommandType.StoredProcedure;
             try
             {
                 con.Open();
                 cmd.ExecuteNonQuery();
                 lblMsg.Visible = true;
                 lblMsg.Text = "Statusi i porosisë u përditësua  me sukses!";
                 lblMsg.CssClass = "alert alert-success";
                 GetPorosiaStatus();


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
         }*/
        protected void btnPerditeso_Click(object sender, EventArgs e)
        {
            int porosiId = Convert.ToInt32(HiddenField1.Value);
            string status = ddlDtatus.SelectedValue;

            con = new SqlConnection(Connection.GetConnectionString());
            con.Open();

            // Create the SQL update statement
            string updateQuery = "UPDATE Porosite SET statusi = @status WHERE porosiId = @porosiId";

            using (SqlCommand cmd = new SqlCommand(updateQuery, con))
            {
                // Add the parameters
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@porosiId", porosiId);

                // Execute the update statement
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Statusi i porosisë u përditësua me sukses!";
                    lblMsg.CssClass = "alert alert-success";
                    GetPorosiaStatus();
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Provoni përsëri .";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }

            con.Close();
        }


        protected void btnAnullo_Click(object sender, EventArgs e)
        {
            pPerditesoStatusin.Visible = false;
        }
        protected string GetStatusLabelClass(string status)
        {
            if (status.Equals("Dorezuar"))
            {
                return "badge badge-success";
            }
            else
            {
                return "badge badge-warning";
            }
        }

    }
}