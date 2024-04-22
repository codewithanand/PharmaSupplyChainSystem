using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect
{
    public partial class Account : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!AuthMiddleware.CheckAuth())
                {
                    Response.Redirect("Login.aspx");
                }
                string userId = Session["user_id"].ToString();
                BindAccountInformation(userId);
                BindShippingAddress(userId);
            }
        }

        protected void BindAccountInformation(string userId)
        {
            con.Open();
            string getQry = "SELECT * FROM [users] WHERE id=@id";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@id", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            UserNameLabel.Text = ds.Tables[0].Rows[0]["name"].ToString();
            EmailLabel.Text = ds.Tables[0].Rows[0]["email"].ToString();
        }

        protected void BindShippingAddress(string userId)
        {
            con.Open();
            string getQry = "SELECT * FROM [addresses] WHERE user_id=@user_id";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@user_id", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                UpdateAddressButton.Visible = true;
                AddAddressButton.Visible = false;

                NameTextBox.Text = ds.Tables[0].Rows[0]["name"].ToString();
                ContactTextBox.Text = ds.Tables[0].Rows[0]["contact"].ToString();
                StreetTextBox.Text = ds.Tables[0].Rows[0]["street_address"].ToString();
                CountryTextBox.Text = ds.Tables[0].Rows[0]["country"].ToString();
                StateTextBox.Text = ds.Tables[0].Rows[0]["state"].ToString();
                CityTextBox.Text = ds.Tables[0].Rows[0]["city"].ToString();
                PincodeTextBox.Text = ds.Tables[0].Rows[0]["pincode"].ToString();
            }
            else
            {
                UpdateAddressButton.Visible = false;
                AddAddressButton.Visible = true;
            }
        }

        protected void AddAddressButton_Click(object sender, EventArgs e)
        {
            string userId = Session["user_id"].ToString();
            con.Open();
            string insertQry = "INSERT INTO [addresses] (user_id, name, contact, street_address, country, state, city, pincode, created_at, updated_at) VALUES (@user_id, @name, @contact, @street_address, @country, @state, @city, @pincode, @created_at, @updated_at)";
            SqlCommand insertCmd = new SqlCommand(insertQry, con);
            insertCmd.Parameters.AddWithValue("@user_id", userId);
            insertCmd.Parameters.AddWithValue("@name", NameTextBox.Text.ToString());
            insertCmd.Parameters.AddWithValue("@contact", ContactTextBox.Text.ToString());
            insertCmd.Parameters.AddWithValue("@street_address", StreetTextBox.Text.ToString());
            insertCmd.Parameters.AddWithValue("@country", CountryTextBox.Text.ToString());
            insertCmd.Parameters.AddWithValue("@state", StateTextBox.Text.ToString());
            insertCmd.Parameters.AddWithValue("@city", CityTextBox.Text.ToString());
            insertCmd.Parameters.AddWithValue("@pincode", PincodeTextBox.Text.ToString());
            insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            insertCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            insertCmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Account.aspx");
        }

        protected void UpdateAddressButton_Click(object sender, EventArgs e)
        {
            string userId = Session["user_id"].ToString();
            con.Open();
            string updateQry = "UPDATE [addresses] SET name=@name, contact=@contact, street_address=@street_address, country=@country, state=@state, city=@city, updated_at=@updated_at WHERE user_id=@user_id";
            SqlCommand updateCmd = new SqlCommand(updateQry, con);
            updateCmd.Parameters.AddWithValue("@user_id", userId);
            updateCmd.Parameters.AddWithValue("@name", NameTextBox.Text.ToString());
            updateCmd.Parameters.AddWithValue("@contact", ContactTextBox.Text.ToString());
            updateCmd.Parameters.AddWithValue("@street_address", StreetTextBox.Text.ToString());
            updateCmd.Parameters.AddWithValue("@country", CountryTextBox.Text.ToString());
            updateCmd.Parameters.AddWithValue("@state", StateTextBox.Text.ToString());
            updateCmd.Parameters.AddWithValue("@city", CityTextBox.Text.ToString());
            updateCmd.Parameters.AddWithValue("@pincode", PincodeTextBox.Text.ToString());
            updateCmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            updateCmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Account.aspx");
        }
    }
}