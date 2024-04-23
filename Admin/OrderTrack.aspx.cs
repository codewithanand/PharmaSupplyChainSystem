using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class OrderTrack : System.Web.UI.Page
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
                    BindCheckpointListView();
                    BindTransportersListView();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }

        protected void BindCheckpointListView()
        {
            try
            {
                string orderId = Request.QueryString["orderId"].ToString();
                con.Open();
                string getQry = "SELECT * FROM [checkpoints] WHERE order_id=@order_id";
                SqlCommand getCmd = new SqlCommand(getQry, con);
                getCmd.Parameters.AddWithValue("@order_id", orderId);
                SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                CheckpointListView.DataSource = ds;
                CheckpointListView.DataBind();
                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void BindTransportersListView()
        {
            try
            {
                string orderId = Request.QueryString["orderId"].ToString();
                con.Open();
                string getQry = "SELECT transporters.name AS name, transporters.vehicle_no AS vehicle_no, order_transporters.source AS source, order_transporters.destination AS destination, order_transporters.dispatch_date AS dispatch_date, order_transporters.deliver_date AS delivery_date FROM [order_transporters] INNER JOIN [transporters] ON order_transporters.transporter_id=transporters.id WHERE order_transporters.order_id=@order_id";
                SqlCommand getCmd = new SqlCommand(getQry, con);
                getCmd.Parameters.AddWithValue("@order_id", orderId);
                SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                TransportersListView.DataSource = ds;
                TransportersListView.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}