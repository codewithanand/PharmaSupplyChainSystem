using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect
{
    public partial class ActivateAccount : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!AuthMiddleware.CheckAuth())
                {
                    Response.Redirect("Login.aspx");
                }
                else if (VerifiedMiddleware.Verified())
                {
                    Response.Redirect("Home.aspx");
                }
                else if (Request.QueryString["activation_code"] == null || Request.QueryString["email"] == null)
                {
                    Response.Redirect("EmailNotice.aspx");
                }
                PlaceHolder1.Visible = true;
                SuccessActivation.Visible = false;
                ErrorActivation.Visible = false;
            }
        }

        protected void ActivateButton_Click(object sender, EventArgs e)
        {
            Activate();
        }
        protected void Activate()
        {
            string activation_code = Request.QueryString["activation_code"].ToString();
            string email = MyCryptography.Base64Decode(Request.QueryString["email"]).ToString();

            if(IsCorrectActivationCode(activation_code, email))
            {
                con.Open();
                string updateQuery = "UPDATE [users] SET activation_code=@activation_code, email_verified_at=@email_verified_at, is_active=@is_active WHERE email=@email";
                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@email", email);
                updateCmd.Parameters.AddWithValue("@activation_code", DBNull.Value);
                updateCmd.Parameters.AddWithValue("@email_verified_at", DateTime.Now);
                updateCmd.Parameters.AddWithValue("@is_active", 1);
                updateCmd.ExecuteNonQuery();
                con.Close();

                PlaceHolder1.Visible = false;
                SuccessActivation.Visible = true;
                ErrorActivation.Visible = false;
            }
            else
            {
                // Display activation failure message
                PlaceHolder1.Visible = false;
                SuccessActivation.Visible = false;
                ErrorActivation.Visible = true;
            }
        }

        protected bool IsCorrectActivationCode(string activation_code, string email)
        {
            con.Open();
            string checkQry = "SELECT id FROM [users] WHERE activation_code=@activation_code and email=@email";
            SqlCommand checkCmd = new SqlCommand(checkQry, con);
            checkCmd.Parameters.AddWithValue("@activation_code", activation_code);
            checkCmd.Parameters.AddWithValue("email", email);
            SqlDataReader reader = checkCmd.ExecuteReader();
            if (reader.HasRows)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
    }
}