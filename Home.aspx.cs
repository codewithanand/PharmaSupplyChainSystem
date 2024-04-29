using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect
{
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                StoreCallRequesst();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        protected void StoreCallRequesst()
        {
            con.Open();
            string insertQry = "INSERT INTO [callback_requests] (name, email, subject, contact, message, created_at, updated_at) VALUES (@name, @email, @subject, @contact, @message, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@name", Name.Text.ToString());
            insertCmd.Parameters.AddWithValue("@email", Email.Text.ToString());
            insertCmd.Parameters.AddWithValue("@contact", Mobile.Text.ToString());
            insertCmd.Parameters.AddWithValue("@subject", Subject.Text.ToString());
            insertCmd.Parameters.AddWithValue("@message", Message.Text.ToString());
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            insertCmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Home.aspx");
        }
    }
}