using MediConnect.Utils;
using System;
using System.Data.SqlClient;
using System.Data;

namespace MediConnect.Admin
{
    public partial class UserEdit : System.Web.UI.Page
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
                try
                {
                    string id = Request.QueryString["id"].ToString();
                    BindInputs(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    SuccessMessage.Text = "";
                    ErrorMessage.Text = "Something went wrong while loading data";
                }
            }
            if (IsPostBack)
            {
                UpdateUserButton.Enabled = false;
            }
        }

        protected void BindInputs(string id)
        {
            
            con.Open();
            string getQry = "SELECT * FROM [users] WHERE id=@id";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            con.Close();

            Name.Text = dataSet.Tables[0].Rows[0]["name"].ToString();
            Email.Text = dataSet.Tables[0].Rows[0]["email"].ToString();
            UserType.SelectedIndex = (int)dataSet.Tables[0].Rows[0]["user_type"];
        }

        protected void UpdateUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string updateQry = "UPDATE [users] SET name=@name, user_type=@user_type WHERE id=@id";
                SqlCommand updateCmd = new SqlCommand(updateQry, con);
                updateCmd.Parameters.AddWithValue("@name", Name.Text.ToString());
                updateCmd.Parameters.AddWithValue("@user_type", UserType.SelectedIndex);
                updateCmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                updateCmd.ExecuteNonQuery();
                con.Close();

                SuccessMessage.Text = "User updated successfully!";
                ErrorMessage.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                SuccessMessage.Text = "";
                ErrorMessage.Text = "Something went wrong while updating data";
            }
        }
    }
}