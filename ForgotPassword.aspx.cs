using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            SuccessMessagePH.Visible = false;
            ErrorMessagePH.Visible = false;
        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            string email = Email.Text.ToString();
            con.Open();
            string checkQry = "SELECT expires_at, token FROM [password_reset_tokens] WHERE email=@email";
            SqlCommand checkCmd = new SqlCommand(checkQry, con);
            checkCmd.Parameters.AddWithValue("email", email);
            SqlDataReader reader = checkCmd.ExecuteReader();
            if (reader.Read())
            {
                DateTime expires_at = (DateTime)reader.GetValue(0);
                string password_reset_token = reader.GetValue(1).ToString();
                con.Close();
                if(expires_at < DateTime.Now)
                {
                    try
                    {
                        UpdatePasswordResetToken(email, password_reset_token);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        SuccessMessagePH.Visible = false;
                        ErrorMessagePH.Visible = true;
                        ErrorMessage.Text = "Error while sending password reset link.";
                    }
                    SuccessMessagePH.Visible = true;
                    ErrorMessagePH.Visible = false;
                    SuccessMessage.Text = "Password reset link sent!";
                }
                else
                {
                    SuccessMessagePH.Visible = false;
                    ErrorMessagePH.Visible = true;
                    ErrorMessage.Text = "Password reset link already sent!";
                }
            }
            else
            {
                con.Close();
                try
                {
                    InsertPasswordResetToken(email);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    SuccessMessagePH.Visible = false;
                    ErrorMessagePH.Visible = true;
                    ErrorMessage.Text = "Error while sending password reset link.";
                }
                SuccessMessagePH.Visible = true;
                ErrorMessagePH.Visible = false;
                SuccessMessage.Text = "Password reset link sent!";
            }
        }

        protected void InsertPasswordResetToken(string email)
        {
            // Generating 8-digit password reset token
            string password_reset_token = TokenGenerator.Token(8);

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