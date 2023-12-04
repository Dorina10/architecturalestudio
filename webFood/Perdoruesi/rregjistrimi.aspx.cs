using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webFood.Perdoruesi
{
    public partial class rregjistrimi : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null) // && Session["perdoruesiId"])
                {
                    getUserDetails();
                }
                else if (Session["perdoruesId"] != null)
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string actionName = string.Empty, imagePath = string.Empty, fileExtension = string.Empty;
            bool isValidToExecute = false;
            int perdoruesId = Convert.ToInt32(Request.QueryString["Id"]);
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("perdoruesi_crud", con);
            cmd.Parameters.AddWithValue("@veprimi", perdoruesId == 0 ? "INSERT" : "UPDATE");
            cmd.Parameters.AddWithValue("@perdoruesiId", perdoruesId);
            cmd.Parameters.AddWithValue("@emriSt", TxtName.Text.Trim());
            cmd.Parameters.AddWithValue("@username", TxtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@telefoni", txtMobile.Text.Trim());
            cmd.Parameters.AddWithValue("@emaili", TxtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@adresa", txtAdresa.Text.Trim());
            cmd.Parameters.AddWithValue("@kodipostar", txtKodipostar.Text.Trim());
            cmd.Parameters.AddWithValue("@passwordi", txtPassword.Text.Trim());
            if (fuUserImage.HasFile)
            {
                if (Utils.IsValidExtension(fuUserImage.FileName))
                {
                    Guid obj = Guid.NewGuid();
                    fileExtension = Path.GetExtension(fuUserImage.FileName);
                    imagePath = "/imazhet/perdoruesit/" + obj.ToString() + fileExtension;
                    fuUserImage.PostedFile.SaveAs(Server.MapPath("~/imazhet/perdoruesit/") + obj.ToString() + fileExtension);
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
                    actionName = perdoruesId == 0 ?
                        "rregjistrimi u krye me sukses! <b><a href='Login.aspx'>  Klikoni ketu  </a></b>  per tu loguar" :
                        "detajet u perditesuan me sukses! <b><a href='Profile.aspx'>Mund te klikoni ketu  </a></b> ";
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b>" + TxtUsername.Text.Trim() + "</b>" + actionName;
                    lblMsg.CssClass = "alert alert-success";
                    if (perdoruesId != 0)
                    {
                        Response.AddHeader("REFRESH", "1;URL=Profili.aspx");
                    }
                    clear();

                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("Violation of key unique"))
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "<b>" + TxtUsername.Text.Trim() + "</b> emri i perdoruesit ekziston,provo perseri..!";
                        lblMsg.CssClass = "alert alert-danger";
                    }


                }
                catch (Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error~" + ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }
                finally
                {

                    con.Close();

                }
            }
        }
        void getUserDetails()
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("perdoruesi_crud", con);
            cmd.Parameters.AddWithValue("@veprimi", "SELECT4PROFILE");
            cmd.Parameters.AddWithValue("@perdoruesiId", Request.QueryString["Id"]);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                TxtName.Text = dt.Rows[0]["emri"].ToString();
                TxtUsername.Text = dt.Rows[0]["username"].ToString();
                txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                TxtEmail.Text = dt.Rows[0]["email"].ToString();
                txtAdresa.Text = dt.Rows[0]["adresa"].ToString();
                txtKodipostar.Text = dt.Rows[0]["kodipostar"].ToString();
                txtPassword.Text = dt.Rows[0]["password"].ToString();
                imgUser.ImageUrl = string.IsNullOrEmpty(dt.Rows[0]["imazhiUrl"].ToString())
                          ? "../imazhet/No_image.png" : "../" + dt.Rows[0]["imazhiUrl"].ToString();
                imgUser.Height = 200;
                imgUser.Width = 200;
                txtPassword.TextMode = TextBoxMode.SingleLine;
                txtPassword.ReadOnly = true;
                txtPassword.Text = dt.Rows[0]["password"].ToString();

            }
            lblHeaderMsg.Text = "<h2> Edito profilin </h2>";
            btnRegister.Text = "Perditeso";
            lblAlreadyUser.Text = "";

        }
        private void clear()
        {
            TxtName.Text = string.Empty;
            TxtUsername.Text = string.Empty;
            txtMobile.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            txtAdresa.Text = string.Empty;
            txtKodipostar.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }
    }
}