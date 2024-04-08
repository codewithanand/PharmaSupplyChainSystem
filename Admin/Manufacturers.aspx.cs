using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class Manufacturers : System.Web.UI.Page
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
                ManufacturerRowLiteral.Text += string.Empty;
                try
                {
                    BindManufacturers();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        protected void BindManufacturers()
        {
            con.Open();

            string getQuery = "SELECT * FROM [manufacturers]";
            SqlCommand getCmd = new SqlCommand(getQuery, con);
            SqlDataReader reader = getCmd.ExecuteReader();
            while (reader.Read())
            {
                ManufacturerRowLiteral.Text += "<tr>";
                ManufacturerRowLiteral.Text += "<td>" + reader.GetValue(1) + "</td>";
                ManufacturerRowLiteral.Text += "<td>" + reader.GetValue(3) + "</td>";
                ManufacturerRowLiteral.Text += "<td>" + reader.GetValue(4) + "</td>";
                ManufacturerRowLiteral.Text += "<td><a class=\"btn btn-info btn-sm me-2\" href=\"ManufacturerEdit.aspx?id=" + reader.GetValue(0).ToString() + "\"><i class=\"mdi mdi-lead-pencil\"></i></a><a class=\"btn btn-danger btn-sm\" onclick=\"return confirm('Are you sure want to delete this manufacturer?')\" href=\"ManufacturerDelete.aspx?id=" + reader.GetValue(0).ToString() + "\"><i class=\"mdi mdi-delete\"></i></a></td>";
                ManufacturerRowLiteral.Text += "</tr>";
            }

            con.Close();
        }
    }
}