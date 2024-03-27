using System.Data.SqlClient;
using System.Configuration;

namespace MediConnect.Utils
{
    public class Connection
    {
        public static SqlConnection Connect()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        }
    }
}