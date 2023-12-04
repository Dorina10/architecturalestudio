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
    public partial class Karta : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        decimal totaliPerfundimtar = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["perdoruesId"] == null)
                {
                    Response.Redirect("Login.aspx");//nqs eshte loguar shkon tek log in page
                }
                else
                {
                    getProduktetKarta();
                }
            }
        }
        void getProduktetKarta()
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("carta", con);
            cmd.Parameters.AddWithValue("@veprimi", "SELECT");

            cmd.Parameters.AddWithValue("@perdoruesId", Session["perdoruesId"]);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rCartItem.DataSource = dt;
            if (dt.Rows.Count == 0)
            {

                rCartItem.FooterTemplate = null;
                rCartItem.FooterTemplate = new CustomTemplate(ListItemType.Footer);

            }
            rCartItem.DataBind();
        }

        protected void rCartItem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Utils utils = new Utils();
            if (e.CommandName == "Remove")
            {
                con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("carta", con);
                cmd.Parameters.AddWithValue("@veprimi", "DELETE");
                cmd.Parameters.AddWithValue("@produktId", e.CommandArgument);
                cmd.Parameters.AddWithValue("@perdoruesId", Session["perdoruesId"]);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    getProduktetKarta(); //shafq produktet qe jane ne karte
                    //cart count 
                    Session["numriKarte"] = utils.cartCount(Convert.ToInt32(Session["perdoruesId"]));
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
            if (e.CommandName == "Perditeso")
            {
                bool isCartUpdate = false;
                for (int item = 0; item < rCartItem.Items.Count; item++)
                {
                    if (rCartItem.Items[item].ItemType == ListItemType.Item || rCartItem.Items[item].ItemType == ListItemType.AlternatingItem)
                    {
                        TextBox quantity = rCartItem.Items[item].FindControl("txtQuantity") as TextBox;
                        HiddenField produktId = rCartItem.Items[item].FindControl("HiddenProductId") as HiddenField;
                        HiddenField sasia = rCartItem.Items[item].FindControl("HiddenSasia") as HiddenField;
                        int sasiaKarta = Convert.ToInt32(quantity.Text);
                        int ProduktId = Convert.ToInt32(produktId.Value);
                        int sasiaDatabaze = Convert.ToInt32(sasia.Value);
                        bool isTrue = false;
                        int updatedQuantity = 1;
                        if (sasiaKarta > sasiaDatabaze)
                        {
                            updatedQuantity = sasiaKarta;
                            isTrue = true;

                        }
                        else if (sasiaKarta < sasiaDatabaze)
                        {
                            updatedQuantity = sasiaKarta;
                            isTrue = true;

                        }
                        if (isTrue)
                        {
                            //perditeso sasine e produktit ne databaze
                            isCartUpdate = utils.updateSasineKarte(updatedQuantity, ProduktId, Convert.ToInt32(Session["perdoruesId"]));
                        }
                    }
                }
                getProduktetKarta();
            }
            
        }







        protected void rCartItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label cmimiTotal = e.Item.FindControl("lblTotalCmim") as Label;
                Label cmimiProdukt = e.Item.FindControl("LblCmim") as Label;
                TextBox sasia = e.Item.FindControl("txtQuantity") as TextBox;
                decimal calTotalPrice = Convert.ToDecimal(cmimiProdukt.Text) * Convert.ToDecimal(sasia.Text);
                cmimiTotal.Text = calTotalPrice.ToString();
                totaliPerfundimtar += calTotalPrice;



            }
            Session["totali perfundimtar"] = totaliPerfundimtar;
        }


        //template klase per te shtuar kontrollet 
        private sealed class CustomTemplate : ITemplate
        {
            private ListItemType ListItemType { get; set; }

            public CustomTemplate(ListItemType type)
            {
                ListItemType = type;
            }

            public void InstantiateIn(Control container)
            {
                if (ListItemType == ListItemType.Footer)
                {
                    var footer = new LiteralControl("<tr><td colspan='5'><b>Shporta juaj eshte bosh.</b><a href='menu.aspx' class='badge badge-info ml-2'>Vazhdo me blerjet </a></td></tr></tbody></table>");
                    container.Controls.Add(footer);
                }
            }

        }

        protected void lbKonfirmo_Click(object sender, EventArgs e)
        {
            bool isTrue = false;
            string pName = string.Empty;

            // Si fillim kontrollon sasine e produktit
            for (int item = 0; item < rCartItem.Items.Count; item++)
            {
                if (rCartItem.Items[item].ItemType == ListItemType.Item || rCartItem.Items[item].ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField produktId = rCartItem.Items[item].FindControl("HiddenProductId") as HiddenField;
                    HiddenField sasiaKarte = rCartItem.Items[item].FindControl("HiddenSasia") as HiddenField;
                    HiddenField sasiaProdukt = rCartItem.Items[item].FindControl("HiddenProdQuantity") as HiddenField;
                    Label productName = rCartItem.Items[item].FindControl("lblName") as Label;

                    int produktiId;
                    int sasiaNgaKarta;
                    int produktsasia;

                    if (int.TryParse(produktId.Value, out produktiId) &&
                        int.TryParse(sasiaKarte.Value, out sasiaNgaKarta) &&
                        int.TryParse(sasiaProdukt.Value, out produktsasia))
                    {
                        if (produktsasia > sasiaNgaKarta && produktsasia > 2)
                        {
                            isTrue = true;
                        }
                    }
                    else
                    {
                        isTrue = false;
                        pName = productName.Text.ToString();
                        break;
                    }
                }
                else
                {
                    // Parsing failed for one or more values
                    // Handle the error here, if necessary
                }
                if (isTrue)
                {
                    Response.Redirect("Pagesa.aspx");
                }
                else
                {
                    lblMesazh.Visible = true;
                    lblMesazh.Text = "Produkti nuk ka stok";
                    lblMesazh.CssClass = "alert alert-warning";
                }
            }
        
    }
    }
}

