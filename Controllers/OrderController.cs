using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect.Controllers
{
    public class OrderController
    {
        public static void store(string userId, string productId, string addressId, string ownerId, string quantity, string totalPrice, string transactionId)
        {
            SqlConnection con = Connection.Connect();
            con.Open();
            string insertQry = "INSERT INTO [orders] (user_id, address_id, owner_id, product_id, quantity, total_price, transaction_id, payment_mode, payment_status, order_date, delivery_date, is_delivered, created_at, updated_at) VALUES (@user_id, @address_id, @owner_id, @product_id, @quantity, @total_price, @transaction_id, @payment_mode, @payment_status, @order_date, @delivery_date, @is_delivered, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@user_id", userId);
            insertCmd.Parameters.AddWithValue("@address_id", addressId);
            insertCmd.Parameters.AddWithValue("@owner_id", ownerId);
            insertCmd.Parameters.AddWithValue("@product_id", productId);
            insertCmd.Parameters.AddWithValue("@quantity", quantity);
            insertCmd.Parameters.AddWithValue("@total_price", totalPrice);
            insertCmd.Parameters.AddWithValue("@transaction_id", transactionId);
            insertCmd.Parameters.AddWithValue("@payment_mode", "cash");
            insertCmd.Parameters.AddWithValue("@payment_status", 1);
            insertCmd.Parameters.AddWithValue("@order_date", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@delivery_date", DBNull.Value);
            insertCmd.Parameters.AddWithValue("@is_delivered", 0);
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            insertCmd.ExecuteNonQuery();
            con.Close();

            int orderId = GetLastOrderId();
            for(int i=1; i <= Convert.ToInt32(quantity); i++)
            {
                string productUid = ProductNumberGenerator.Generate(Convert.ToInt32(ownerId));
                StoreUniqueProduct(orderId, productId, productUid);
            }
        }

        public static void StoreUniqueProduct(int orderId, string productId, string productUid)
        {
            SqlConnection con = Connection.Connect();
            con.Open();
            string insertQry = "INSERT INTO [order_products] (order_id, product_id, product_uid, created_at, updated_at) VALUES (@order_id, @product_id, @product_uid, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@order_id", orderId);
            insertCmd.Parameters.AddWithValue("@product_id", productId);
            insertCmd.Parameters.AddWithValue("@product_uid", productUid);
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            insertCmd.ExecuteNonQuery();
            con.Close();
        }

        public static int GetLastOrderId()
        {
            string query = "SELECT TOP 1 id FROM [orders] ORDER BY id DESC";
            using (SqlConnection con = Connection.Connect())
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0; // No orders found
                }
            }
        }
    }
}