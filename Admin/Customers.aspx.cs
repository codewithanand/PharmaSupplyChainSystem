using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class Customers : System.Web.UI.Page
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
                    BindCutomerListView();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }

        protected void BindCutomerListView()
        {
            con.Open();
            string getQry = "SELECT * FROM [customers] WHERE deleted_at IS NULL";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            CustomerListView.DataSource = ds;
            CustomerListView.DataBind();
            con.Close();
        }
    }
}