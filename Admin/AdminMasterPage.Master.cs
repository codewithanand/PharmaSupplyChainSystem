using MediConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediConnect.Admin
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!AuthMiddleware.CheckAuth())
                //{
                //    Response.Redirect("~/Login.aspx");
                //}
            }
        }
    }
}