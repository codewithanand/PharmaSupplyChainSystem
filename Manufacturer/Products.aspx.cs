using MediConnect.Utils;
using System;
using System.Data.SqlClient;
using System.Data;

namespace MediConnect.Manufacturer
{
    public partial class Products : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (RoleMiddleware.Role() != 3)
                {
                    Response.Redirect("~/Unauthorized.aspx");
                }
                try
                {
                    BindProducts();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        protected void BindProducts()
        {
            string userId = Session["user_id"].ToString();
            string customerId = GetCustomerId(userId);
            con.Open();

            string getQuery = "SELECT products.id AS id, products.name AS name, categories.name AS category, customers.name AS owner, products.quantity AS quantity, products.price AS price FROM products INNER JOIN [categories] ON products.category_id = categories.id INNER JOIN [customers] ON products.owner_id = customers.id WHERE products.owner_id=@owner_id";
            SqlCommand getCmd = new SqlCommand(getQuery, con);
            getCmd.Parameters.AddWithValue("@owner_id", customerId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ProductListView.DataSource = ds;
            ProductListView.DataBind();
            con.Close();
        }

        protected string GetCustomerId(string userId)
        {
            con.Open();
            string getQuery = "SELECT * FROM [customers] WHERE user_id=@user_id";
            SqlCommand getCmd = new SqlCommand(getQuery, con);
            getCmd.Parameters.AddWithValue("@user_id", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            return ds.Tables[0].Rows[0]["id"].ToString();
        }
    }
}