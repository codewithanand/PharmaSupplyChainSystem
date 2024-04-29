using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class Agents : System.Web.UI.Page
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
            }
            try
            {
                BindAgentListView();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        protected void BindAgentListView()
        {
            con.Open();
            string getQry = "SELECT * FROM [users] WHERE user_type=@user_type";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@user_type", 6);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            AgentListView.DataSource = ds;
            AgentListView.DataBind();
            con.Close();
        }
    }
}