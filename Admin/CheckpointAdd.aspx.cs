using MediConnect.Utils;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace MediConnect.Admin
{
    public partial class CheckpointAdd : System.Web.UI.Page
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

                BindOwners();

                ErrorMessage.Text = string.Empty;
                SuccessMessage.Text = string.Empty;
            }
        }

        protected void CreateCheckpointBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string insertQry = "INSERT INTO [checkpoints] (name, address, remarks, order_id, owner_id, expected_date, delivery_date, is_delivered, created_at, updated_at) VALUES (@name, @address, @remarks, @order_id, @owner_id, @expected_date, @delivery_date, @is_delivered, @created_at, @updated_at)";
                SqlCommand insertCmd = new SqlCommand(insertQry, con);
                insertCmd.Parameters.AddWithValue("@name", CheckpointName.Text.ToString());
                insertCmd.Parameters.AddWithValue("@address", DBNull.Value);
                insertCmd.Parameters.AddWithValue("@remarks", DBNull.Value);
                insertCmd.Parameters.AddWithValue("@order_id", OrderId.Text.ToString());
                insertCmd.Parameters.AddWithValue("@owner_id", OwnerDropDownList.SelectedValue);
                insertCmd.Parameters.AddWithValue("@expected_date", TextFormatter.ConvertTextToDate(ExpectedDate.Text.ToString()));
                insertCmd.Parameters.AddWithValue("@delivery_date", DBNull.Value);
                insertCmd.Parameters.AddWithValue("@is_delivered", 0);
                insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
                insertCmd.ExecuteNonQuery();
                con.Close();

                ErrorMessage.Text = string.Empty;
                SuccessMessage.Text = "Checkpoint created successfully";
            }
            catch (Exception ex) {
                ErrorMessage.Text = "Error while creating checkpoint";
                SuccessMessage.Text = string.Empty;
            }
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
    }
}