using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFood.Admin;

namespace webFood.Perdoruesi
{
    public partial class menu : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // nqs faqja eshte ngarkuar per here te pare shfaq produktet dhe kategorite
            {
                GetCategories();
                GetProduktet();
            }
        }

        private void GetCategories()
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("category", con);
            cmd.Parameters.AddWithValue("@veprimi", "ACTIVECAT");
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rCategory.DataSource = dt;
            rCategory.DataBind();



        }

        private void GetProduktet()
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("produkt_crud", con);
            cmd.Parameters.AddWithValue("@veprimi", "ACTIVEPROD");
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rProducts.DataSource = dt;
            rProducts.DataBind();



        }
        public string LowerCase(object obj)
        {
            return obj.ToString().ToLower();

        }

        protected void rProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Session["perdoruesId"] != null) //nqs eshte loguar shko tek log in page 
            {
                bool isCartUpdated = false;
                int i = isItemExistOnCart(Convert.ToInt32(e.CommandArgument));
                if (i == 0)
                {
                    //shto new item ne shporten e e blerjes
                    con = new SqlConnection(Connection.GetConnectionString());
                    cmd = new SqlCommand("carta", con);
                    cmd.Parameters.AddWithValue("@veprimi", "INSERT");
                    cmd.Parameters.AddWithValue("@produktId", e.CommandArgument);
                    cmd.Parameters.AddWithValue("@sasia", 1);
                    cmd.Parameters.AddWithValue("@perdoruesId", Session["perdoruesId"]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error = " + ex.Message + "');<script>");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    //ky funksion eshte per te shtuar item ekzistues ne shporte
                    Utils utils = new Utils();
                    isCartUpdated = utils.updateSasineKarte(i + 1, Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session["perdoruesId"]));

                }
                lblMesazh.Visible = true;
                lblMesazh.Text = "Produkti u shtua me sukses ne shporten tende ";
                lblMesazh.CssClass = "alert alert-success";
                Response.AddHeader("REFRESH", "70;URL=Karta.aspx"); //pasi eshte kryer me sukses  pas nje sekonde do te coje tek faqja e shportes

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            int isItemExistOnCart(int produktId)
            {
                con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("carta", con);
                cmd.Parameters.AddWithValue("@veprimi", "GETBYID");
                cmd.Parameters.AddWithValue("@produktId", produktId);
                cmd.Parameters.AddWithValue("@perdoruesId", Session["perdoruesId"]);
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                int sasia = 0;
                if (dt.Rows.Count > 0)
                {
                    sasia = Convert.ToInt32(dt.Rows[0]["sasia"]);


                }
                return sasia;

            }
        }
    }
}