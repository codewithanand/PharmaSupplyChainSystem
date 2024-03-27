using System;
using System.Data.SqlClient;
using MediConnect.Utils;

namespace MediConnect
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            if(UserExists(Email.Text.ToString()))
            {
                ErrorMessage.Text = "An account is already registered with this email address!";
            }
            else
            {
                try
                {
                    // Generating 8-digit activation code
                    string activation_code = TokenGenerator.ActivationCode(8);

                    // Inserting user records into users table
                    con.Open();
                    string registerQry = "INSERT INTO [users] (name, email, password, activation_code, created_at, updated_at) VALUES (@name, @email, @password, @activation_code, @created_at, @updated_at)";
                    SqlCommand registerCmd = new SqlCommand(registerQry, con);
                    registerCmd.Parameters.AddWithValue("@name", Name.Text.ToString());
                    registerCmd.Parameters.AddWithValue("@email", Email.Text.ToString());
                    registerCmd.Parameters.AddWithValue("@password", MyCryptography.MyEncrypt(Password.Text.ToString()));
                    registerCmd.Parameters.AddWithValue("@activation_code", activation_code);
                    registerCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                    registerCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
                    registerCmd.ExecuteNonQuery();
                    con.Close();

                    // Sending activation code to user's email address
                    string emailBody = string.Empty;
                    emailBody = MailTemplates.EmailVerification(Email.Text.ToString(), activation_code);
                    try
                    {
                        MailServiceProvider.SendMail(Email.Text.ToString(), "Action Required - Verify Email", emailBody);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage.Text = ex.Message.ToString();
                    }

                    Response.Redirect("Login.aspx");
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = ex.Message.ToString();
                }
            }
        }

        protected bool UserExists(string email)
        {
            con.Open();
            string getQuery = "SELECT id FROM [users] WHERE email=@email";
            SqlCommand getQueryCmd = new SqlCommand(getQuery, con);
            getQueryCmd.Parameters.AddWithValue("@email", email);
            SqlDataReader getReader = getQueryCmd.ExecuteReader();

            if (getReader.HasRows) { 
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
       
    }
}