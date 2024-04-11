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
            con.Open();
            string getQry = "SELECT * FROM [carts] INNER JOIN [products] ON carts.product_id=products.id WHERE user_id=@user_id ORDER BY carts.id DESC";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@user_id", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();

            CartListView.DataSource = ds;
            CartListView.DataBind();

            float gst = 10;
            int totalCartItems = 0;
            float subTotalPrice = 0;
            float totalPrice = 0;
            float gstTotal = 0;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                totalCartItems += Convert.ToInt32(row["product_quantity"]);
                subTotalPrice += Convert.ToSingle(row["price"]) * Convert.ToInt32(row["product_quantity"]);
            }

            gstTotal = gst / 100 * subTotalPrice;
            totalPrice = subTotalPrice + gstTotal;

            TotalCartItems.Text = totalCartItems.ToString();
            SubTotalPrice.Text = subTotalPrice.ToString();
            GSTValue.Text = gstTotal.ToString();
            TotalPrice.Text = totalPrice.ToString();
        }
    }
}