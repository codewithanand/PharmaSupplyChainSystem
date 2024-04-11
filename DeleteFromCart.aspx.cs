using MediConnect.Utils;
using System;
using System.Data.SqlClient;

namespace MediConnect
{
    public partial class DeleteFromCart : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    string userId = Session["user_id"].ToString();
                    string cartId = Request.QueryString["cart"].ToString();

                    DeleteCart(userId, cartId);
                    Response.Redirect("Cart.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void DeleteCart(string userId, string cartId)
        {
            con.Open();
            string deleteQry = "DELETE FROM [carts] WHERE user_id=@user_id AND id=@id";
            SqlCommand deleteCmd = new SqlCommand(deleteQry, con);
            deleteCmd.Parameters.AddWithValue("@id", cartId);
            deleteCmd.Parameters.AddWithValue("@user_id", userId);
            deleteCmd.ExecuteNonQuery();
            con.Close();
        }
    }
}