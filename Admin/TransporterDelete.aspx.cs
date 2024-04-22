using MediConnect.Utils;
using System;
using System.Data.SqlClient;


namespace MediConnect.Admin
{
    public partial class TransporterDelete : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (RoleMiddleware.Role() != 1)
                {
                    Response.Redirect("~/Unauthorized.aspx");
                }
                try
                {
                    string transporterId = Request.QueryString["transporterId"].ToString();
                    DeleteTransporter(transporterId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void DeleteTransporter(string transporterId)
        {
            con.Open();
            string updateQry = "UPDATE [transporters] SET deleted_at=@deleted_at WHERE id=@id";
            SqlCommand updateCmd = new SqlCommand(updateQry, con);
            updateCmd.Parameters.AddWithValue("@id", transporterId);
            updateCmd.Parameters.AddWithValue("@deleted_at", DateTime.Now);
            updateCmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Transporters.aspx");
        }
    }
}