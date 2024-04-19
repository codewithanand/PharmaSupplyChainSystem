using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (RoleMiddleware.Role() != 1)
                {
                    Response.Redirect("~/Unauthorized.aspx");
                }
                try
                {
                    string orderId = Request.QueryString["orderId"].ToString();
                    BindUserInformation(orderId);
                    BindOrderInformation(orderId);
                    BindItemInformations(orderId);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void BindUserInformation(string orderId)
        {
            string getQry = "SELECT addresses.name AS user_name, addresses.contact AS contact, addresses.street_address AS street_address, addresses.country AS country, addresses.city AS city, addresses.state AS state, addresses.pincode AS pincode, orders.order_date AS order_date, orders.delivery_date AS is_delivered FROM [orders] INNER JOIN [users] ON orders.user_id=users.id INNER JOIN [addresses] ON orders.address_id=addresses.id WHERE orders.id=@id";
            DataSet ds = GetDataSet(getQry, orderId);
            UserName.Text = ds.Tables[0].Rows[0]["user_name"].ToString();
            Contact.Text = ds.Tables[0].Rows[0]["contact"].ToString();
            string address = ds.Tables[0].Rows[0]["street_address"].ToString() + ", " + ds.Tables[0].Rows[0]["city"].ToString() + ", " + ds.Tables[0].Rows[0]["state"].ToString() + ", " + ds.Tables[0].Rows[0]["country"].ToString() + " - " + ds.Tables[0].Rows[0]["pincode"].ToString();
            Address.Text = address;
            OrderDate.Text = ds.Tables[0].Rows[0]["order_date"].ToString();
            DeliveryDate.Text = ds.Tables[0].Rows[0]["delivery_date"] == DBNull.Value ? "Not Deliverd" : ds.Tables[0].Rows[0]["delivery_date"].ToString();
        }

        protected void BindOrderInformation(string orderId)
        {
            string getQry = "SELECT orders.id AS id, products.name AS product_name, orders.quantity AS quantity, orders.transaction_id AS transaction_id FROM [orders] INNER JOIN [products] ON orders.product_id=products.id WHERE orders.id=@id";
            DataSet ds = GetDataSet(getQry, orderId);
            OrderId.Text = ds.Tables[0].Rows[0]["id"].ToString();
            ProductName.Text = ds.Tables[0].Rows[0]["product_name"].ToString();
            Quantity.Text = ds.Tables[0].Rows[0]["quantity"].ToString();
            TransactionId.Text = ds.Tables[0].Rows[0]["transaction_id"].ToString();
        }

        protected void BindItemInformations(string orderId)
        {
            string getQry = "SELECT order_products.product_uid AS product_uid, manufacturers.name AS manufacturer, products.manufacturing_date AS manufacturing_date, products.expiry_date AS expiry_date FROM [orders] INNER JOIN [products] ON orders.product_id=products.id INNER JOIN [manufacturers] ON orders.manufacturer_id=manufacturers.id INNER JOIN [order_products] ON orders.id=order_products.order_id WHERE orders.id=@id";
            DataSet ds = GetDataSet(getQry, orderId);
            ItemInfoListView.DataSource = ds;
            ItemInfoListView.DataBind();
        }

        protected DataSet GetDataSet(string query, string orderId)
        {
            con.Open();
            SqlCommand getCmd = new SqlCommand(query, con);
            getCmd.Parameters.AddWithValue("@id", orderId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            return ds;
        }
    }
}