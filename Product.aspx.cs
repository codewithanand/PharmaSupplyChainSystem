using MediConnect.Utils;
using System;
using System.Data.SqlClient;
using System.Data;

namespace MediConnect
{
    public partial class Product : System.Web.UI.Page
    {
        SqlConnection con = Connection.Connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string id = Request.QueryString["id"].ToString();
                    BindProduct(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        protected void BindProduct(string id)
        {
            con.Open();
            string getQry = "SELECT * FROM [products] WHERE id=@id";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            getCmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ProductImage.ImageUrl = "assets/uploads/product/"+ds.Tables[0].Rows[0]["image"].ToString();
            ProductTitle.Text = ds.Tables[0].Rows[0]["name"].ToString();
            ProductDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
            ProductPrice.Text = ds.Tables[0].Rows[0]["price"].ToString();
            con.Close();
        }

        protected void AddToCartBtn_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            string quantity = ProductQuantity.Text.ToString();
            Response.Redirect("AddToCart.aspx?product=" + id + "&quantity=" + quantity);
        }
    }
}