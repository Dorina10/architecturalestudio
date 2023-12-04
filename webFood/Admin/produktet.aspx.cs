using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using webFood.Admin;
using webFood;

namespace webFood.Admin
{
    public partial class produktet : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
                Session["breadCrum"] = "produktet";
            if (Session["Admin"] == null)
            {
                Response.Redirect("../Perdoruesi/Login.aspx");
            }
            else
            {
                GetProduktet();
            }


            lblMsg.Visible = false;
        }

        protected void btnAddorUpdate_Click(object sender, EventArgs e)
        {
            string actionName = string.Empty, imagePath = string.Empty, fileExtension = string.Empty;
            bool isValidToExecute = false;
            int produktId = Convert.ToInt32(hdnId.Value);
            con = new SqlConnection(Connection.GetConnectionString());
           
            cmd = new SqlCommand("dbo.produkt_crud", con);
            cmd.Parameters.AddWithValue("@veprimi", produktId == 0 ? "INSERT" : "UPDATE");
            cmd.Parameters.AddWithValue("@produktId", produktId);
            cmd.Parameters.AddWithValue("@emri", textName.Text.Trim());
            cmd.Parameters.AddWithValue("@pershkrimi", TextPershkrimi.Text.Trim());
            cmd.Parameters.AddWithValue("@cmimi", TextCmimi.Text.Trim());
            cmd.Parameters.AddWithValue("@sasi", TextSasia.Text.Trim());
            cmd.Parameters.AddWithValue("@kategoriaId", kategorilist.Text.Trim());
            cmd.Parameters.AddWithValue("@aktiviteti", cbisactive.Checked);
            if (imazhi.HasFile)
            {
                if (Utils.IsValidExtension(imazhi.FileName))
                {
                    Guid obj = Guid.NewGuid();
                    fileExtension = Path.GetExtension(imazhi.FileName);
                    imagePath = "/imazhet/Produktet/" + obj.ToString() + fileExtension;
                    imazhi.PostedFile.SaveAs(Server.MapPath("~/imazhet/Produktet/") + obj.ToString() + fileExtension);
                    cmd.Parameters.AddWithValue("@imazhiUrl", imagePath);
                    isValidToExecute = true;
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Ju lutem selektoni formatin .jpg .jpeg ose .png ";
                    lblMsg.CssClass = "alert alert-danger ";
                    isValidToExecute = false;

                }
            }
            else
            {
                isValidToExecute = true;
            }
            if (isValidToExecute)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    actionName = produktId == 0 ? "u shtua " : "u perditesua ";
                    lblMsg.Visible = true;
                    lblMsg.Text = "Produkti  " + actionName + " me sukses!";
                    lblMsg.CssClass = "alert alert-success";
                    GetProduktet();
                    Clear();
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
        private void GetProduktet()
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("produkt_crud", con);
            cmd.Parameters.AddWithValue("@veprimi", "SELECT");
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rProduktet.DataSource = dt;
            rProduktet.DataBind();



        }
        private void Clear() //metode per te fshire te dhenat 
        {
            textName.Text = string.Empty;
            TextPershkrimi.Text = string.Empty;
            TextSasia.Text = string.Empty;
            TextCmimi.Text = string.Empty;
            kategorilist.ClearSelection();
            cbisactive.Checked = false;
            hdnId.Value = "0";
            btnAddorUpdate.Text = "Shto";
            imazhprodukt.ImageUrl = string.Empty;


        }


        protected void btnclear_Click(object sender, EventArgs e) //kur shtypim butonin clear dhe therritet metoda clear per te fshire te dhenat 
        {
            Clear();
        }

        protected void rProduktet_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            lblMsg.Visible = false;
            con = new SqlConnection(Connection.GetConnectionString());
            //kur duam te editojme nje produkt 
            if (e.CommandName == "Edito")
            {

                cmd = new SqlCommand("produkt_crud", con);
                cmd.Parameters.AddWithValue("@veprimi", "GETBYID");
                cmd.Parameters.AddWithValue("@produktId", e.CommandArgument);
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                textName.Text = dt.Rows[0]["emri"].ToString();
                TextPershkrimi.Text = dt.Rows[0]["pershkrimi"].ToString();
                TextCmimi.Text = dt.Rows[0]["cmimi"].ToString();
                TextSasia.Text = dt.Rows[0]["sasia"].ToString();
                kategorilist.SelectedValue = dt.Rows[0]["kategoriId"].ToString();
                cbisactive.Checked = Convert.ToBoolean(dt.Rows[0]["aktiviteti"]);
                imazhprodukt.ImageUrl = string.IsNullOrEmpty(dt.Rows[0]["imazhiUrl"].ToString()) ? "../imazhet/No_Image.png" : "../" + dt.Rows[0]["imazhiUrl"].ToString();
                imazhprodukt.Height = 200;
                imazhprodukt.Width = 200;
                hdnId.Value = dt.Rows[0]["produktId"].ToString();
                btnAddorUpdate.Text = "Update";
                LinkButton btn = e.Item.FindControl("LinkEdit") as LinkButton;
                btn.CssClass = " badge badge-warning ";

            }
            //kur duam te fshijme nje produkt
            else if (e.CommandName == "Fshi")
            {
                //con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("produkt_crud", con);
                cmd.Parameters.AddWithValue("@veprimi", "DELETE");
                cmd.Parameters.AddWithValue("@produktId", e.CommandArgument);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Produkti u fshi me sukses";
                    lblMsg.CssClass = "alert alert-success";
                    GetProduktet();
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

        protected void rProduktet_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label LblIsActive = e.Item.FindControl("LblIsActive") as Label;
                Label LblSasi = e.Item.FindControl("Lblsasi") as Label;
                if (LblIsActive.Text == "True")
                {
                    LblIsActive.Text = "Aktive";
                    LblIsActive.CssClass = " badge badge-success";


                }
                else
                {
                    LblIsActive.Text = "Jo aktive";
                    LblIsActive.CssClass = "badge badge-danger";
                }
                //nqs sasia eqe vendoset eshte poshte 5 ose <5 do te thote qe po shkon drejt fundit  dhe behet me nghyre te kuqe
                int sasiValue;
                if (int.TryParse(LblSasi.Text, out sasiValue))
                {
                    if (sasiValue <= 5)
                    {
                        LblSasi.CssClass = "badge badge-danger";
                        LblSasi.ToolTip = "Drejt perfundimit";
                    }
                }
            }

        }
    }
}