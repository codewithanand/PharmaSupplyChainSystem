using MediConnect.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediConnect.Admin
{
    public partial class UserDelete : System.Web.UI.Page
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
                    con.Open();
                    string deleteQry = "DELETE FROM [users] WHERE id=@id";
                    SqlCommand deleteCmd = new SqlCommand(deleteQry, con);
                    deleteCmd.Parameters.AddWithValue("@id", id);
                    deleteCmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("Users.aspx");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}