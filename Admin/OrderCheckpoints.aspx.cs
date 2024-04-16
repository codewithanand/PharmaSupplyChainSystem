using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class OrderCheckpoints : System.Web.UI.Page
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
                    BindCheckpointsListView();
                    BindOwners();
                }
                catch(Exception ex) {
                    Response.Write(ex.Message.ToString());
                }
            }
        }

        protected void BindCheckpointsListView()
        {
            string orderId = Request.QueryString["orderId"].ToString();
            con.Open();
            string getQry = "SELECT * FROM [checkpoints] WHERE order_id=@order_id";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@order_id", orderId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            CheckpointsListView.DataSource = ds;
            CheckpointsListView.DataBind();
            con.Close();
        }

        protected void BindOwners()
        {
            con.Open();
            string getQry = "SELECT * FROM [manufacturers] WHERE deleted_at IS NULL";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            SqlDataReader reader = getCmd.ExecuteReader();
            OwnerDropDownList.DataSource = reader;
            OwnerDropDownList.Items.Clear();
            OwnerDropDownList.DataTextField = "name";
            OwnerDropDownList.DataValueField = "id";
            OwnerDropDownList.DataBind();
            con.Close();
        }

        protected void CreateCheckpointBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string orderId = Request.QueryString["orderId"].ToString();
                con.Open();
                string insertQry = "INSERT INTO [checkpoints] (name, address, remarks, order_id, owner_id, expected_date, delivery_date, is_delivered, created_at, updated_at) VALUES (@name, @address, @remarks, @order_id, @owner_id, @expected_date, @delivery_date, @is_delivered, @created_at, @updated_at)";
                SqlCommand insertCmd = new SqlCommand(insertQry, con);
                insertCmd.Parameters.AddWithValue("@name", CheckpointName.Text.ToString());
                insertCmd.Parameters.AddWithValue("@address", DBNull.Value);
                insertCmd.Parameters.AddWithValue("@remarks", DBNull.Value);
                insertCmd.Parameters.AddWithValue("@order_id", orderId);
                insertCmd.Parameters.AddWithValue("@owner_id", OwnerDropDownList.SelectedValue);
                insertCmd.Parameters.AddWithValue("@expected_date", TextFormatter.ConvertTextToDate(ExpectedDate.Text.ToString()));
                insertCmd.Parameters.AddWithValue("@delivery_date", DBNull.Value);
                insertCmd.Parameters.AddWithValue("@is_delivered", 0);
                insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
                insertCmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("OrderCheckpoints.aspx?orderId=" + orderId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}