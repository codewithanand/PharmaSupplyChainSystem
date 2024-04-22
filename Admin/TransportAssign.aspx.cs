using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class TransportAssign : System.Web.UI.Page
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
                    OrderId.Text = orderId;
                    BindTransporterList();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void AssignButton_Click(object sender, EventArgs e)
        {
            string orderId = Request.QueryString["orderId"].ToString();
            try
            {
                InsertTransporter(orderId);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void InsertTransporter(string orderId)
        {
            con.Open();
            string insertQry = "INSERT INTO [order_transporters] (order_id, transporter_id, soure, destination, dispatch_date, deliver_date, created_at, updated_at) VALUES (@order_id, @transporter_id, @soure, @destination, @dispatch_date, @deliver_date, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@order_id", OrderId.Text.ToString());
            insertCmd.Parameters.AddWithValue("@transporter_id", TransporterDropDownList.SelectedValue);
            insertCmd.Parameters.AddWithValue("@soure", Source.Text.ToString());
            insertCmd.Parameters.AddWithValue("@destination", Destination.Text.ToString());
            insertCmd.Parameters.AddWithValue("@dispatch_date", TextFormatter.ConvertTextToDate(DispatchDate.Text.ToString()));
            insertCmd.Parameters.AddWithValue("@deliver_date", DBNull.Value);
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            insertCmd.ExecuteNonQuery();
            con.Close();
        }

        protected void BindTransporterList()
        {
            string ownerId = Request.QueryString["ownerId"].ToString();
            con.Open();
            string getQry = "SELECT * FROM [transporters] WHERE owner_id=@owner_id";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@owner_id", ownerId);
            SqlDataReader reader = getCmd.ExecuteReader();
            TransporterDropDownList.DataSource = reader;
            TransporterDropDownList.DataTextField = "name";
            TransporterDropDownList.DataValueField = "id";
            TransporterDropDownList.DataBind();
            con.Close();
        }
    }
}