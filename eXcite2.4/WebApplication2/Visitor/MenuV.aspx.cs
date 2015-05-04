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
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class MenuV : System.Web.UI.Page
    {
        SqlConnection myConnection;
        protected void Send_Click(object sender, EventArgs e)
        {
            App_DB.ProductDataContext db = new App_DB.ProductDataContext();

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Pizza WHERE Nume ='" + ListBox1.SelectedItem.ToString() + "'", myConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                      TextBox2.Text = (Convert.ToInt32(myReader["UnitPrice"]) * Convert.ToInt32(TextBox1.Text)).ToString();
                 /*   TextBox1.Text = myReader["UnitPrice"].ToString();*/
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        protected void Send_Click1(object sender, EventArgs e)
        {
            Button1.Visible = false;
            Label2.Text = " !!Va rugam sa va logati!!";
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*App_DB.ProductDataContext db = new App_DB.ProductDataContext();

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from Pizza where Nume ='" + ListBox1.SelectedItem.ToString() + "'", myConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                    TextBox1.Text = myReader["UnitPrice"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/
        }

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
    }
}
