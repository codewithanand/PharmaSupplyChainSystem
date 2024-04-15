using MediConnect.Utils;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MediConnect.Admin
{
    public partial class Categories : System.Web.UI.Page
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
                CategoryRowLiteral.Text = string.Empty;
                try
                {
                    BindCategories();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        protected void BindCategories()
        {
            con.Open();
            string getQry = "SELECT * FROM [categories] WHERE deleted_at IS NULL";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            SqlDataReader reader = getCmd.ExecuteReader();
            while (reader.Read())
            {
                CategoryRowLiteral.Text += "<tr>";
                CategoryRowLiteral.Text += "<td>" + reader.GetValue(1) + "</td>";
                CategoryRowLiteral.Text += "<td><img src='../assets/uploads/category/"+ reader.GetValue(3) + "' /></td>";

                CategoryRowLiteral.Text += "<td><a class=\"btn btn-info btn-sm me-2\" href=\"CategoryEdit.aspx?id=" + reader.GetValue(0).ToString() + "\"><i class=\"mdi mdi-lead-pencil\"></i></a><a class=\"btn btn-danger btn-sm\" onclick=\"return confirm('Are you sure want to delete this category?')\" href=\"CategoryDelete.aspx?id=" + reader.GetValue(0).ToString() + "\"><i class=\"mdi mdi-delete\"></i></a></td>";
                CategoryRowLiteral.Text += "</tr>";
            }
            con.Close();
        }
    }
}