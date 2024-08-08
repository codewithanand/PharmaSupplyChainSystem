<%@ Page Title="Order Details - MediConnect" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="MediConnect.Admin.OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/admin/datatable/dataTable.bootstrap4.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-row justify-content-between">
                        <span class="h4">Order Details</span>
                        <a class="btn btn-primary btn-icon-text btn-sm" href="Orders.aspx"><i class="mdi mdi-database-plus btn-icon-prepend"></i>View Orders</a>
                    </div>
                    <div class="mt-3">
                        <div class="row border p-3">
                            <div class="col-12 mb-3">
                                <h4>User Information</h4>
                            </div>
                            <div class="col-md-4 mb-3">
                                <strong>Name</strong>:
                                <span>
                                    <asp:Label ID="UserName" runat="server" Text="Label"></asp:Label>
                                </span>
                            </div>
                            <div class="col-md-4">
                                <strong>Contact</strong>:
                                <span>
                                    <asp:Label ID="Contact" runat="server" Text="Label"></asp:Label>
                                </span>
                            </div>
                            <div class="col-md-4">
                                <p>
                                    <asp:Label ID="Address" runat="server" Text="Label"></asp:Label>
                                </p>
                            </div>
                            
                            <div class="col-md-4">
                                <strong>Ordered Date</strong>:
                                <span>
                                    <asp:Label ID="OrderDate" runat="server" Text="Label"></asp:Label>
                                </span>
                            </div>
                            <div class="col-md-4">
                                <strong>Delivery Date</strong>:
                                <span>
                                    <asp:Label ID="DeliveryDate" runat="server" Text="Label"></asp:Label>
                                </span>
                            </div>
                        </div>
                        <div class="row border p-3 mt-3">
                            <div class="col-12 mb-3">
                                <h4>Orders</h4>
                            </div>
                            <div class="col-md-4 mb-3">
                                <strong>OrderId</strong>:
                                <span>#<asp:Label ID="OrderId" runat="server" Text="Label"></asp:Label></span>
                            </div>
                            <div class="col-md-4">
                                <strong>Product</strong>:
                                <span>
                                    <asp:Label ID="ProductName" runat="server" Text="Label"></asp:Label>
                                </span>
                            </div>
                            <div class="col-md-4">
                                <strong>Quantity</strong>:
                                <span>
                                    <asp:Label ID="Quantity" runat="server" Text="Label"></asp:Label>
                                </span>
                            </div>
                            <div class="col-md-4">
                                <strong>TransactionId</strong>:
                                <span>
                                    <asp:Label ID="TransactionId" runat="server" Text="Label"></asp:Label>
                                </span>
                            </div>
                        </div>
                        <div class="row border p-3 mt-3">
                            <div class="col-12 mb-3">
                                <h4>Item Information</h4>
                            </div>
                            <div class="table-responsive">
                                <table class="table table-striped" id="itemInfoDataTable">
                                    <thead>
                                        <tr>
                                            <th>ProductUid</th>
                                            <th>Manufacturer</th>
                                            <th>Manufacturing Date</th>
                                            <th>Expiry Date</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView ID="ItemInfoListView" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>#<%# Eval("product_uid") %></td>
                                                    <td><%# Eval("owner") %></td>
                                                    <td><%# Eval("manufacturing_date") %></td>
                                                    <td><%# Eval("expiry_date") %></td>
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
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="server">
    <script src="../assets/admin/datatable/jquery.js"></script>
    <script src="../assets/admin/datatable/dataTable.js"></script>
    <script src="../assets/admin/datatable/dataTable.bootstrap4.js"></script>
    <script>
        $(document).ready(function () {
            $('#itemInfoDataTable').DataTable();
        });
    </script>
</asp:Content>
