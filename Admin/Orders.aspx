<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="MediConnect.Admin.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Orders</title>
    <link href="../assets/admin/datatable/dataTable.bootstrap4.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Orders
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-row justify-content-between mb-3">
                        <span class="h4">Orders</span>
                        <a class="btn btn-primary btn-icon-text btn-sm" href="ProductAdd.aspx"><i class="mdi mdi-database-plus btn-icon-prepend"></i>Add New</a>
                    </div>
                    <div class="table-responsive">
                        <table id="orderDataTable" class="table table-striped mb-3">
                            <thead>
                                <tr>
                                    <th>OrderId</th>
                                    <th>Status</th>
                                    <th>Product</th>
                                    <th>Destination</th>
                                    <th>Order Date</th>
                                    <th>Options</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="OrderListView" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("id") %></td>
                                            <td>
                                                <span class="badge text-white <%# Convert.ToBoolean(Eval("is_delivered")) ? "bg-success" : "bg-danger" %>">
                                                <%# Convert.ToBoolean(Eval("is_delivered")) ? "Delivered" : "Not Delivered" %>
                                                </span>
                                            </td>
                                            <td><%# Eval("product") %></td>
                                            <td><%# Eval("destination") %></td>
                                            <td><%# Eval("order_date") %></td>
                                            <td>
                                                <div class="dropdown">
                                                    <a class="btn btn-outline-dark dropdown-toggle" href="#" data-toggle="dropdown">
                                                        <i class="typcn typcn-cog-outline"></i>
                                                    </a>
                                                    <div class="dropdown-menu dropdown-menu-right navbar-dropdown preview-list" aria-labelledby="accountDropdown">
                                                        <a href="OrderDetails.aspx?orderId=<%# Eval("id") %>" class="dropdown-item preview-item py-3"> View </a>
                                                        <a href="OrderTrack.aspx?orderId=<%# Eval("id") %>" class="dropdown-item preview-item py-3"> Track </a>
                                                        <a href="OrderCheckpoints.aspx?orderId=<%# Eval("id") %>&ownerId=<%# Eval("owner") %>" class="dropdown-item preview-item py-3"> Checkpoints </a>
                                                        <a href="TransportAssign.aspx?orderId=<%# Eval("id") %>&ownerId=<%# Eval("owner") %>" class="dropdown-item preview-item py-3"> Assign Transports </a>
                                                    </div>
                                                </div>
                                            </td>
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
            $('#orderDataTable').DataTable();
        });
    </script>
</asp:Content>
