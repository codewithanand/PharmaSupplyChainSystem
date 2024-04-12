using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect
{
    public partial class Orders : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!AuthMiddleware.CheckAuth())
                {
                    Response.Redirect("Login.aspx");
                }
                try
                {
                    BindOrderListView();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }

        protected void BindOrderListView()
        {
            string userId = Session["user_id"].ToString();
            con.Open();
            string getQry = "SELECT products.name AS name, orders.quantity AS quantity, orders.total_price AS price, products.image AS image, orders.payment_mode AS payment_mode, orders.payment_status AS payment_status, orders.is_delivered AS delivery_status FROM [orders] INNER JOIN [products] ON orders.product_id=products.id WHERE orders.user_id=@user_id";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@user_id", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            OrderListView.DataSource = ds;
            OrderListView.DataBind();
            con.Close();
        }
    }
}