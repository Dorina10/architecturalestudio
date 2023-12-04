using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webFood.Admin
{
    public partial class Kategorite : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["breadCrum"] = "Kategorite";
                if (Session["Admin"] == null)
                {
                    Response.Redirect("../Perdoruesi/Login.aspx");
                }
                else
                {
                    GetCategories();
                }
              

            }
            lblMsg.Visible = false;
        }
        protected void BtnAddorUpdate_Click(object sender, EventArgs e)
        {
            string actionName = string.Empty, imagePath = string.Empty, fileExtension = string.Empty;
            bool isValidToExecute = false;
            int kategoriId = Convert.ToInt32(hdnId.Value);
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("category", con);
            cmd.Parameters.AddWithValue("@veprimi", kategoriId == 0 ? "INSERT" : "UPDATE");
            cmd.Parameters.AddWithValue("@kategoriId", kategoriId);
            cmd.Parameters.AddWithValue("@emri", textName.Text.Trim());
            cmd.Parameters.AddWithValue("@aktiviteti", cbisactive.Checked);
            if (imazhikategori.HasFile)
            {
                if (Utils.IsValidExtension(imazhikategori.FileName))
                {
                    Guid obj = Guid.NewGuid();
                    fileExtension = Path.GetExtension(imazhikategori.FileName);
                    imagePath =  "/imazhet/Kategorite/" + obj.ToString() + fileExtension;
                    imazhikategori.PostedFile.SaveAs(Server.MapPath("~/imazhet/Kategorite/") + obj.ToString() + fileExtension);
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
            if(isValidToExecute)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    actionName = kategoriId == 0 ? "u shtua " : "perditesua ";
                    lblMsg.Visible = true;
                    lblMsg.Text = "Kategoria  "   + actionName +   " me sukses!";
                    lblMsg.CssClass = "alert alert-success";
                    GetCategories();
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

        private void GetCategories()
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("category", con);
            cmd.Parameters.AddWithValue("@veprimi", "SELECT");
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rCategory.DataSource = dt;
            rCategory.DataBind();



        }

        private void Clear()
        {
            textName.Text = string.Empty;
            cbisactive.Checked = false;
            hdnId.Value = "0";
            btnAddorUpdate.Text = "Shto";
            imazhkategori.ImageUrl = string.Empty;
            

        }
        protected void Btnclear_Click(object sender, EventArgs e)
        {
            Clear();

        }
        

        protected void rCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            lblMsg.Visible = false;
            con = new SqlConnection(Connection.GetConnectionString());
            if (e.CommandName == "Edito")
            {
              
                cmd = new SqlCommand("category", con);
                cmd.Parameters.AddWithValue("@veprimi", "GETBYID");
                cmd.Parameters.AddWithValue("@kategoriId", e.CommandArgument);
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                textName.Text = dt.Rows[0]["emri"].ToString();
                cbisactive.Checked = Convert.ToBoolean(dt.Rows[0]["aktiviteti"]);
                imazhkategori.ImageUrl = string.IsNullOrEmpty(dt.Rows[0]["imazhiUrl"].ToString()) ? "../imazhet/No_Image.png" : "../" + dt.Rows[0]["imazhiUrl"].ToString();
                imazhkategori.Height = 200;
                imazhkategori.Width = 200;
                hdnId.Value = dt.Rows[0]["kategoriId"].ToString();
                btnAddorUpdate.Text = "Update";
                LinkButton btn = e.Item.FindControl("LinkEdit") as LinkButton;
                btn.CssClass = " badge badge-warning ";

            }
            else if(e.CommandName == "Fshi")
            {
                //con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("category", con);
                cmd.Parameters.AddWithValue("@veprimi", "DELETE");
                cmd.Parameters.AddWithValue("@kategoriId", e.CommandArgument);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Kategoria u fshi me sukses";
                    lblMsg.CssClass = "alert alert-success";
                    GetCategories();
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



        protected void rCategory_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbl = e.Item.FindControl("LblIsActive") as Label;
                if (lbl.Text == "True")
                {
                    lbl.Text = "Aktive";
                    lbl.CssClass = " badge badge-success";


                }
                else
                {
                    lbl.Text = "Jo aktive";
                    lbl.CssClass = "badge badge-danger";
                }
            }



        }
    }
}

