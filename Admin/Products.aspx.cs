using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class Products : System.Web.UI.Page
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
                ProductRowLiteral.Text += string.Empty;
                try
                {
                    BindProducts();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        protected void BindProducts()
        {
            con.Open();

            string getQuery = "SELECT products.id AS id, products.name AS name, categories.name AS category, manufacturers.name AS owner, products.quantity AS quantity, products.price AS price FROM products INNER JOIN categories ON products.category_id = categories.id INNER JOIN manufacturers ON products.manufacturer_id = manufacturers.id";
            SqlCommand getCmd = new SqlCommand(getQuery, con);
            SqlDataReader reader = getCmd.ExecuteReader();
            while (reader.Read())
            {
                ProductRowLiteral.Text += "<tr>";
                ProductRowLiteral.Text += "<td>" + reader.GetValue(1) + "</td>";
                ProductRowLiteral.Text += "<td>" + reader.GetValue(2) + "</td>";
                ProductRowLiteral.Text += "<td>" + reader.GetValue(3) + "</td>";
                ProductRowLiteral.Text += "<td>" + reader.GetValue(4) + "</td>";
                ProductRowLiteral.Text += "<td>" + reader.GetValue(5) + "</td>";
                ProductRowLiteral.Text += "<td><a class=\"btn btn-info btn-sm me-2\" href=\"ProductEdit.aspx?id=" + reader.GetValue(0).ToString() + "\"><i class=\"mdi mdi-lead-pencil\"></i></a><a class=\"btn btn-danger btn-sm\" onclick=\"return confirm('Are you sure want to delete this user?')\" href=\"ProductDelete.aspx?id=" + reader.GetValue(0).ToString() + "\"><i class=\"mdi mdi-delete\"></i></a></td>";
                ProductRowLiteral.Text += "</tr>";
            }

            con.Close();
        }
    }
}