using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect
{
    public partial class EmailNotice : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!AuthMiddleware.CheckAuth())
                {
                    Response.Redirect("~/Login.aspx");
                }
                if (VerifiedMiddleware.Verified())
                {
                    Response.Redirect("Account.aspx");
                }
            }
            SuccessMessagePH.Visible = false;
            ErrorMessagePH.Visible = false;
        }

        protected void ResendButton_Click(object sender, EventArgs e)
        {
            string email = Session["user"].ToString();
            string activation_code = string.Empty;

            con.Open();
            string getCodeQry = "SELECT activation_code FROM [users] WHERE email=@email";
            SqlCommand getCodeCmd = new SqlCommand(getCodeQry, con);
            getCodeCmd.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = getCodeCmd.ExecuteReader();
            if(reader.Read())
            {
                activation_code = reader.GetValue(0).ToString();
                try
                {
                    string emailBody = string.Empty;
                    emailBody = MailTemplates.EmailVerification(email, activation_code);
                    MailServiceProvider.SendMail(email, "Action Required - Verify Email", emailBody);

                    ErrorMessagePH.Visible = false;
                    SuccessMessagePH.Visible = true;
                    SuccessMessage.Text = "Activation link sent!";
                }
                catch(Exception ex)
                {
                    SuccessMessagePH.Visible = false;
                    ErrorMessagePH.Visible = true;
                    ErrorMessage.Text = "Error while sending activation link";
                    Console.WriteLine(ex);
                }
            }
            else
            {
                SuccessMessagePH.Visible = false;
                ErrorMessagePH.Visible = true;
                ErrorMessage.Text = "Something went wrong!";
            }
        }
    }
}