<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="MediConnect.Admin.Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Customers</title>
    <link href="../assets/admin/datatable/dataTable.bootstrap4.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Customers
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-row justify-content-between mb-3">
                        <span class="h4">Customers</span>
                        <a class="btn btn-primary btn-icon-text btn-sm" href="CustomersAdd.aspx"><i class="mdi mdi-database-plus btn-icon-prepend"></i>Add New</a>
                    </div>
                    <div class="table-responsive">
                        <table id="customerDataTable" class="table table-striped mb-3">
                            <thead>
                                <tr>
                                    <th>Customer</th>
                                    <th>Address</th>
                                    <th>Contact</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="CustomerListView" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("name") %></td>
                                            <td><%# Eval("address") %></td>
                                            <td><%# Eval("contact") %></td>
                                            <td></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
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
            $('#customerDataTable').DataTable();
        });
    </script>
</asp:Content>
