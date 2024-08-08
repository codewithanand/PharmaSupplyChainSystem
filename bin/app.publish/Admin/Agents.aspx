<%@ Page Title="Agents - MediConnect" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Agents.aspx.cs" Inherits="MediConnect.Admin.Agents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/admin/datatable/dataTable.bootstrap4.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-row justify-content-between mb-3">
                        <span class="h4">Agents</span>
                    </div>
                    <div class="table-responsive">
                        <table id="agentsDataTable" class="table table-striped mb-3">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Name</th>
                                    <th>Email</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="AgentListView" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("id") %></td>
                                            <td><%# Eval("name") %></td>
                                            <td><%# Eval("email") %></td>
                                            <td>
                                                <a onclick="return confirm('Are you sure want to delete this agent?')" href="UserDelete.aspx?id=<%# Eval("id") %>" class="btn btn-danger">Delete</a>
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
            $('#agentsDataTable').DataTable();
        });
    </script>
</asp:Content>
