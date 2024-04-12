using MediConnect.Admin;
using MediConnect.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MediConnect.Controllers
{
    public class OrderController
    {
        public static void store(string userId, string productId, string manufacturerId, string quantity, string totalPrice, string transactionId)
        {
            SqlConnection con = Connection.Connect();
            con.Open();
            string insertQry = "INSERT INTO [orders] (user_id, manufacturer_id, product_id, quantity, total_price, transaction_id, payment_mode, payment_status, is_delivered, created_at, updated_at) VALUES (@user_id, @manufacturer_id, @product_id, @quantity, @total_price, @transaction_id, @payment_mode, @payment_status, @is_delivered, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@user_id", userId);
            insertCmd.Parameters.AddWithValue("@manufacturer_id", manufacturerId);
            insertCmd.Parameters.AddWithValue("@product_id", productId);
            insertCmd.Parameters.AddWithValue("@quantity", quantity);
            insertCmd.Parameters.AddWithValue("@total_price", totalPrice);
            insertCmd.Parameters.AddWithValue("@transaction_id", transactionId);
            insertCmd.Parameters.AddWithValue("@payment_mode", "cash");
            insertCmd.Parameters.AddWithValue("@payment_status", 1);
            insertCmd.Parameters.AddWithValue("@is_delivered", 0);
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            insertCmd.ExecuteNonQuery();
            con.Close();
        }
    }
}