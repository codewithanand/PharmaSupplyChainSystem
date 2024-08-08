using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MediConnect.Manufacturer
{
    public partial class ProductAdd : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (RoleMiddleware.Role() != 3)
                {
                    Response.Redirect("~/Unauthorized.aspx");
                }
                ErrorMessage.Text = string.Empty;
                SuccessMessage.Text = string.Empty;
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
            string userId = Session["user_id"].ToString();
            string customerId = GetCustomerId(userId);

            con.Open();
            string insertQry = "INSERT INTO [products] (name, slug, description, quantity, price, manufacturing_date, expiry_date, image, category_id, owner_id, deleted_at, created_at, updated_at) VALUES (@name, @slug, @description, @quantity, @price, @manufacturing_date, @expiry_date, @image, @category_id, @owner_id, @deleted_at, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@name", ProductTitle.Text.ToString());
            insertCmd.Parameters.AddWithValue("@slug", TextFormatter.Slugify(ProductTitle.Text.ToString()));
            insertCmd.Parameters.AddWithValue("@description", Description.Text.ToString());
            insertCmd.Parameters.AddWithValue("@quantity", Quantity.Text.ToString());
            insertCmd.Parameters.AddWithValue("@price", Price.Text.ToString());

            insertCmd.Parameters.AddWithValue("@manufacturing_date", ManufacturingDate.Text);
            insertCmd.Parameters.AddWithValue("@expiry_date", ExpiryDate.Text);

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
            string filePath = Server.MapPath("~/assets/uploads/product/") + fileName;
            Image.SaveAs(filePath);
            insertCmd.Parameters.AddWithValue("@image", fileName);

            insertCmd.Parameters.AddWithValue("@category_id", Category.SelectedValue);
            insertCmd.Parameters.AddWithValue("@owner_id", customerId);
            insertCmd.Parameters.AddWithValue("@deleted_at", DBNull.Value);
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);

            insertCmd.ExecuteNonQuery();
            con.Close();
        }

        protected string GetCustomerId(string userId)
        {
            con.Open();
            string getQuery = "SELECT * FROM [customers] WHERE user_id=@user_id";
            SqlCommand getCmd = new SqlCommand(getQuery, con);
            getCmd.Parameters.AddWithValue("@user_id", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            return ds.Tables[0].Rows[0]["id"].ToString();
        }
    }
}