<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="MediConnect.Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Feature Area Starts -->
    <section class="feature-area section-padding">
        <div class="container mb-3">
            <h2 class="mb-3">Latest Products</h2>
            <div class="row">
                <asp:Literal ID="LatestProductsLiteral" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="container">
            <h2 class="mb-3">All Products</h2>
            <div class="row">
                <asp:Literal ID="AllProductsLiteral" runat="server"></asp:Literal>
            </div>
        </div>
    </section>
    <!-- Feature Area End -->
</asp:Content>
