using MediConnect.Controllers;
using MediConnect.Utils;
using System;

namespace MediConnect
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!AuthMiddleware.CheckAuth())
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    string userId = Session["user_id"].ToString();
                    int productId = Convert.ToInt32(Request.QueryString["product"].ToString());
                    int quantity = Convert.ToInt32(Request.QueryString["quantity"].ToString());
                    try
                    {
                        CartController.store(userId, productId, quantity);
                        Response.Redirect("Cart.aspx");
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                }
            }
        }
    }
}