using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect
{
    public partial class Agent : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!AuthMiddleware.CheckAuth() && RoleMiddleware.Role() != 6)
                {
                    Response.Redirect("Login.aspx");
                }
                if (Request.QueryString["orderId"] != null)
                {
                    DetailsPlaceHolder.Visible = true;
                    string orderId = Request.QueryString["orderId"].ToString();
                    OrderId.Text = Request.QueryString["orderId"].ToString();
                    BindCheckPointList(orderId);
                }
                else
                {
                    DetailsPlaceHolder.Visible = false;
                }
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string orderId = OrderId.Text.ToString();
            Response.Redirect("Agent.aspx?orderId=" + orderId);
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string orderId = OrderId.Text.ToString();
            string agentId = GetAgentId();

            if(LastDeliveryCheckBox.Checked == true)
            {
                UpdateOrder(orderId);
            }
            UpdateCheckpoint(agentId);

            Response.Redirect("Agent.aspx");
            
        }

        protected void UpdateOrder(string orderId)
        {
            con.Open();
            string updateQry = "UPDATE [orders] SET is_delivered=@is_delivered, delivery_date=@delivery_date, updated_at=@updated_at WHERE id=@id";
            SqlCommand updateCmd = new SqlCommand(updateQry, con);
            updateCmd.Parameters.AddWithValue("@id", orderId);
            updateCmd.Parameters.AddWithValue("@is_delivered", 1);
            updateCmd.Parameters.AddWithValue("@delivery_date", DateTime.Now);
            updateCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            updateCmd.ExecuteNonQuery();
            con.Close();
        }

        protected void UpdateCheckpoint(string agentId)
        {
            con.Open();
            string updateQry = "UPDATE [checkpoints] SET checked_by=@checked_by, address=@address, remarks=@remarks, is_delivered=@is_delivered, delivery_date=@delivery_date, updated_at=@updated_at WHERE id=@id";
            SqlCommand updateCmd = new SqlCommand(updateQry, con);
            updateCmd.Parameters.AddWithValue("@id", CheckPointDropDownList.SelectedValue);
            updateCmd.Parameters.AddWithValue("@checked_by", agentId);
            updateCmd.Parameters.AddWithValue("@address", Address.Text.ToString());
            updateCmd.Parameters.AddWithValue("@remarks", Remarks.Text.ToString());
            updateCmd.Parameters.AddWithValue("@is_delivered", 1);
            updateCmd.Parameters.AddWithValue("@delivery_date", DateTime.Now);
            updateCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            updateCmd.ExecuteNonQuery();
            con.Close();
        }

        protected void BindCheckPointList(string orderId)
        {
            con.Open();
            string getQry = "SELECT * FROM [checkpoints] WHERE order_id=@order_id AND is_delivered=0";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@order_id", orderId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            CheckPointDropDownList.DataSource = ds;
            CheckPointDropDownList.DataTextField = "name";
            CheckPointDropDownList.DataValueField = "id";
            CheckPointDropDownList.DataBind();
            con.Close();
        }

        protected string GetAgentId()
        {
            con.Open();
            string getQry = "SELECT id, name FROM [users] WHERE email=@email";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@email", Session["user"].ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            string agentId = ds.Tables[0].Rows[0]["id"].ToString();
            return agentId;
        }
    }
}