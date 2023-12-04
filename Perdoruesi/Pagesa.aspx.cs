using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webFood.Admin;

namespace webFood.Perdoruesi
{
    public partial class Pagesa : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr, dr1;
        DataTable dt;
        SqlTransaction transaction = null;
        string _emri = string.Empty; string _nrKarte = string.Empty; string _dataSkadimit = string.Empty; string _cvv = string.Empty;
        string _adresa = string.Empty; string _menyrapagese = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["perdoruesId"] == null)
                {
                    Response.Redirect("Login.aspx");//nqs eshte loguar shkon tek log in page
                }

            }
        }

        protected void lbCardSubmit_Click(object sender, EventArgs e)
        {
            _emri = txtName.Text.Trim();
            _nrKarte = txtCardNo.Text.Trim();
            _nrKarte = string.Format("************{0}", txtCardNo.Text.Trim().Substring(12, 4)); //do jete 16 shifror numer dhe 12 te parat nuk shafqen  4 te fundit do te shafqen
            _dataSkadimit = txtExpMonth.Text.Trim() + "/" + txtExpYear.Text.Trim(); //morem dhe muajin dhe vitin bashke sepse data skadimit eshte bashke psh 11/25
            _cvv = txtCvv.Text.Trim();
            _adresa = txtAddress.Text.Trim();
            _menyrapagese = "card";
            if (Session["perdoruesId"] != null) //nese sesioni nuk eshte bosh log in dhe nese jo shko tek log in page  
            {
                Pagesa1(_emri, _nrKarte, _dataSkadimit, _cvv, _adresa, _menyrapagese);
            }
            else
            {
                Response.Redirect("Login.aspx");//con userin tek login page
            }
        }

        protected void lbCodSubmit_Click(object sender, EventArgs e)
        {
            _adresa = txtCODAddress.Text.Trim();
            _menyrapagese = "cod";
            if (Session["perdoruesId"] != null) //nese sesioni nuk eshte bosh log in dhe nese jo shko tek log in page  
            {
                Pagesa1(_emri, _nrKarte, _dataSkadimit, _cvv, _adresa, _menyrapagese);

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        void Pagesa1(string emri, string numerKarte, string dataSkadimit, string nr3, string adresa, string menyraPagesa)
        {
            int pagesaId; int produktId; int sasia;
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] {
                new DataColumn("porosiNumer" , typeof(string)),
                new DataColumn("produktId" , typeof(int)),
                new DataColumn("sasia" , typeof(int)),
                new DataColumn("perdoruesId" , typeof(int)),
                new DataColumn("status" , typeof(string)),
                new DataColumn("pagesaId" , typeof(int)),
                new DataColumn("dataPorosise" , typeof(DateTime)),

                });
            con = new SqlConnection(Connection.GetConnectionString());
            con.Open();
            #region Sql Transaction
            transaction = con.BeginTransaction();
            cmd = new SqlCommand("pagesa3", con, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emri", emri);
            cmd.Parameters.AddWithValue("@nrKarta", numerKarte);
            cmd.Parameters.AddWithValue("@dataskadimit", dataSkadimit);
            cmd.Parameters.AddWithValue("@cvv", nr3);
            cmd.Parameters.AddWithValue("@adresa", adresa);
            cmd.Parameters.AddWithValue("@menyraPagese", menyraPagesa);
            cmd.Parameters.Add("@InsertedId", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                cmd.ExecuteNonQuery();
                pagesaId = Convert.ToInt32(cmd.Parameters["@InsertedId"].Value);

                #region marrja e produkteve nga karta
                cmd = new SqlCommand("carta", con, transaction);
                cmd.Parameters.AddWithValue("@veprimi", "SELECT");

                cmd.Parameters.AddWithValue("@perdoruesId", Session["perdoruesId"]);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    produktId = (int)dr["produktId"];
                    sasia = (int)dr["sasia"];
                    // perditeso sasine e produktit nqs 2 te parat pesojne ndonje gabim
                    PerditesoSasine(produktId, sasia, transaction, con);
                    // perditeso sasine e produktit fundi

                    //fshi produktet nga karta
                    FshiProduktetKarte(produktId, transaction, con);
                    //fshi produktet nga karta fundi
                    dt.Rows.Add(Utils.GetIdUnike(), produktId, sasia, (int)Session["perdoruesId"], "Pending", pagesaId, Convert.ToDateTime(DateTime.Now));

                }
                dr.Close();
                #endregion marrja e produkteve nga karta
                #region Te dhenat e porosise
                if (dt.Rows.Count > 0)
                {
                    cmd = new SqlCommand("detajet_porosise", con, transaction);


                    cmd.Parameters.AddWithValue("@tblPorosite", dt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                #endregion Te dhenat e porosise
                transaction.Commit();
                lblMsg.Visible = true;
                lblMsg.Text = "Porosia jote u krye me sukses";
                lblMsg.CssClass = "alert alert-success";
                Response.AddHeader("REFRESH", "1;URL=fatura.aspx?Id=" + pagesaId);
            }
            catch (Exception e)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            #endregion Sql Transaction
            finally
            {
                con.Close();
            }



        }
        void PerditesoSasine(int _produktId, int _sasia, SqlTransaction sqlTransaction, SqlConnection sqlConnection)
        {
            int dbSasia;
            cmd = new SqlCommand("produkt_crud", sqlConnection, sqlTransaction);
            cmd.Parameters.AddWithValue("@veprimi", "GETBYID");
            cmd.Parameters.AddWithValue("@produktId", _produktId);
            cmd.CommandType = CommandType.StoredProcedure;
            try //dr eshte data reader
            {
                dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    dbSasia = (int)dr1["sasia"];
                    if (dbSasia > _sasia && dbSasia > 2)
                    {
                        dbSasia -= _sasia;
                        cmd = new SqlCommand("produkt_crud", sqlConnection, sqlTransaction);
                        cmd.Parameters.AddWithValue("@veprimi", "QTYUPDATE");
                        cmd.Parameters.AddWithValue("@sasi", dbSasia);
                        cmd.Parameters.AddWithValue("@produktId", _produktId);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }

                }
                dr1.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {

            }
        }
        void FshiProduktetKarte(int _produktId, SqlTransaction sqlTransaction, SqlConnection sqlConnection)
        {
            cmd = new SqlCommand("carta", sqlConnection, sqlTransaction);
            cmd.Parameters.AddWithValue("@veprimi", "DELETE");

            cmd.Parameters.AddWithValue("@produktId", _produktId);
            cmd.Parameters.AddWithValue("@perdoruesId", Session["perdoruesId"]);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }


    }

}

