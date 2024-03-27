using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MediConnect.Utils
{
    public class VerifiedMiddleware
    {
        public static bool Verified()
        {
            try
            {
                SqlConnection con = Connection.Connect();
                con.Open();
                string getQuery = "SELECT is_active FROM [users] WHERE email=@email";
                SqlCommand getCmd = new SqlCommand(getQuery, con);
                getCmd.Parameters.AddWithValue("@email", HttpContext.Current.Session["user"]);
                SqlDataReader reader = getCmd.ExecuteReader();
                if (reader.Read())
                {
                    int active = Convert.ToInt32(reader.GetValue(0));
                    con.Close();
                    if(active == 1)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}