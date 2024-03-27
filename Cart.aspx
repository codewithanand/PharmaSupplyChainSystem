<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="MediConnect.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="patient-area section-padding">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="mb-5">
                        <h1 style="font-size: 2.5rem !important;" class="pb-3">Shopping Cart</h1>
                    </div>
                    <%
                        bool isCartEmpty = true;
                        if (isCartEmpty == true)
                        {
                            Response.Write("<div class=\"container mb-3 p-5\"><div class=\"d-flex flex-column align-items-center justify-content-center\"><i style=\"font-size: 90px;\" class=\"mdi mdi-cart-outline\"></i><h2 class=\"text-mute\">Cart is empty</h2><a href=\"Shop.aspx\" class=\"btn btn-dark\">Go to Shop</a></div></div>");
                        }
                        else
                        {
                            for(int i=0; i<3; i++)
                            {
                                Response.Write("<div class=\"row shadow-sm mb-3 p-2\"><div class=\"col-md-4\"><img src=\"\" width=\"100\" height=\"100\" /></div><div class=\"col-md-4\"><h3>My Product</h3><p class=\"text-secondary\">Qty: 4</p></div><div class=\"col-md-4\"><h2>₹ 1234</h2><a href=\"#\" class=\"btn btn-danger\">Cancel Order</a><a href=\"#\" class=\"btn btn-dark\">Place Order</a></div></div>");
                            }
                        }
                    %>
                    <%--<div class="container mb-3 p-5">
                        <div class="d-flex flex-column align-items-center justify-content-center">
                            <i style="font-size: 90px;" class="mdi mdi-cart-outline"></i>
                            <h2 class="text-mute">Cart is empty</h2>
                            <a href="Shop.aspx" class="btn btn-dark">Go to Shop</a>
                        </div>
                    </div>--%>

                    <%--<div class="row shadow-sm mb-3 p-2">
                        <div class="col-md-4">
                            <img src="" width="100" height="100" />
                        </div>
                        <div class="col-md-4">
                            <h3>My Product</h3>
                            <p class="text-secondary">Qty: 4</p>
                        </div>
                        <div class="col-md-4">
                            <h2>₹ 1234</h2>
                            <a href="#" class="btn btn-danger">Cancel Order</a>
                            <a href="#" class="btn btn-dark">Place Order</a>
                        </div>
                    </div>--%>

                </div>
            </div>
        </div>
    </section>
</asp:Content>
