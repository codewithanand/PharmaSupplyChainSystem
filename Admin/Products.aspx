<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="MediConnect.Admin.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Products</title>
    <link href="../assets/admin/datatable/dataTable.bootstrap4.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Products
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-row justify-content-between mb-3">
                        <span class="h4">Products</span>
                        <a class="btn btn-primary btn-icon-text btn-sm" href="ProductAdd.aspx"><i class="mdi mdi-database-plus btn-icon-prepend"></i>Add New</a>
                    </div>
                    <div class="table-responsive">
                        <table id="productDataTable" class="table table-striped mb-3">
                            <thead>
                                <tr>
                                    <th>Product</th>
                                    <th>Owner</th>
                                    <th>Quantity</th>
                                    <th>Price</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Product Name</td>
                                    <td>XYZ Company</td>
                                    <td>100</td>
                                    <td>1234</td>
                                    <td>
                                        <a class="btn btn-warning btn-sm" href="#"><i class="mdi mdi-pencil-box-outline"></i></a>
                                        <a class="btn btn-danger btn-sm" href="#"><i class="mdi mdi-delete"></i></a>
                                    </td>
                                </tr>
                                <asp:Literal ID="UserRowLiteral" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="server">
    <script src="../assets/admin/datatable/jquery.js"></script>
    <script src="../assets/admin/datatable/dataTable.js"></script>
    <script src="../assets/admin/datatable/dataTable.bootstrap4.js"></script>
    <script>
        $(document).ready(function () {
            $('#productDataTable').DataTable();
        });
    </script>
</asp:Content>
