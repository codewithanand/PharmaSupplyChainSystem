using MediConnect.Utils;
using System;

namespace MediConnect.Admin
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!AuthMiddleware.CheckAuth())
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
    }
}