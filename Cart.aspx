<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="MediConnect.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="patient-area section-padding">
        <div class="container">
            <div class="row">
                <div class="col-md-9">
                    <div class="mb-5">
                        <h1 style="font-size: 2.5rem !important;" class="pb-3">Shopping Cart</h1>
                    </div>

                    <asp:ListView ID="CartListView" runat="server">
                        <EmptyItemTemplate>
                            <div class="container shadow mb-3 p-5">
                                <div class="d-flex flex-column align-items-center justify-content-center">
                                    <i style="font-size: 40px;" class="fas fa-shopping-cart text-mute"></i>
                                    <h3 style="font-size: 2.3rem">Cart is empty</h3>
                                    <p style="font-size: 1.3rem">Go to Shopping</p>
                                </div>
                            </div>
                        </EmptyItemTemplate>
                        <ItemTemplate>
                            <div class="row border-bottom mb-5 p-2">
                                <div class="col-md-4">
                                    <img src="assets/uploads/product/<%# Eval("image") %>" height="100" />
                                </div>
                                <div class="col-md-4">
                                    <h3><%# Eval("name") %></h3>
                                    <p class="text-secondary">Qty: <%# Eval("product_quantity") %></p>
                                </div>
                                <div class="col-md-4 d-flex justify-content-end">
                                    <div>
                                    <h2>₹ <%# Convert.ToDouble(Eval("price")) * Convert.ToInt32(Eval("product_quantity")) %></h2>
                                    <a href="DeleteFromCart.aspx?cart=<%# Eval("id") %>" class="btn btn-danger">Delete</a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>

                </div>
                <div class="col-md-3">
                    <div class="row mb-3">
                        <div class="col-12">
                            <h3>Shipping Addresses</h3>
                            <hr />
                            <asp:RadioButtonList ID="AddressesRadioButtonList" runat="server">
                                
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <h3>Total <asp:Label ID="TotalCartItems" runat="server" Text="0"></asp:Label> item(s)</h3>
                            <hr />
                            <div class="d-flex justify-content-between">
                                <strong>Subtotal</strong>
                                <span>₹ <asp:Label ID="SubTotalPrice" runat="server" Text="0"></asp:Label></span>
                            </div>
                            <hr />
                            <div class="d-flex justify-content-between mb-3">
                                <strong>Total</strong>
                                <span>₹ <asp:Label ID="TotalPrice" runat="server" Text="0"></asp:Label></span>
                            </div>
                            <asp:LinkButton ID="PlaceOrderBtn" runat="server" OnClick="PlaceOrderBtn_Click" CssClass="btn btn-dark">Place Order</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>



