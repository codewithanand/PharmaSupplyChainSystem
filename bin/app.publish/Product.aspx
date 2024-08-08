<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="MediConnect.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid page-header mb-5 wow fadeIn" data-wow-delay="0.1s">
        
    </div>
    <section class="container-fluid pt-5">
        <div class="container pt-5">
            <div class="row">
                <div class="col-md-8">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Image ID="ProductImage" runat="server" Width="100%" />
                        </div>
                        <div class="col-md-8">
                            <h2>
                                <asp:Label ID="ProductTitle" runat="server" Text="Product Title"></asp:Label>
                            </h2>
                            <p>
                                <asp:Label ID="ProductDescription" runat="server" Text="Product Description"></asp:Label>
                            </p>
                            <h3 class="text-danger mb-3">
                                ₹ <asp:Label ID="ProductPrice" runat="server" Text=""></asp:Label>
                            </h3>
                            <p>
                                <asp:TextBox ID="ProductQuantity" runat="server" Text="1" TextMode="Number"></asp:TextBox>
                            </p>
                            <p class="mb-3">
                                <asp:Button CssClass="btn btn-dark" ID="AddToCartBtn" runat="server" Text="Add To Cart" OnClick="AddToCartBtn_Click" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 border-left">
                    <div class="row mb-3">
                        <div class="col-12">
                            <h3>Similar Products</h3>
                        </div>

                    </div>
                    <div class="row mb-3">
                        <div class="col-12">
                            <h3>Popular Products</h3>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
