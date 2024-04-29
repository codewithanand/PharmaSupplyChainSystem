using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class UserAdd : System.Web.UI.Page
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
            }
            if (IsPostBack)
            {
                CreateUserButton.Enabled = false;
            }
        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                StoreUser();
                StoreAgent();
                ErrorMessage.Text = string.Empty;
                SuccessMessage.Text = "User created successfully.";
            }
            catch(Exception ex)
            {
                SuccessMessage.Text = string.Empty;
                ErrorMessage.Text = "Error while creating a user.";
                Console.Write(ex);
            }
        }

        protected void StoreUser()
        {
            con.Open();
            string insertQry = "INSERT INTO [users] (name, email, password, user_type, email_verified_at, is_active, created_at, updated_at, deleted_at) VALUES (@name, @email, @password, @user_type, @email_verified_at, @is_active, @created_at, @updated_at, @deleted_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@name", Name.Text.ToString());
            insertCmd.Parameters.AddWithValue("@email", Email.Text.ToString());
            insertCmd.Parameters.AddWithValue("@password", MyCryptography.MyEncrypt(Password.Text.ToString()));
            insertCmd.Parameters.AddWithValue("@user_type", UserType.SelectedIndex);
            insertCmd.Parameters.AddWithValue("@email_verified_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@is_active", 1);
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@deleted_at", DBNull.Value);
            insertCmd.ExecuteNonQuery();
            con.Close();
        }

        protected void StoreAgent()
        {
            string ownerId = Session["user_id"].ToString();
            string userId = GetLastAgent();
            con.Open();
            string insertQry = "INSERT INTO [agents] (user_id, owner_id, created_at, updated_at) VALUES (@user_id, @owner_id, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@user_id", userId);
            insertCmd.Parameters.AddWithValue("@owner_id", ownerId);
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            con.Close();
        }

        protected string GetLastAgent()
        {
            con.Open();
            string getQry = "SELECT * FROM [users] WHERE email=@email";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@email", Email.Text.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            return ds.Tables[0].Rows[0]["id"].ToString();
        }
    }
}