using MediConnect.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediConnect.Admin
{
    public partial class Transporters : System.Web.UI.Page
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
                try
                {
                    BindOwners();
                    BindTransporterListView();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void BindTransporterListView()
        {
            con.Open();
            string getQry = "SELECT transporters.id AS id, transporters.name AS name, transporters.vehicle_no AS vehicle_no, transporters.contact AS contact, users.name AS owner FROM [transporters] INNER JOIN [users] ON transporters.owner_id=users.id WHERE transporters.deleted_at IS NULL";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            TransporterListView.DataSource = ds;
            TransporterListView.DataBind();
            con.Close();
        }

        protected void BindOwners()
        {
            con.Open();
            string getQry = "SELECT * FROM [users] WHERE user_type != 1 AND user_type != 0";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            SqlDataReader reader = getCmd.ExecuteReader();
            OwnerDropDownList.DataSource = reader;
            OwnerDropDownList.DataTextField = "name";
            OwnerDropDownList.DataValueField = "id";
            OwnerDropDownList.DataBind();
            con.Close();
        }

        protected void CreateTransporterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string insertQry = "INSERT INTO [transporters] (owner_id, name, contact, vehicle_no, deleted_at, created_at, updated_at) VALUES (@owner_id, @name, @contact, @vehicle_no, @deleted_at, @created_at, @updated_at)";
                SqlCommand insertCmd = new SqlCommand(insertQry, con);
                insertCmd.Parameters.AddWithValue("@owner_id", OwnerDropDownList.SelectedValue);
                insertCmd.Parameters.AddWithValue("@name", TransporterName.Text.ToString());
                insertCmd.Parameters.AddWithValue("@contact", TransporterContact.Text.ToString());
                insertCmd.Parameters.AddWithValue("@vehicle_no", TransportNo.Text.ToString());
                insertCmd.Parameters.AddWithValue("@deleted_at", DBNull.Value);
                insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
                insertCmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}