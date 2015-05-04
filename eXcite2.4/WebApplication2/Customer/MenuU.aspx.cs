using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Sql;
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

namespace WebApplication2.Customer
{
    public partial class MenuU : System.Web.UI.Page
    {
        SqlConnection myConnection;

        private static  Comanda com1= new Comanda();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*Comanda = new Comanda();*/
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
        protected void Send_Click(object sender, EventArgs e)
        {
            App_DB.ProductDataContext db = new App_DB.ProductDataContext();

            try
            {
                SqlDataReader myReader1;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Pizza WHERE Nume ='" + ListBox1.SelectedItem.ToString() + "'", myConnection);
                myReader1 = myCommand.ExecuteReader();
                if (myReader1.Read())
                {
                    TextBox2.Text = (Convert.ToInt32(myReader1["UnitPrice"]) * Convert.ToInt32(TextBox1.Text)).ToString();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected void Send_Click1(object sender, EventArgs e)
        {
            ItemComanda it = new ItemComanda(ListBox1.SelectedItem.ToString(), Convert.ToInt32(TextBox1.Text));
           
            
            com1.addText(it);
            int p = com1.getPretP(it);
            TextBox3.Text = p.ToString();
            Label2.Text ="RON";


        }
        protected void Send_Click2(object sender, EventArgs e)
        {
            com1.addDb();
            /*TextBox2.Text = (com1.getPretT()).ToString();*/
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

    }
}
