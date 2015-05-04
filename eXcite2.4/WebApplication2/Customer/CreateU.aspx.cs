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
    public partial class CreateU : System.Web.UI.Page
    {
        static DataTable tb2;
        protected void Page_Load(object sender, EventArgs e)
        {
            Array ing;
            App_DB.ProductDataContext db = new App_DB.ProductDataContext();
            ing = db.Ingredients.ToArray();
            if (tb2 == null) //first time the page is loaded
            {
                tb2 = new DataTable();
                tb2.Columns.Add("id");
                tb2.Columns.Add("Ingredient");
                tb2.Columns.Add("Cantitate");
                tb2.Columns.Add("Pret");
                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["stitchDBConnectionString"].ConnectionString);
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM ingredients", myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    DataRow row = tb2.NewRow();
                    row["id"] = myReader["IngredientID"].ToString();
                    row["Ingredient"] = myReader["Name"].ToString();
                    row["Pret"] = myReader["UnitPrice"].ToString();
                    row["Cantitate"] = 0;
                    tb2.Rows.Add(row);
                }
                myConnection.Close();
                GridView1.DataSource = tb2;
                GridView1.DataBind();
                for (int idx = 0; idx < GridView1.Rows.Count; idx++)
                {
                    GridViewRow row = GridView1.Rows[idx];
                    TextBox txt = ((TextBox)row.FindControl("TextBoxCantitate"));
                    txt.Text = tb2.Rows[idx]["Cantitate"].ToString();
                }
            }
            else //the page is being reloaded
            {
                for (int idx = 0; idx < GridView1.Rows.Count; idx++)
                {
                    GridViewRow row = GridView1.Rows[idx];
                    TextBox txt = ((TextBox)row.FindControl("TextBoxCantitate"));
                    tb2.Rows[idx]["Cantitate"] = txt.Text;
                }
                Session.Add("PizzaName", TextBox1.Text);
            }
        }

        protected void New_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["stitchDBConnectionString"].ConnectionString);
            myConnection.Open();
            float price = 0;
            int weight = 0;
            //first insert pizza to get the new PizzaID
            string sqlIns2 = "INSERT INTO Pizza (Nume, Gramaj, UnitPrice) VALUES (@nume, @gramaj, @unitprice)";
            SqlCommand cmdIns2 = new SqlCommand(sqlIns2, myConnection);
            cmdIns2.Parameters.AddWithValue("@nume", Session["PizzaName"].ToString());
            cmdIns2.Parameters.AddWithValue("@gramaj", weight);
            cmdIns2.Parameters.AddWithValue("@unitprice", price);
            cmdIns2.ExecuteNonQuery();
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Pizza WHERE Nume = '"+Session["PizzaName"].ToString()+"'", myConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();
            myReader.Read();
            int PizzaID = int.Parse(myReader["PizzaID"].ToString());
            myReader.Close();

            //then insert ingredients
            foreach (DataRow row in tb2.Rows)
            {
                string sqlIns = "INSERT INTO CPizzaIngredient (PizzaID, IngredientID, Quantity) VALUES (@PizzaID, @ingredient, @cantitate)";
                SqlCommand cmdIns = new SqlCommand(sqlIns, myConnection);
                cmdIns.Parameters.AddWithValue("@PizzaID", PizzaID);
                cmdIns.Parameters.AddWithValue("@ingredient", row["id"]);
                cmdIns.Parameters.AddWithValue("@cantitate", row["Cantitate"]);
                cmdIns.ExecuteNonQuery();
                price += float.Parse(row["Pret"].ToString()) * float.Parse(row["Cantitate"].ToString());
                weight += int.Parse(row["Cantitate"].ToString()) * 100;
            }

            //and last update price and weight
            sqlIns2 = "UPDATE Pizza SET Gramaj=" + weight + ", UnitPrice=" + price + " WHERE PizzaID ='" + PizzaID + "'";
            cmdIns2 = new SqlCommand(sqlIns2, myConnection);
            cmdIns2.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}
