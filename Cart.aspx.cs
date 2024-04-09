using MediConnect.Controllers;
using MediConnect.Utils;
using System;
using System.Data.SqlClient;

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
                    EmptyCartLiteral.Text = string.Empty;
                    CartRowLiteral.Text = string.Empty;
                    try
                    {
                        CheckCart();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }

        protected void CheckCart()
        {
            string userId = Session["user_id"].ToString();
            int carts = 0;
            con.Open();
            string getQry = "SELECT count(id) AS items FROM [carts] WHERE user_id=@user_id";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@user_id", userId);
            SqlDataReader reader = getCmd.ExecuteReader();
            if (reader.Read())
            {
                carts = Convert.ToInt32(reader["items"]);
            }
            con.Close();

            if(carts > 0)
            {
                try
                {
                    BindCarts();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            else
            {

            }
           
        }

        protected void BindCarts()
        {
            string userId = Session["user_id"].ToString();
            con.Open();
            string getQry = "SELECT * FROM [carts] INNER JOIN [products] ON carts.product_id=products.id WHERE user_id=@user_id";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@user_id", userId);
            SqlDataReader reader = getCmd.ExecuteReader();
            while (reader.Read())
            {
                CartRowLiteral.Text += "<div class=\"row shadow-sm mb-3 p-2\">";
                CartRowLiteral.Text += "<div class=\"col-md-4\">";
                CartRowLiteral.Text += "<img src=\"assets/uploads/product/" + reader["image"] +"\" width=\"100\" height=\"100\" />";
                CartRowLiteral.Text += "</div>";
                CartRowLiteral.Text += "<div class=\"col-md-4\">";
                CartRowLiteral.Text += "<h3>" + reader["name"] +"</h3>";
                CartRowLiteral.Text += "<p class=\"text-secondary\">Qty: " + reader["product_quantity"] +"</p>";
                CartRowLiteral.Text += "</div>";
                CartRowLiteral.Text += "<div class=\"col-md-4\">";
                CartRowLiteral.Text += "<h2>₹ " + reader["price"] +"</h2>";
                CartRowLiteral.Text += "<a href=\"#\" class=\"btn btn-danger\">Delete</a>";
                CartRowLiteral.Text += "<a href=\"#\" class=\"btn btn-dark\">Place Order</a>";
                CartRowLiteral.Text += "</div>";
                CartRowLiteral.Text += "</div>";
            }
            con.Close();
        }

        protected void BindEmptyCart()
        {
            EmptyCartLiteral.Text += "<div class=\"container mb-3 p-5\">";
            EmptyCartLiteral.Text += "<div class=\"d-flex flex-column align-items-center justify-content-center\">";
            EmptyCartLiteral.Text += "<i style=\"font-size: 90px;\" class=\"mdi mdi-cart-outline\"></i>";
            EmptyCartLiteral.Text += "<h2 class=\"text-mute\">Cart is empty</h2>";
            EmptyCartLiteral.Text += "<a href=\"Shop.aspx\" class=\"btn btn-dark\">Go to Shop</a>";
            EmptyCartLiteral.Text += "</div>";
            EmptyCartLiteral.Text += "</div>";
        }
    }
}