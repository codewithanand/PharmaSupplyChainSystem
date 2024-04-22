﻿using MediConnect.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MediConnect.Admin
{
    public partial class Orders : System.Web.UI.Page
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
                    BindOrderListView();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void BindOrderListView()
        {
            DataSet orderDataSet = GetOrders();
            OrderListView.DataSource = orderDataSet;
            OrderListView.DataBind();
        }

        protected DataSet GetOrders()
        {
            con.Open();
            string getQry = "SELECT orders.id AS id, customers.id AS owner, products.name AS product, orders.created_at AS order_date, orders.is_delivered AS is_delivered, addresses.city AS destination FROM [orders] INNER JOIN [products] ON products.id=orders.product_id INNER JOIN [customers] ON customers.id=orders.owner_id INNER JOIN [addresses] ON addresses.id=orders.address_id ORDER BY orders.id DESC";
            SqlCommand getCmd = new SqlCommand(getQry, con);
            SqlDataAdapter adapter = new SqlDataAdapter(getCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            return ds;
        }
    }
}