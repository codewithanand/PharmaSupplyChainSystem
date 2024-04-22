using MediConnect.Utils;
using System;
using System.Data.SqlClient;
using System.IO;

namespace MediConnect.Admin
{
    public partial class CustomersAdd : System.Web.UI.Page
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
                ErrorMessage.Text = string.Empty;
                SuccessMessage.Text = string.Empty;
                try
                {
                    BindUsers();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }

        protected void BindUsers()
        {
            con.Open();
            string getQry = "SELECT * FROM [users] WHERE user_type != 1";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            SqlDataReader reader = getCmd.ExecuteReader();
            UserDropDownList.DataSource = reader;
            UserDropDownList.DataTextField = "name";
            UserDropDownList.DataValueField = "id";
            UserDropDownList.DataBind();
            con.Close();
        }

        protected void CreateCustomerButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateCustomer();

                ErrorMessage.Text = string.Empty;
                SuccessMessage.Text = "Customer created successfully.";
            }
            catch(Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
                SuccessMessage.Text = string.Empty;
            }
        }

        protected void CreateCustomer()
        {
            con.Open();
            string insertQry = "INSERT INTO [customers] (name, address, contact, image, user_id, created_at, updated_at, deleted_at) VALUES (@name, @address, @contact, @image, @user_id, @created_at, @updated_at, @deleted_at)";
            SqlCommand insertCmd = new SqlCommand(@insertQry, con);
            insertCmd.Parameters.AddWithValue("@name", Name.Text.ToString());
            insertCmd.Parameters.AddWithValue("@address", Address.Text.ToString());
            insertCmd.Parameters.AddWithValue("@contact", Contact.Text.ToString());

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
            string filePath = Server.MapPath("~/assets/uploads/customer/") + fileName;
            Image.SaveAs(filePath);
            insertCmd.Parameters.AddWithValue("@image", fileName);

            insertCmd.Parameters.AddWithValue("@user_id", UserDropDownList.SelectedValue);
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@deleted_at", DBNull.Value);
            insertCmd.ExecuteNonQuery();
            con.Close();
        }
    }
}