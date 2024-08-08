using MediConnect.Utils;
using System;
using System.Data.SqlClient;
using System.Data;

namespace MediConnect.Manufacturer
{
    public partial class Orders : System.Web.UI.Page
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
                    BindOrderListView();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void BindOrderListView()
        {
            DataSet orderDataSet = GetOrders();
            OrderListView.DataSource = orderDataSet;
            OrderListView.DataBind();
        }

        protected DataSet GetOrders()
        {
            string userId = Session["user_id"].ToString();
            string customerId = GetCustomerId(userId);

            con.Open();
            string getQry = "SELECT orders.id AS id, customers.id AS owner, products.name AS product, orders.created_at AS order_date, orders.is_delivered AS is_delivered, addresses.city AS destination FROM [orders] INNER JOIN [products] ON products.id=orders.product_id INNER JOIN [customers] ON customers.id=orders.owner_id INNER JOIN [addresses] ON addresses.id=orders.address_id WHERE orders.owner_id=@owner_id ORDER BY orders.id DESC";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@owner_id", customerId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            return ds;
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