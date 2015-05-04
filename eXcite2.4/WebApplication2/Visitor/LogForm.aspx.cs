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
    public  partial class LogForm : System.Web.UI.Page
    {
        private App_DB.ProductDataContext db;
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

        /// <summary>
        /// It checks if all the the fields are filled and checks if the PASSWORD matches
        /// the CPASSWORD. In case of success it adds a new user to the User dataBase, 
        /// otherwise it prints a warning on the screen. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NewUser_Click(object sender, EventArgs e)
        {
            App_DB.ProductDataContext db = new App_DB.ProductDataContext();
           
          /*  var it = new App_DB.User();*/
            Label1.Text = "";
            if ((USERNAME.Text != null) && (CITY.Text != null) && (ADDRESS.Text != null) && (PASSWORD.Text != null) && (EMAIL.Text != null) && (NAME.Text != null))
            {
                
                if (PASSWORD.Text != CPASSWORD.Text)
                { OUTPUT.Text = "Your passwords do not match"; }
                else
                {
                    App_DB.User it = new App_DB.User();
                    it.UserID = USERNAME.Text;
                    it.Password = PASSWORD.Text;
                    it.IsAdmin = false;
                    it.Address = ADDRESS.Text;
                    it.Email = EMAIL.Text;
                    it.Name = NAME.Text;
                    it.City = CITY.Text;

                    try
                    {
                        SqlDataReader myReader = null;
                        SqlCommand myCommand = new SqlCommand("select * from Users where  UserId = '"+it.UserID+"'", myConnection);

                        myReader = myCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            Label1.Text = "Acest userId este deja inregistrat, va rugam sa reincercati.";
                        }
                        else
                        {
                            if(it.Email.Contains('@')){
                                db.Users.InsertOnSubmit(it);
                                db.SubmitChanges();
                                Label1.Text = "Ati fost inregistrat cu succes.";
                            }
                            else{
                                Label1.Text = "Adresa de email invalida.";
                            }
                           // Response.Redirect("../Visitor/HomeV.aspx", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    
                }
            }
            else
            { OUTPUT.Text = "All fields are mandatory"; }
            
        }
    }
}
