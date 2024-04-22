using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MediConnect
{
    public partial class Shop : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string latestQry = "SELECT TOP 4 * FROM [products] WHERE deleted_at IS NULL ORDER BY id DESC";
                    BindProductListView(latestQry, LatestProductListView);

                    string allQry = "SELECT * FROM [products] WHERE deleted_at IS NULL ORDER BY NEWID()";
                    BindProductListView(allQry, ProductListView);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }

        protected void BindProductListView(string qry, ListView listView)
        {
            con.Open();
            string getQry = qry;
            SqlCommand getCmd = new SqlCommand(getQry, con);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            listView.DataSource = ds;
            listView.DataBind();
            con.Close();
        }
    }
}