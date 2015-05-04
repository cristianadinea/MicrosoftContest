using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace WebApplication2.Customer
{
    public class ItemComanda
    {
        private String pizza;
        private int Cantitate;

        public String getPizza()
        { return this.pizza;}

        public int getCantitate()
        {
            return this.Cantitate;
        }

        public ItemComanda(String s, int c)
        {
            this.pizza = s;
            this.Cantitate = c;
        }

        public int getPret()
        {
            
            
        
                int pret;
                SqlConnection myConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["stitchDBConnectionString"].ConnectionString);
                myConnection1.Open();
                App_DB.ProductDataContext db = new App_DB.ProductDataContext();
                
               try{

                SqlDataReader myReader;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Pizza WHERE Nume = '" + pizza+ "'",myConnection1);
                myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {
                     pret= (Convert.ToInt32(myReader["UnitPrice"].ToString()))* this.Cantitate;
                     return pret;
                }
                return 0;
               }
          catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
    }
    }



    

