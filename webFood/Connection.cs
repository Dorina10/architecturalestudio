using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI.WebControls;
using webFood.Admin;

namespace webFood
{
    public class Connection
           
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }
    }

    public class Utils
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public static bool IsValidExtension(string fileName)
        {
            bool isValid = false;
            string[] fileExtension = { ".jpg", ".png", "jpeg" };
            for (int i = 0; i < fileExtension.Length - 1; i++)
            {
                if (fileName.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;

        }
        //vendosim default imazh nese nk ka
        public static string GetimazhiUrl(Object url)
        {
            string url1 = "";
            if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                url1 = "../";
            }
            else
            {
                url1 = string.Format("../{0}", url);

            }
            return url1;





        }
        public bool updateSasineKarte(int sasia, int produktId, int perdoruesId) //kur e kemi nje produkt ekzistues ne karte dhe e shtojme prape 
        {
            bool isUpdated = false;
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("carta", con);
            cmd.Parameters.AddWithValue("@veprimi", "UPDATE");
            cmd.Parameters.AddWithValue("@produktId", produktId);
            cmd.Parameters.AddWithValue("@sasia", sasia);
            cmd.Parameters.AddWithValue("@perdoruesId", perdoruesId);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('Error = " + ex.Message + "');<script>");
            }
            finally
            {
                con.Close();
            }
            return isUpdated;
        }
        public int cartCount(int perdoruesId)
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("carta", con);
            cmd.Parameters.AddWithValue("@veprimi", "SELECT");
            cmd.Parameters.AddWithValue("@perdoruesId", perdoruesId);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt.Rows.Count;
        }
        public static string GetIdUnike()
        {
            Guid guid = Guid.NewGuid();
            String uniqueId = guid.ToString();
            return uniqueId;
        }
    }
}