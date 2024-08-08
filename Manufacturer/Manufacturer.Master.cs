using MediConnect.Utils;
using System;

namespace MediConnect.Manufacturer
{
    public partial class Manufacturer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthMiddleware.CheckAuth())
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}