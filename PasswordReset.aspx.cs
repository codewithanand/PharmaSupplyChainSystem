using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect
{
    public partial class PasswordReset : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["token"] == null || Request.QueryString["email"] == null)
                {
                    Response.Redirect("ForgotPassword.aspx");
                }
                SuccessMessagePH.Visible = false;
                ErrorMessagePH.Visible = false;
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            string email = MyCryptography.Base64Decode(Request.QueryString["email"]).ToString();
            string token = Request.QueryString["token"].ToString();
            string password = Password.Text.ToString();

            con.Open();
            string checkQry = "SELECT email, token, expires_at FROM [password_reset_tokens] WHERE email=@email AND token=@token";
            SqlCommand checkCmd = new SqlCommand(checkQry, con);
            checkCmd.Parameters.AddWithValue("@email", email);
            checkCmd.Parameters.AddWithValue ("@token", token);
            SqlDataReader reader = checkCmd.ExecuteReader();
            if (reader.Read())
            {
                DateTime expires_at = (DateTime)reader.GetValue(2);
                con.Close();
                if(expires_at < DateTime.Now)
                {
                    SuccessMessagePH.Visible = false;
                    ErrorMessagePH.Visible = true;
                    ErrorMessage.Text = "Token expired!";
                }
                else
                {
                    try
                    {
                        ChangePassword(email, password);
                        Response.Redirect("Login.aspx");
                    }
                    catch (Exception ex)
                    {
                        SuccessMessagePH.Visible = false;
                        ErrorMessagePH.Visible = true;
                        ErrorMessage.Text = "Error while reseting the password";
                    }
                }
            }
            else
            {
                con.Close();
                SuccessMessagePH.Visible = false;
                ErrorMessagePH.Visible = true;
                ErrorMessage.Text = "Token expired!";
            }
        }

        protected void ChangePassword(string email, string password)
        {
            con.Open();
            string updateQry = "UPDATE [users] SET password=@password WHERE email=@email";
            SqlCommand updateCmd = new SqlCommand(updateQry, con);
            updateCmd.Parameters.AddWithValue("@email", email);
            updateCmd.Parameters.AddWithValue("@password", MyCryptography.MyEncrypt(password));
            updateCmd.ExecuteNonQuery();
            con.Close();
            DeletePasswordResetToken(email);
            SuccessMessagePH.Visible = true;
            ErrorMessagePH.Visible = false;
            SuccessMessage.Text = "Password changed!";
        }

        protected void DeletePasswordResetToken(string email)
        {
            con.Open();
            string deleteQry = "DELETE FROM [password_reset_tokens] WHERE email=@email";
            SqlCommand deleteCmd = new SqlCommand(deleteQry, con);
            deleteCmd.Parameters.AddWithValue("@email", email);
            deleteCmd.ExecuteNonQuery();
            con.Close();
        }
    }
}