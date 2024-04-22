﻿using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class Products : System.Web.UI.Page
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
                    BindProducts();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        protected void BindProducts()
        {
            con.Open();

            string getQuery = "SELECT products.id AS id, products.name AS name, categories.name AS category, customers.name AS owner, products.quantity AS quantity, products.price AS price FROM products INNER JOIN [categories] ON products.category_id = categories.id INNER JOIN [customers] ON products.owner_id = customers.id";
            SqlCommand getCmd = new SqlCommand(getQuery, con);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ProductListView.DataSource = ds;
            ProductListView.DataBind();
            con.Close();
        }
    }
}