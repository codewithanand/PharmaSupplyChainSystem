using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MediConnect.Admin
{
    public partial class ProductAdd : System.Web.UI.Page
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
                try
                {
                    BindSuppliers();
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = ex.Message.ToString();
                    SuccessMessage.Text = string.Empty;
                }
                try
                {
                    BindCategories();
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = ex.Message.ToString();
                    SuccessMessage.Text = string.Empty;
                }
            }
        }

        protected void BindSuppliers()
        {
            con.Open();
            string getQry = "SELECT * FROM [manufacturers] WHERE deleted_at IS NULL";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            SqlDataReader reader = getCmd.ExecuteReader();
            Supplier.DataSource = reader;
            Supplier.Items.Clear();
            Supplier.DataTextField = "name";
            Supplier.DataValueField = "id";
            Supplier.DataBind();
            con.Close();
        }

        protected void BindCategories()
        {
            con.Open();
            string getQry = "SELECT * FROM [categories] WHERE deleted_at IS NULL";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            SqlDataReader reader = getCmd.ExecuteReader();
            Category.DataSource = reader;
            Category.Items.Clear();
            Category.DataTextField = "name";
            Category.DataValueField = "id";
            Category.DataBind();
            con.Close();
        }

        protected void CreateProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateProduct();

                ErrorMessage.Text = string.Empty;
                SuccessMessage.Text = "Product created successfully.";
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
                SuccessMessage.Text = string.Empty;
            }
        }

        protected void CreateProduct()
        {
            con.Open();
            string insertQry = "INSERT INTO [products] (name, product_uid, slug, description, quantity, price, expiry_date, image, category_id, manufacturer_id, deleted_at, created_at, updated_at) VALUES (@name, @product_uid, @slug, @description, @quantity, @price, @expiry_date, @image, @category_id, @manufacturer_id, @deleted_at, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@name", ProductTitle.Text.ToString());
            insertCmd.Parameters.AddWithValue("@product_uid", ProductUID.Text.ToString());
            insertCmd.Parameters.AddWithValue("@slug", TextFormatter.Slugify(ProductTitle.Text.ToString()));
            insertCmd.Parameters.AddWithValue("@description", Description.Text.ToString());
            insertCmd.Parameters.AddWithValue("@quantity", Quantity.Text.ToString());
            insertCmd.Parameters.AddWithValue("@price", Price.Text.ToString());
            try
            {
                insertCmd.Parameters.AddWithValue("@expiry_date", TextFormatter.ConvertTextToDate(ExpiryDate.Text.ToString()));
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
                SuccessMessage.Text = string.Empty;
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
            string filePath = Server.MapPath("~/assets/uploads/product/") + fileName;
            Image.SaveAs(filePath);
            insertCmd.Parameters.AddWithValue("@image", fileName);

            insertCmd.Parameters.AddWithValue("@category_id", Category.SelectedValue);
            insertCmd.Parameters.AddWithValue("@manufacturer_id", Supplier.SelectedValue);
            insertCmd.Parameters.AddWithValue("@deleted_at", DBNull.Value);
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);

            insertCmd.ExecuteNonQuery();
            con.Close();
        }
    }
}