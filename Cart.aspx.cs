using MediConnect.Controllers;
using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MediConnect
{
    public partial class Cart : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!AuthMiddleware.CheckAuth())
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    try
                    {
                        BindCartListView();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        protected void BindCartListView()
        {
            string userId = Session["user_id"].ToString();
            
            DataSet ds = GetCarts(userId);

            CartListView.DataSource = ds;
            CartListView.DataBind();

            int totalCartItems = 0;
            float subTotalPrice = 0;
            float totalPrice = 0;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                totalCartItems += Convert.ToInt32(row["product_quantity"]);
                subTotalPrice += Convert.ToSingle(row["price"]) * Convert.ToInt32(row["product_quantity"]);
            }

            totalPrice = subTotalPrice;

            TotalCartItems.Text = totalCartItems.ToString();
            SubTotalPrice.Text = subTotalPrice.ToString();
            TotalPrice.Text = totalPrice.ToString();
        }

        protected void PlaceOrderBtn_Click(object sender, EventArgs e)
        {
            string userId = Session["user_id"].ToString();
            DataSet cartDataSet = GetCarts(userId);
            
            foreach(DataRow row in cartDataSet.Tables[0].Rows)
            {
                float subTotalPrice = Convert.ToSingle(row["price"]) * Convert.ToInt32(row["product_quantity"]);
                string transactionId = TokenGenerator.Token(10);

                OrderController.store(userId, row["product_id"].ToString(), row["manufacturer_id"].ToString(), row["product_quantity"].ToString(), subTotalPrice.ToString(), transactionId);

                CartController.destroy(userId, Convert.ToInt32(row["id"]));
            }

            Response.Redirect("Orders.aspx");
        }

        protected DataSet GetCarts(string userId)
        {
            con.Open();
            string getQry = "SELECT * FROM [carts] INNER JOIN [products] ON carts.product_id=products.id WHERE user_id=@user_id ORDER BY carts.id DESC";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@user_id", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            return ds;
        }
    }
}