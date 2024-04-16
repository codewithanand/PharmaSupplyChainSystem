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
    }
}