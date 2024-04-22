using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect.Controllers
{
    public class CartController
    {
        public static void store(string userId, int productId, int quantity)
        {
            SqlConnection con = Connection.Connect();
            con.Open();
            string insertQry = "INSERT INTO [carts] (user_id, product_id, product_quantity, created_at, updated_at) VALUES (@user_id, @product_id, @product_quantity, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@user_id", userId);
            insertCmd.Parameters.AddWithValue("@product_id", productId);
            insertCmd.Parameters.AddWithValue("@product_quantity", quantity);
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            insertCmd.ExecuteNonQuery();
            con.Close();
        }

        public static void destroy(string userId, int cartId)
        {
            SqlConnection con = Connection.Connect();
            con.Open();
            string deleteQry = "DELETE FROM [carts] WHERE id=@id AND user_id=@user_id";
            SqlCommand deleteCmd = new SqlCommand(deleteQry, con);
            deleteCmd.Parameters.AddWithValue("@id", cartId);
            deleteCmd.Parameters.AddWithValue("@user_id", userId);
            deleteCmd.ExecuteNonQuery();
            con.Close();
        }

        public static void index(string userId)
        {
            SqlConnection con = Connection.Connect();
            con.Open();
            string getQry = "SELECT * FROM [carts] WHERE user_id=@user_id";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@user_id", userId);
            con.Close();
        }
    }
}