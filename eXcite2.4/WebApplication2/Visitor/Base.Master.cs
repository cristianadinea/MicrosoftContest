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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        /// <summary>
        /// When loadi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.IsNewSession)
            {
                Session.Add("isAdmin", false);
                Session.Add("userName", String.Empty);
            }
            bool p = (bool)Session["isAdmin"];
            p = false;
            Session["userName"] = String.Empty;
        }

        /// <summary cref="log_aut">
        /// After using the <see cref="data_acc">DataAcces</see> for validating the user
        /// it checks if the user is a plain user, in that case we redirect to the user 
        /// home page, or if he is an administrator, and then we redirect to the administrator
        /// home page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName = Login1.UserName;
            string password = Login1.Password;
            bool rememberUserName = Login1.RememberMeSet;

            DataAccess da = new DataAccess();
            if (da.ValidateUser(userName, password).Equals(String.Empty))
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                e.Authenticated = true;
               
                bool p = (bool)Session["isAdmin"];

                if ((bool)Session["isAdmin"] == true)
                {
                    Response.Redirect("../Admin/HomeA.aspx", true);
                }
                else
                { Response.Redirect("../Customer/HomeU.aspx", true); }
            }
        }
               
    }
    
}
