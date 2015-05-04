using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace WebApplication2.Customer
{
    public partial class OrderU : System.Web.UI.Page
    {
        SqlConnection myConnection;
        protected void Page_Load(object sender, EventArgs e)
        {
            myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["stitchDBConnectionString"].ConnectionString);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {

        }

        protected void ListOrders_Click(object sender, EventArgs e)
        {
            DateTime firstDate = Calendar1.SelectedDate;
            DateTime lastDate = DateTime.Now;
            Label1.Text = "";
            Label2.Text = "";
            App_DB.Order db = new App_DB.Order();
            String label = "";
            if (firstDate <= lastDate)
            {
                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("select * from Orders where Date >= '" + firstDate + "' AND Date <= '" + lastDate + "' AND UserID='" + Session["userName"] + "' ", myConnection);

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        label = myReader["Order"].ToString() + "  ";
                        Label2.Text += label;
                        label = "";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                Label2.Text = "";
                Label1.Text = "Alegeti un interval valid!";
            }
        }
    }
}
