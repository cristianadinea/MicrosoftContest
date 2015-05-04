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
    public class Comanda
    {
        private  int pretpartial;

        private  LinkedList<ItemComanda> lista = new LinkedList<ItemComanda>();
        
        public void  addText(ItemComanda i)
        {
            (this.lista).AddFirst(i);
        }
        public  int getPretP(ItemComanda it)
        {

            pretpartial = pretpartial + it.getPret();
            return pretpartial;

        }
        public LinkedList<ItemComanda> getLista()
        { return this.lista; }

        public int getPretT()
        {
            return pretpartial;
        }

        public String retLista()
        {
            LinkedList<ItemComanda>.Enumerator it = (this.getLista()).GetEnumerator();
            String result=String.Empty;
           // it.MoveNext();
            Boolean p = it.MoveNext();
            while(p)
            { result = result +it.Current.getPizza() + (it.Current.getCantitate()).ToString()+"\n";
               p=it.MoveNext();
            }
            
            lista.Clear();
            return result;
        }

            
          
        

        public void addDb()
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["stitchDBConnectionString"].ConnectionString);
            

            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            App_DB.ProductDataContext db = new App_DB.ProductDataContext();
            App_DB.Order or = new App_DB.Order();
            DateTime p;
            String userNow = (string)HttpContext.Current.Session["userName"];
            try
            {
                SqlDataReader myReader ;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Users WHERE UserID ='" + userNow + "'", myConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    or.UserID= myReader["UserID"].ToString();
                    p = DateTime.Now;
                    or.Date = p;
                    or.Address = myReader["Address"].ToString();
                    or.City = myReader["City"].ToString();
                    or.Order1 = this.retLista();
 

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            db.Orders.InsertOnSubmit(or);
            db.SubmitChanges();

        }
    }
}
