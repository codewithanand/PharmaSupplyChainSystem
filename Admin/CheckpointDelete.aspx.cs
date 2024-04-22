using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class CheckpointDelete : System.Web.UI.Page
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
                if (Request.QueryString["orderId"] == null || Request.QueryString["checkpointId"] == null || Request.QueryString["ownerId"] == null)
                {
                    Response.Redirect("Orders.aspx");
                }
                else
                {
                    string orderId = Request.QueryString["orderId"].ToString();
                    string checkpointId = Request.QueryString["checkpointId"].ToString();
                    string ownerId = Request.QueryString["ownerId"].ToString();
                    DeleteCheckpoint(checkpointId, orderId, ownerId);
                }
            }
        }

        protected void DeleteCheckpoint(string checkpointId, string orderId, string ownerId)
        {
            try
            {
                con.Open();
                string deleteQry = "DELETE FROM [checkpoints] WHERE id=@id";
                SqlCommand deleteCmd = new SqlCommand(deleteQry, con);
                deleteCmd.Parameters.AddWithValue("@id", checkpointId);
                deleteCmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("OrderCheckpoints.aspx?orderId=" + orderId + "&ownerId=" + ownerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            
        }
    }
}