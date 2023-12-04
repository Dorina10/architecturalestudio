using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webFood.Perdoruesi
{
    public partial class Profili : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["perdoruesId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    getUserDetails();
                    getHistoriku();
                }
            }
        }
        void getUserDetails()
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("perdoruesi_crud", con);
            cmd.Parameters.AddWithValue("@veprimi", "SELECT4PROFILE");
            cmd.Parameters.AddWithValue("@perdoruesiId", Session["perdoruesId"]);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            rUserProfile1.DataSource = dt;
            rUserProfile1.DataBind();
            if (dt.Rows.Count == 1)
            {
                Session["emri"] = dt.Rows[0]["emri"].ToString();
                Session["email"] = dt.Rows[0]["email"].ToString();
                Session["imazhiUrl"] = dt.Rows[0]["imazhiUrl"].ToString();
                Session["datakrijimit"] = dt.Rows[0]["datakrijimit"].ToString();

            }


        }
        void getHistoriku()
        {
            int sr = 1;
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Fatura", con);
            cmd.Parameters.AddWithValue("@veprimi", "POROSIH");

            cmd.Parameters.AddWithValue("@perdoruesId", Session["perdoruesId"]);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dt.Columns.Add("NumriSerial", typeof(Int32));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    dataRow["NumriSerial"] = sr;
                    sr++;
                }
            }

            if (dt.Rows.Count == 0)
            {

                rHistoriku.FooterTemplate = null;
                rHistoriku.FooterTemplate = new CustomTemplate(ListItemType.Footer);

            }
            rHistoriku.DataSource = dt;
            rHistoriku.DataBind();
        }
        protected void rHistoriku_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                double grandTotal = 0;
                HiddenField pagesaId = e.Item.FindControl("hdnPagesaId") as HiddenField;
                Repeater repOrders = e.Item.FindControl("rPorosite") as Repeater;
                con = new SqlConnection(Connection.GetConnectionString());
                cmd = new SqlCommand("Fatura", con);
                cmd.Parameters.AddWithValue("@veprimi", "FATURAID");

                cmd.Parameters.AddWithValue("@perdoruesId", Session["perdoruesId"]);
                cmd.Parameters.AddWithValue("@pagesaId", Convert.ToInt32(pagesaId.Value));
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        grandTotal += Convert.ToDouble(dataRow["CmimiTotal"]);

                    }
                }

                DataRow dr = dt.NewRow();
                dr["CmimiTotal"] = grandTotal;
                dt.Rows.Add(dr);
                repOrders.DataSource = dt;
                repOrders.DataBind();
            }
        }
        //template per te shtuar kontrollet tek repeater koka,producti dhe footer section.
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
                    var footer = new LiteralControl("<tr><td><b>Shporta boshh..</b><a href='menu.aspx' class='badge badge-info ml-2'>Kliko për të porositur.. </a></td></tr></tbody></table>");
                    container.Controls.Add(footer);
                }
            }

        }

        
    }

}