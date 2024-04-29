<%@ Page Title="Edit User - MediConnect" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="MediConnect.Admin.UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="card w-100">
        <div class="card-body">
            <div class="d-flex flex-row justify-content-between mb-3">
                <span class="h4">Edit User</span>
                <a class="btn btn-primary btn-icon-text btn-sm" href="Users.aspx"><i class="mdi mdi-database btn-icon-prepend"></i>View Users</a>
            </div>
            <div class="form-group">
                <label for="Name">Name</label>
                <asp:TextBox CssClass="form-control" ID="Name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger text-small" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="Name" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="Email">Email Address</label>
                <asp:TextBox CssClass="form-control" ID="Email" runat="server" Enabled="false"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger text-small" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="Email" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailCheckValidator" ControlToValidate="Email" CssClass="text-danger text-small" runat="server" ErrorMessage="Not a valid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="UserType">Role</label>
                <asp:DropDownList CssClass="form-control" ID="UserType" runat="server">
                    <asp:ListItem Value="0">Consumer</asp:ListItem>
                    <asp:ListItem Value="1">Admin</asp:ListItem>
                    <asp:ListItem Value="2">Supplier</asp:ListItem>
                    <asp:ListItem Value="3">Manufacturer</asp:ListItem>
                    <asp:ListItem Value="4">Wholesaler</asp:ListItem>
                    <asp:ListItem Value="5">Distributor</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator CssClass="text-danger text-small" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ControlToValidate="UserType" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Button CssClass="btn btn-primary" ID="UpdateUserButton" runat="server" Text="Update" OnClick="UpdateUserButton_Click" />
                <asp:Label CssClass="text-danger text-small" ID="ErrorMessage" runat="server" Text=""></asp:Label>
                <asp:Label CssClass="text-success text-small" ID="SuccessMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
