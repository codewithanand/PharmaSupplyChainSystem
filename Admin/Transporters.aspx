<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Transporters.aspx.cs" Inherits="MediConnect.Admin.Transporters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Transporters</title>
    <link href="../assets/admin/datatable/dataTable.bootstrap4.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Transporters
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-row justify-content-between mb-3">
                        <span class="h4">Transporters</span>
                    </div>
                    <div class="p-3 bg-gradient-warning mb-3">
                        <div class="row">
                            <div class="col-md-4 mb-3">
                                <label for="OwnerDropDownList">Owner</label>
                                <asp:DropDownList CssClass="form-control" ID="OwnerDropDownList" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 mb-3">
                                <label for="TransporterName">Name</label>
                                <asp:TextBox CssClass="form-control" ID="TransporterName" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-4 mb-3">
                                <label for="TransporterContact">Contact</label>
                                <asp:TextBox CssClass="form-control" ID="TransporterContact" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-4 mb-3">
                                <label for="TransportNo">Vehicle No</label>
                                <asp:TextBox CssClass="form-control" ID="TransportNo" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-12">
                                <asp:Button CssClass="btn btn-primary" ID="CreateTransporterBtn" runat="server" OnClick="CreateTransporterBtn_Click" Text="Create Transporter" />
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <table id="transporterDataTable" class="table table-striped mb-3">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Owner</th>
                                    <th>Name</th>
                                    <th>Vehicle No</th>
                                    <th>Contact</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="TransporterListView" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("id") %></td>
                                            <td><%# Eval("owner") %></td>
                                            <td><%# Eval("name") %></td>
                                            <td><%# Eval("vehicle_no") %></td>
                                            <td><%# Eval("contact") %></td>
                                            <td>
                                                <a onclick="return confirm('Are you sure want to delete this transporter?')" href="TransporterDelete.aspx?transporterId=<%# Eval("id") %>" class="btn btn-danger">Delete</a>
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
            $('#transporterDataTable').DataTable();
        });
    </script>
</asp:Content>
