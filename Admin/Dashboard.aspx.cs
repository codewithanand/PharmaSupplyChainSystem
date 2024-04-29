using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;


namespace MediConnect.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (RoleMiddleware.Role() != 1)
                {
                    Response.Redirect("~/Unauthorized.aspx");
                }
                BindOrderDataValues();
                BindUserDataValues();
            }
        }

        protected void BindOrderDataValues()
        {
            string totalPendingOrderCount = GetOrderCount(false);
            string totalDeliveredOrderCount = GetOrderCount(true);

            PendingOrders.Text = totalPendingOrderCount;
            CompleteOrders.Text = totalDeliveredOrderCount;
        }

        protected void BindUserDataValues()
        {
            string totalUserCount = GetTotalUserCount();
            string totalManufacturerCount = GetUserCount(3);
            string totalConsumerCount = GetUserCount(0);
            string totalAgentCount = GetUserCount(6);

            TotalUserCount.Text = totalUserCount;
            ManufacturerCount.Text = totalManufacturerCount;
            ConsumerCount.Text = totalConsumerCount;
            AgentCount.Text = totalAgentCount;
        }

        protected string GetTotalUserCount()
        {
            con.Open();
            SqlCommand getCmd = new SqlCommand("SELECT COUNT(id) AS total_count FROM [users]", con);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            return ds.Tables[0].Rows[0]["total_count"].ToString();
        }

        protected string GetOrderCount(bool isDelivered)
        {
            int status = isDelivered == true ? 1 : 0;
            con.Open();
            SqlCommand getCmd = new SqlCommand("SELECT COUNT(id) AS total_count FROM [orders] WHERE is_delivered=@is_delivered", con);
            getCmd.Parameters.AddWithValue("@is_delivered", status);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            return ds.Tables[0].Rows[0]["total_count"].ToString();
        }

        protected string GetUserCount(int userType)
        {
            con.Open();
            SqlCommand getCmd = new SqlCommand("SELECT COUNT(id) AS total_count FROM [users] WHERE user_type=@user_type", con);
            getCmd.Parameters.AddWithValue("@user_type", userType);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            return ds.Tables[0].Rows[0]["total_count"].ToString();
        }
    }
}