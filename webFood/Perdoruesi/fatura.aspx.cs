using iTextSharp.text.pdf;
using iTextSharp.text;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Linq;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

using System.Net;

namespace webFood.Perdoruesi
{
    public partial class fatura : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;


        protected void Page_Load(object sender, EventArgs e)
        {
            //kur faqja ngarkohet  therasim funksion getDetajetPorosite qe te dale fatura
            if (!IsPostBack)
            {
                //nqs perdoruesi esht log ine
                if (Session["perdoruesId"] != null)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        rProduktiPorosi.DataSource = GetDetajetPorsit();
                        rProduktiPorosi.DataBind();
                    }
                }
                else //nqs nuk eshte loguar 
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        //krijojme nje funksion qe there stored procedure Fature ne menyre qe te marrim te dhenat
        DataTable GetDetajetPorsit()
        {
            double CmimiTotal = 0;
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Fatura", con);
            cmd.Parameters.AddWithValue("@veprimi", "FATURAID");
            cmd.Parameters.AddWithValue("@pagesaId", Convert.ToInt32(Request.QueryString["id"]));
            cmd.Parameters.AddWithValue("@perdoruesId", Session["perdoruesId"]);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow drow in dt.Rows)
                {
                    CmimiTotal += Convert.ToDouble(drow["CmimiTotal"]);
                }
            }
            DataRow dr = dt.NewRow();
            dr["CmimiTotal"] = CmimiTotal;
            dt.Rows.Add(dr);
            return dt;
        }

        protected void lbShkarkoFature_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "fatura.pdf";  // shenohet si e do emrin e fatures
                string downloadPath = Path.Combine(Server.MapPath("~/Downloads"), fileName);  // sheno pathin e shkarkimit

                DataTable dtbl = GetDetajetPorsit(); // Call the method to retrieve invoice details

                ExportToPdf(dtbl, downloadPath, "Fatura");  // Generate the PDF and save it to the download path

                // Prepare the file for download
                byte[] fileBytes = File.ReadAllBytes(downloadPath);
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(fileBytes);
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesazh.Visible = true;
                lblMesazh.Text = "Error Message: " + ex.Message.ToString();
            }
        }


        void ExportToPdf(DataTable dtblTable, String downloadPath, string strHeader)
        {
            FileStream fs = new FileStream(downloadPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252,
            BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, Color.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);
            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252,
            BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, Color.GRAY);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk( "Porositur nga  : MED  ", fntAuthor));
            prgAuthor.Add(new Chunk("\nData porosisë : " + dtblTable.Rows[0]["porosiDate"].ToString(),fntAuthor));
            
            document.Add(prgAuthor);
            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F,
            100.0F, Color.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);
            //Add line break
            document.Add(new Chunk("\n" , fntHead));
            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count - 2);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN,
            BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 9, 1, Color.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count - 2; i++)
{
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);

            }
            //table Data
            Font fntColumnData = new Font(btnColumnHeader, 8, 1, Color.BLACK);
            for (int i = 0; i < dtblTable.Rows.Count; i++)
{
                for (int j = 0; j < dtblTable.Columns.Count - 2; j++)
{
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Chunk(dtblTable.Rows[i][j].ToString(), fntColumnData));
                    table.AddCell(cell);
                }
            }
            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }
    }
}