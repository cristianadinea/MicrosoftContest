using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WebApplication2
{   
    public partial class Admin1 : System.Web.UI.MasterPage
    {
        /// <summary>
        /// On page load we always have to check if the user is logged in, also if he is an 
        /// administrator. 
        /// If he isn't logged in we redirect to the visitor home page, othervise (if he is 
        /// logged in, but he isn't an administrator) we redirect to the user home page.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Bine ai venit, " + Session["userName"].ToString();
            if (Session.IsNewSession)
            {
                Session.Add("isAdmin", false);
                Session.Add("userName", String.Empty);
            }
            if ((string)Session["userName"]!=String.Empty)
            {   
                if ((bool)Session["isAdmin"]==false)
                      Response.Redirect("../Customer/HomeU", true);
            }
            else
                Response.Redirect("../Visitor/HomeV", true);
        }
    }
}
