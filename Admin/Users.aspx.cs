using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class Users : System.Web.UI.Page
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
                UserRowLiteral.Text += string.Empty;
                try
                {
                    BindUsers();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
     
        protected void BindUsers()
        {
            con.Open();

            string getQuery = "SELECT id, name, email, user_type FROM [users] WHERE deleted_at IS NULL";
            SqlCommand getCmd = new SqlCommand(getQuery, con);
            SqlDataReader reader = getCmd.ExecuteReader();
            while (reader.Read())
            {
                UserRowLiteral.Text += "<tr>";
                UserRowLiteral.Text += "<td>"+reader.GetValue(0)+"</td>";
                UserRowLiteral.Text += "<td>"+reader.GetValue(1)+"</td>";
                UserRowLiteral.Text += "<td>"+reader.GetValue(2)+"</td>";
                int user_type = (int)reader.GetValue(3);
                if(user_type == 0)
                {
                    UserRowLiteral.Text += "<td><span class=\"badge bg-warning text-white\">consumer</span></td>";
                }
                else if (user_type == 1)
                {
                    UserRowLiteral.Text += "<td><span class=\"badge bg-success text-white\">admin</span></td>";
                }
                else if (user_type == 2)
                {
                    UserRowLiteral.Text += "<td><span class=\"badge bg-primary text-white\">supplier</span></td>";
                }
                else if (user_type == 3)
                {
                    UserRowLiteral.Text += "<td><span class=\"badge bg-primary text-white\">manufacturer</span></td>";
                }
                else if (user_type == 4)
                {
                    UserRowLiteral.Text += "<td><span class=\"badge bg-primary text-white\">wholesaler</span></td>";
                }
                else if (user_type == 5)
                {
                    UserRowLiteral.Text += "<td><span class=\"badge bg-warning text-white\">distributor</span></td>";
                }
                else
                {
                    UserRowLiteral.Text += "<td><span class=\"badge bg-warning text-white\">consumer</span></td>";
                }
                UserRowLiteral.Text += "<td><a class=\"btn btn-info btn-sm me-2\" href=\"UserEdit.aspx?id="+ reader.GetValue(0).ToString() + "\"><i class=\"mdi mdi-lead-pencil\"></i></a><a class=\"btn btn-danger btn-sm\" onclick=\"return confirm('Are you sure want to delete this user?')\" href=\"UserDelete.aspx?id="+ reader.GetValue(0).ToString() + "\"><i class=\"mdi mdi-delete\"></i></a></td>";
                UserRowLiteral.Text += "</tr>";
            }
            
            con.Close();
        }
    }
}