<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="MediConnect.Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid page-header mb-5 wow fadeIn" data-wow-delay="0.1s">
        <div class="container">
            <h1 class="display-3 mb-4 animated slideInDown">Shop</h1>
            <nav aria-label="breadcrumb animated slideInDown">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Shop</li>
                </ol>
            </nav>
        </div>
    </div>
    <!-- Feature Area Starts -->
    <div class="container py-5">
        <div class="container mb-3">
            <h3 class="mb-3 border-bottom">Latest Products</h3>
            <div class="row">

                <asp:ListView ID="LatestProductListView" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-12 col-md-4 col-lg-3 mb-3">
                            <div class="card">
                                <img src="assets/uploads/product/<%# Eval("image") %>" />
                                <div class="card-body">
                                    <h3 class="card-title"><a class="product-title" href="Product.aspx?id=<%# Eval("id") %>"><%# Eval("name") %></a></h3>
                                    <p class="card-text">₹ <%# Eval("price") %></p>
                                    <a href="AddToCart.aspx?product=<%# Eval("id") %>&quantity=1" class="btn btn-dark me-2"><i class="mdi mdi-cart-outline"></i>Add to cart</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>

            </div>
        </div>
        <div class="container">
            <h3 class="mb-3 border-bottom">All Products</h3>
            <div class="row">

                <asp:ListView ID="ProductListView" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-12 col-md-4 col-lg-3 mb-3">
                            <div class="card">
                                <img src="assets/uploads/product/<%# Eval("image") %>" />
                                <div class="card-body">
                                    <h3 class="card-title"><a class="product-title" href="Product.aspx?id=<%# Eval("id") %>"><%# Eval("name") %></a></h3>
                                    <p class="card-text">₹ <%# Eval("price") %></p>
                                    <a href="AddToCart.aspx?product=<%# Eval("id") %>&quantity=1" class="btn btn-dark me-2"><i class="mdi mdi-cart-outline"></i>Add to cart</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>

            </div>
        </div>
    </div>
    <!-- Feature Area End -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script>
        let productTitles = document.querySelectorAll(".product-title");
        productTitles.forEach(item => {
            let title = item.innerHTML;
            let newTitle = title.slice(0, 30);
            item.innerHTML = newTitle + "...";
        });
    </script>
</asp:Content>
