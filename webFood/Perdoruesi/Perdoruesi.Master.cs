using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webFood.Perdoruesi
{
    public partial class Perdoruesi : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //nqs nuk eshte jo default page ky slider nuk ngarkohet 
            if (!Request.Url.AbsoluteUri.ToString().Contains("default.aspx"))
            {
                form1.Attributes.Add("class", "sub_page");


            }
            else
            {
                form1.Attributes.Remove("class");
                //ketu kontrolli behet  dinamik dhe ngarkohet 
                Control sliderUserControl1 = (Control)Page.LoadControl("sliderUserControl1.ascx");
                //shton kontrollin tek paneli
                Panel1slider.Controls.Add(sliderUserControl1);



            }
            //kur useri eshte log in dhe do te dale
            if (Session["perdoruesId"] != null)
            {
                ibLoginLogout.Text = "Log out";
                Utils utils = new Utils();
                Session["numriKarte"] = utils.cartCount(Convert.ToInt32(Session["perdoruesId"])).ToString();
            }
            //kur useri nuk esht futur dhe do te futet 
            else
            {
                ibLoginLogout.Text = "Log in";
                Session["numriKarte"] = "0";
            }
        }

        protected void ibLoginLogout_Click(object sender, EventArgs e)
        {
            //nqs nje perdorues eshte loguar nuk i shfaqet login , nese jo i shfaqet
            if (Session["perdoruesId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }

        

        protected void lbRegisterOrProfile_Click1(object sender, EventArgs e)
        {
            //nqs nje perdorues eshte loguar nuk i shfaqet login , nese jo i shfaqet
            if (Session["perdoruesId"] != null)
            {
                lbRegisterOrProfile.ToolTip = "Profili i perdoruesit";
                Response.Redirect("Profili.aspx");
            }
            else
            {
                lbRegisterOrProfile.ToolTip = "Profili i rregjistrimit";
                Response.Redirect("rregjistrimi.aspx");
            }
        }
    }
}