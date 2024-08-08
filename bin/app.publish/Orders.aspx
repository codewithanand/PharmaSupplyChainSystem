<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="MediConnect.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid page-header mb-5 wow fadeIn" data-wow-delay="0.1s">
        <div class="container">
            <h1 class="display-3 mb-4 animated slideInDown">My Orders</h1>
        </div>
    </div>
    <section class="container-fluid pt-5">
        <div class="container">
            <div class="row">
                <asp:ListView ID="OrderListView" runat="server">
                    <ItemTemplate>
                        <div class="container border-bottom mb-3 p-2">
                            <div class="row">
                                <div class="col-md-2">
                                    <img src="assets/uploads/product/<%# Eval("image") %>" alt="" width="200">
                                </div>
                                <div class="col-md-8 col-sm-12">
                                    <h3 class="mb-3"><%# Eval("name") %></h3>
                                    <div class="mb-2">
                                        Quantity:
                                <span><%# Eval("quantity") %></span>
                                    </div>
                                    <div class="mb-2">
                                        Payment Status:
                                        <span>
                                            <%# Convert.ToBoolean(Eval("payment_status")) ? "Paid" : "Not Paid" %>
                                        </span>
                                    </div>
                                    <div class="mb-3">
                                        Delivery Status:
                                        <span>
                                            <%# Convert.ToBoolean(Eval("delivery_status")) ? "Delivered" : "Not Delivered" %>
                                        </span>
                                    </div>
                                    <div>
                                        <a href="#" class="btn btn-outline-primary">Track order</a>
                                    </div>
                                </div>
                                <div class="col-md-2 p-2 col-sm-12">
                                    <h2 class="text-danger price" style="font-size: 2rem !important;">₹ <%# Eval("price") %></h2>
                                    <div class="mb-2">
                                        <a class="btn btn-dark mb-2" href="#">Print Receipt
                                        </a>
                                        <a class="btn btn-danger mb-2" onclick="return confirm('Are you sure want to cancel this order?')" href="#">Cancel Order
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </section>

</asp:Content>
