using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect
{
    public partial class Contact : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                StoreEnquiry();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        protected void StoreEnquiry()
        {
            con.Open();
            string insertQry = "INSERT INTO [enquiries] (name, email, subject, message, created_at, updated_at) VALUES (@name, @email, @subject, @message, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@name", Name.Text.ToString());
            insertCmd.Parameters.AddWithValue("@email", Email.Text.ToString());
            insertCmd.Parameters.AddWithValue("@subject", Subject.Text.ToString());
            insertCmd.Parameters.AddWithValue("@message", Message.Text.ToString());
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            insertCmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Contact.aspx");
        }
    }
}