using MediConnect.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediConnect.Admin
{
    public partial class OrderTrack : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCheckpointListView();
        }

        protected void BindCheckpointListView()
        {
            con.Open();
            string getQry = "SELECT * FROM [checkpoints] WHERE order_id='1002'";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            CheckpointListView.DataSource = ds;
            CheckpointListView.DataBind();
            con.Close();
        }
    }
}