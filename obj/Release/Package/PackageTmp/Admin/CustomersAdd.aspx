﻿<%@ Page Title="Add Customer - MediConnect" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomersAdd.aspx.cs" Inherits="MediConnect.Admin.CustomersAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card w-100">
            <div class="card-body">
                <div class="d-flex flex-row justify-content-between mb-3">
                    <span class="h4">Add New Customer</span>
                    <a class="btn btn-primary btn-icon-text btn-sm" href="Manufacturers.aspx"><i class="mdi mdi-database btn-icon-prepend"></i>View Customers</a>
                </div>
                <div class="form-group">
                    <label for="UserDropDownList">User</label>
                    <asp:DropDownList CssClass="form-control" ID="UserDropDownList" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="Name">Company Name</label>
                    <asp:TextBox CssClass="form-control" ID="Name" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Address">Address</label>
                    <asp:TextBox CssClass="form-control" ID="Address" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Contact">Contact</label>
                    <asp:TextBox CssClass="form-control" ID="Contact" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Image">Cover Image</label>
                    <asp:FileUpload CssClass="form-control" ID="Image" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Button CssClass="btn btn-primary" ID="CreateCustomerButton" OnClick="CreateCustomerButton_Click" runat="server" Text="Create Customer" />
                    <asp:Label CssClass="text-danger text-small" ID="ErrorMessage" runat="server" Text=""></asp:Label>
                    <asp:Label CssClass="text-success text-small" ID="SuccessMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="server">
    
</asp:Content>