<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="CategoryAdd.aspx.cs" Inherits="MediConnect.Admin.CategoryAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Category</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Add Category
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="card w-100">
        <div class="card-body">
            <div class="d-flex flex-row justify-content-between mb-3">
                <span class="h4">Add New Category</span>
                <a class="btn btn-primary btn-icon-text btn-sm" href="Categories.aspx"><i class="mdi mdi-database btn-icon-prepend"></i>View Categories</a>
            </div>
            <div class="form-group">
                <label for="CategoryTitle">Title</label>
                <asp:TextBox CssClass="form-control" ID="CategoryTitle" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="CategoryTitle">Slug</label>
                <asp:TextBox CssClass="form-control" ID="CategorySlug" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="Image">Cover Image</label>
                <asp:FileUpload CssClass="form-control" ID="Image" runat="server" />
            </div>
            <div class="form-group">
                <asp:Button CssClass="btn btn-primary" ID="CategoryCreateButton" runat="server" Text="Create" OnClick="CategoryCreateButton_Click" />
                <asp:Label CssClass="text-danger text-small" ID="ErrorMessage" runat="server" Text=""></asp:Label>
                <asp:Label CssClass="text-success text-small" ID="SuccessMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
