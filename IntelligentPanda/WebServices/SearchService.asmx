<%@ WebService Language="C#" Class="SearchService" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SearchService  : System.Web.Services.WebService {

    /// <summary>
    /// Fetches a staff member's last name from the database that is like
    /// the text the user is typing into the text box.
    /// </summary>
    /// <param name="prefixText">The input text.</param>
    /// <param name="count">If numbers are entered, count is used instead.</param>
    /// <returns>A List of strings to be used as search results.</returns>
    [WebMethod]
    public IList<string> FetchNames(string prefixText, int count)
    {
        IList<string> result = new List<string>();
        string constr = Settings.PandaConnection;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT FirstName, LastName from StaffList WHERE LastName LIKE '%" + prefixText + "%' OR FirstName LIKE '%" + prefixText + "%' OR FirstName + ' ' + LastName LIKE '%" + prefixText + "%'";
        try
        {
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(dr["FirstName"].ToString() + " " + dr["LastName"].ToString());
            }
            con.Close();
            return result;
        }
        catch
        {
            return null;
        }
    }  
    
}