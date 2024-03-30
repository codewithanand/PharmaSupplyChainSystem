using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class CategoryAdd : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (RoleMiddleware.Role() != 1)
                //{
                //    Response.Redirect("~/Unauthorized.aspx");
                //}
                ErrorMessage.Text = "";
                SuccessMessage.Text = "";
            }
        }

        protected void CategoryCreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                CategoryCreateButton.Enabled = false;

                con.Open();
                string insertQry = "INSERT INTO [categories] (name, slug, image, deleted_at, created_at, updated_at) VALUES (@name, @slug, @image, @deleted_at, @created_at, @updated_at)";
                SqlCommand insertCmd = new SqlCommand(insertQry, con);
                insertCmd.Parameters.AddWithValue("@name", CategoryTitle.Text.ToString());
                byte[] image = Image.FileBytes;
                if (image != null && image.Length > 0 )
                {
                    insertCmd.Parameters.AddWithValue("@image", image);
                }
                insertCmd.Parameters.AddWithValue("@slug", TokenGenerator.Slugify(CategorySlug.Text.ToString()));
                insertCmd.Parameters.AddWithValue("@deleted_at", DBNull.Value);
                insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
                insertCmd.ExecuteNonQuery();
                con.Close();

                ErrorMessage.Text = "";
                SuccessMessage.Text = "Category created successfully";
                CategoryCreateButton.Enabled = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ErrorMessage.Text = ex.Message;
                SuccessMessage.Text = "";
                CategoryCreateButton.Enabled = true;
            }
        }
    }
}