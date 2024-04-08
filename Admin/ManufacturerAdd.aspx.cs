using MediConnect.Utils;
using System;
using System.Data.SqlClient;
using System.IO;

namespace MediConnect.Admin
{
    public partial class ManufacturerAdd : System.Web.UI.Page
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
                ErrorMessage.Text = string.Empty;
                SuccessMessage.Text = string.Empty;
            }
        }

        protected void CreateManufacturerButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateManufacturer();

                ErrorMessage.Text = string.Empty;
                SuccessMessage.Text = "Manufacturer created successfully.";
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString() ;
                SuccessMessage.Text = string.Empty;
            }
        }

        protected void CreateManufacturer()
        {
            con.Open();
            string insertQry = "INSERT INTO [manufacturers] (name, slug, address, contact, image, deleted_at, created_at, updated_at) VALUES (@name, @slug, @address, @contact, @image, @deleted_at, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@name", Name.Text.ToString());
            insertCmd.Parameters.AddWithValue("@slug", TextFormatter.Slugify(Name.Text.ToString()));
            insertCmd.Parameters.AddWithValue("@address", Address.Text.ToString());
            insertCmd.Parameters.AddWithValue("@contact", Contact.Text.ToString());

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
            string filePath = Server.MapPath("~/assets/uploads/manufacturer/") + fileName;
            Image.SaveAs(filePath);
            insertCmd.Parameters.AddWithValue("@image", fileName);

            insertCmd.Parameters.AddWithValue("@deleted_at", DBNull.Value);
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);

            insertCmd.ExecuteNonQuery();
            con.Close();
        }
    }
}