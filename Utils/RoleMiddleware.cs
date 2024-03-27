using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MediConnect.Utils
{
    public class RoleMiddleware
    {
        public static int Role()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
                con.Open();
                string getQuery = "SELECT user_type FROM [users] WHERE email=@email";
                SqlCommand getCmd = new SqlCommand(getQuery, con);
                getCmd.Parameters.AddWithValue("@email", HttpContext.Current.Session["user"]);
                SqlDataReader reader = getCmd.ExecuteReader();
                if (reader.Read())
                {
                    int role = Convert.ToInt32(reader.GetValue(0));
                    con.Close();
                    return role;
                }
                else
                {
                    con.Close();
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}