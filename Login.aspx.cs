using System;
using System.Data.SqlClient;
using MediConnect.Utils;

namespace MediConnect
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (AuthMiddleware.CheckAuth())
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string getQuery = "SELECT name, email, user_type, is_active, id from [users] WHERE email='"+ Email.Text.ToString() + "' AND password='"+ MyCryptography.MyEncrypt(Password.Text.ToString()) + "'";
                SqlCommand getCmd = new SqlCommand(getQuery, con);
                SqlDataReader reader = getCmd.ExecuteReader();
                
                if (reader.Read())
                {
                    // Setting Session
                    Session.Add("user_id", reader.GetValue(4).ToString());
                    Session.Add("user_name", reader.GetValue(0).ToString());
                    Session.Add("user", reader.GetValue(1).ToString());

                    // Setting Cookies
                    // Auth.attempt(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), (int)reader.GetValue(2));

                    int is_active = (int)reader.GetValue(3);
                    if (is_active == 1)
                    {
                        // Redirecting users to their pages according to their role
                        int role = (int)reader.GetValue(2);
                        con.Close();
                        RedirectRole(role);
                    }
                    else
                    {
                        con.Close();
                        Response.Redirect("EmailNotice.aspx");
                    }
                }
                else
                {
                    con.Close();
                    ErrorMessage.Text = "The credentials you provided is incorrect!";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
            }
        }

        protected void RedirectRole(int role)
        {
            switch (role)
            {
                case 0:
                    Response.Redirect("Home.aspx");
                    break;
                case 1:
                    Response.Redirect("Admin/Dashboard.aspx");
                    break;
                case 2:
                    Response.Redirect("Admin/SupplierDashboard.aspx");
                    break;
                case 3:
                    Response.Redirect("Admin/ManufacturerDashboard.aspx");
                    break;
                case 4:
                    Response.Redirect("Admin/WholesalerDashboard.aspx");
                    break;
                default:
                    Response.Redirect("Home.aspx");
                    break;
            }
        }
    }
}