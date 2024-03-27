<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ProductAdd.aspx.cs" Inherits="MediConnect.Admin.ProductAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Product</title>
    <link href="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Add Product
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card w-100">
            <div class="card-body">
                <div class="d-flex flex-row justify-content-between mb-3">
                    <span class="h4">Add New Product</span>
                    <a class="btn btn-primary btn-icon-text btn-sm" href="Products.aspx"><i class="mdi mdi-database btn-icon-prepend"></i>View Products</a>
                </div>
                <div class="form-group">
                    <label for="Owner">Owner</label>
                    <asp:DropDownList CssClass="form-control" ID="Owner" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="Category">Category</label>
                    <asp:DropDownList CssClass="form-control" ID="Category" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="ProductTitle">Title</label>
                    <asp:TextBox CssClass="form-control" ID="ProductTitle" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Description">Description</label>
                    <asp:TextBox CssClass="form-control" ID="Description" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Price">Price</label>
                    <asp:TextBox CssClass="form-control" ID="Price" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Quantity">Quantity</label>
                    <asp:TextBox CssClass="form-control" ID="Quantity" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Image">Cover Image</label>
                    <asp:FileUpload ID="Image" runat="server" />
                </div>
                <div class="form-group">
                    <button class="btn btn-primary">Create</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="server">
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#ContentPlaceHolder1_Description').summernote();
        });

    </script>
</asp:Content>
