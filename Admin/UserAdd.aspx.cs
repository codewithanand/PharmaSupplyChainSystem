using MediConnect.Utils;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;

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
    }
}