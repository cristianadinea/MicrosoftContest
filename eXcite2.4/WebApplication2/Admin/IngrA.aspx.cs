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

namespace WebApplication2.Admin
{
    public partial class IngrA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void ShowProducts()
        {
            App_DB.ProductDataContext db = new App_DB.ProductDataContext();

            var products = from p in db.Ingredients
                           select p;

            // Gridview1.DataSource = products;
            Gridview1.DataBind();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            App_DB.ProductDataContext db = new App_DB.ProductDataContext();

            App_DB.Ingredient p1 = new App_DB.Ingredient();

            db.Ingredients.InsertOnSubmit(p1);
            db.SubmitChanges();
            ShowProducts();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            App_DB.ProductDataContext db = new App_DB.ProductDataContext();
            App_DB.Ingredient ingredient = db.Ingredients.First(p => p.Name.StartsWith("s"));
            db.Ingredients.DeleteOnSubmit(ingredient);
            db.SubmitChanges();
            ShowProducts();
        }

    }
}
