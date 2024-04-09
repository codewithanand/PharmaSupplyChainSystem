using MediConnect.Controllers;
using MediConnect.Utils;
using System;
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
                AllProductsLiteral.Text = string.Empty;
                try
                {
                    string latestQry = "SELECT TOP 4 * FROM [products] WHERE deleted_at IS NULL ORDER BY id DESC";
                    BindProducts(latestQry, LatestProductsLiteral);

                    string allQry = "SELECT * FROM [products] WHERE deleted_at IS NULL ORDER BY NEWID()";
                    BindProducts(allQry, AllProductsLiteral);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }

        protected void BindProducts(string qry, Literal literal)
        {
            con.Open();
            string getQry = qry;
            SqlCommand getCmd = new SqlCommand(getQry, con);    
            SqlDataReader reader = getCmd.ExecuteReader();
            while(reader.Read())
            {
                int productId = Convert.ToInt32(reader.GetValue(0).ToString());
                literal.Text += "<div class=\"col-sm-12 col-md-4 col-lg-3 mb-3 \">";
                literal.Text += "<div class=\"card\">";
                literal.Text += "<img src=\"assets/uploads/product/"+reader.GetValue(7).ToString()+"\" />";
                literal.Text += "<div class=\"card-body\">";
                literal.Text += "<h3 class=\"card-title\"><a href=\"Product.aspx?"+reader.GetValue(3)+"\">"+reader.GetValue(2)+"</a></h3>";
                literal.Text += "<p class=\"card-text\">$ "+reader.GetValue(6)+"</p>";
                int items = (int)reader.GetValue(5);
                if(items > 0)
                {
                    literal.Text += "<a href=\"AddToCart.aspx?product="+productId+"&quantity=1\" class=\"btn btn-dark me-2\"><i class=\"mdi mdi-cart-outline\"></i>Add to cart</a>";
                }
                else
                {
                    literal.Text += "<p class=\"text-danger\">Out of stock</p>";
                }
                literal.Text += "</div>";
                literal.Text += "</div>";
                literal.Text += "</div>";
            }
            con.Close();
        }
    }
}