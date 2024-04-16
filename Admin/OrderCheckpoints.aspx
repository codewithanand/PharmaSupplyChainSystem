<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="OrderCheckpoints.aspx.cs" Inherits="MediConnect.Admin.OrderCheckpoints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order Checkpoints</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Order Checkpoints
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-row justify-content-between mb-3">
                        <span class="h4">Order Checkpoints</span>
                        <a class="btn btn-primary btn-icon-text btn-sm" href="Orders.aspx"><i class="mdi mdi-database-plus btn-icon-prepend"></i>View Orders</a>
                    </div>
                    <asp:ListView ID="CheckpointsListView" runat="server">
                        <ItemTemplate>
                            <div class="border p-3 mb-3">
                                <div class="row">
                                    <div class="col-md-4">
                                        <label>Checkpoint Name</label>
                                        <label class="form-control"><%# Eval("name") %></label>
                                    </div>
                                    <div class="col-md-4">
                                        <label>Expected Date</label>
                                        <label class="form-control"><%# String.Format("{0:dd-MM-yyyy}", Eval("expected_date")) %></label>
                                    </div>
                                    <div class="col-md-4 d-flex align-items-center justify-content-end">
                                        <a onclick="return confirm('Are you sure want to delete this checkpoint?')" href="CheckpointDelete.aspx?orderId=<%# Eval("order_id") %>&checkpointId=<%# Eval("id") %>" class="btn btn-danger">Delete</a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <div class="p-3 bg-gradient-warning">
                        <div class="row">
                            <div class="col-md-4 mb-3">
                                <label for="OwnerDropDownList">Owner</label>
                                <asp:DropDownList CssClass="form-control" ID="OwnerDropDownList" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 mb-3">
                                <label for="CheckpointName">Checkpoint Name</label>
                                <asp:TextBox CssClass="form-control" ID="CheckpointName" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-4 mb-3">
                                <label for="ExpectedDate">Expected Date</label>
                                <asp:TextBox CssClass="form-control" ID="ExpectedDate" runat="server" placeholder="dd-MM-yyyy"></asp:TextBox>
                            </div>
                            <div class="col-md-12">
                                <asp:Button CssClass="btn btn-primary" ID="CreateCheckpointBtn" OnClick="CreateCheckpointBtn_Click" runat="server" Text="Create Checkpoint" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="server">

</asp:Content>
