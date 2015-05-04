using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary cref="data_acc">
/// It is user by the <see cref="log_aut">Login1_Authenticate</see> for 
/// validating the user
/// </summary>
public class DataAccess : IDisposable
{
    private SqlConnection conn;

    public DataAccess()
	{
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["stitchDBConnectionString"].ConnectionString);
    }

    /// <summary>
    ///  It checks if the given userName exists in the User dataBase, and if the given password 
    ///  matches the one assigned to this userName. 
    ///  Also it creates 2 session variables: a boolean, isAdmin, and a string, userName, that 
    ///  will help us know along the way if the user is logged in, and if he is a plain user or
    ///  an administrator.
    /// </summary>
    /// <param name="userName">the user ID</param>
    /// <param name="password"></param>
    /// <returns>Returns a warning in case the userName does not exist in the User dataBase,
    /// or the password does not match the one assigned to given userName in the User
    /// dataBase</returns>
    public string ValidateUser(string userName, string password)
    {
        string returnString;

        SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserName", conn);

        SqlParameter user = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
        user.Direction = ParameterDirection.Input;
        user.Value = userName;

        cmd.Parameters.Add(user);

        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (!dr.Read())
            returnString = "No such username";
        else
            if (dr["Password"].ToString().Equals(password))
            {
                returnString = String.Empty; 
                HttpSessionState Session = HttpContext.Current.Session;
                
                Session["isAdmin"]=(bool)dr["IsAdmin"];
                Session["userName"] = userName;
            }
            else
                returnString = "Password incorrect";
        
        cmd.Dispose();
        dr.Dispose();
        conn.Close();

        return returnString;
    }

    #region IDisposable Members

    public void Dispose()
    {
        if (conn != null)
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        conn.Dispose();
    }

    #endregion
}
