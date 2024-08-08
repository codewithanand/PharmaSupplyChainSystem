using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.Text = string.Empty;
            SuccessMessage.Text = string.Empty;
        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            string email = Email.Text.ToString();
            bool isUserExist = CheckEmail(email);
            if (isUserExist)
            {
                int isPasswordExpired = CheckPasswordResetToken(email);
                if (isPasswordExpired == 1)
                {
                    string password_reset_token = TokenGenerator.Token(8);
                    UpdatePasswordResetToken(email, password_reset_token);
                    ErrorMessage.Text = string.Empty;
                    SuccessMessage.Text = "Password reset link sent!";
                }
                else if (isPasswordExpired == 0)
                {
                    ErrorMessage.Text = "A password reset link is already sent!";
                    SuccessMessage.Text = string.Empty;
                }
                else
                {
                    string password_reset_token = TokenGenerator.Token(8);
                    InsertPasswordResetToken(email, password_reset_token);
                    ErrorMessage.Text = string.Empty;
                    SuccessMessage.Text = "Password reset link sent!";
                }
            }
            else
            {
                ErrorMessage.Text = "User does not exist!";
                SuccessMessage.Text = string.Empty;
            }
        }

        protected int CheckPasswordResetToken(string email)
        {
            con.Open();
            SqlCommand getCmd = new SqlCommand("SELECT expires_at, token FROM [password_reset_tokens] WHERE email=@email", con);
            getCmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DateTime expires_at = (DateTime)ds.Tables[0].Rows[0]["expires_at"];
                if (expires_at < DateTime.Now)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }

        protected bool CheckEmail(string email)
        {
            con.Open();
            SqlCommand getCmd = new SqlCommand("SELECT * FROM [users] WHERE email=@email", con);
            getCmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void InsertPasswordResetToken(string email, string password_reset_token)
        {
            con.Open();
            string insertQry = "INSERT INTO [password_reset_tokens] (email, token, expires_at, created_at, updated_at) VALUES (@email, @token, @expires_at, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@email", email);
            insertCmd.Parameters.AddWithValue("@token", password_reset_token);
            insertCmd.Parameters.AddWithValue("@expires_at", DateTime.Now.AddMinutes(10));
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            insertCmd.ExecuteNonQuery();
            con.Close();
            SendPasswordResetToken(email, password_reset_token);
        }

        protected void UpdatePasswordResetToken(string email, string password_reset_token)
        {
            con.Open();
            string updateQry = "UPDATE [password_reset_tokens] SET expires_at=@expires_at, updated_at=@updated_at WHERE email=@email";
            SqlCommand updateCmd = new SqlCommand(updateQry, con);
            updateCmd.Parameters.AddWithValue("@email", email);
            updateCmd.Parameters.AddWithValue("@expires_at", DateTime.Now.AddMinutes(10));
            updateCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            updateCmd.ExecuteNonQuery();
            con.Close();
            SendPasswordResetToken(email, password_reset_token);
        }

        protected void SendPasswordResetToken(string email, string password_reset_token)
        {
            string emailBody = string.Empty;
            emailBody = MailTemplates.PasswordReset(email, password_reset_token);
            MailServiceProvider.SendMail(email, "Action Required - Reset Password", emailBody);
        }
    }
}