<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MediConnect.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Dashboard
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div class="col-md-4 grid-margin stretch-card">
            <div class="card bg-gradient-info">
                <div class="card-body">
                    <div class="d-flex align-items-center justify-content-between justify-content-md-center justify-content-xl-between flex-wrap mb-4">
                        <div>
                            <p class="mb-2 text-md-center text-lg-left">Total Users</p>
                            <h1 class="mb-0">
                                <asp:Label ID="TotalUserCount" runat="server" Text="Label"></asp:Label>
                            </h1>
                        </div>
                        <i class="typcn typcn-briefcase icon-xl text-white"></i>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4 grid-margin stretch-card">
            <div class="card bg-gradient-success">
                <div class="card-body">
                    <div class="d-flex align-items-center justify-content-between justify-content-md-center justify-content-xl-between flex-wrap mb-4">
                        <div>
                            <p class="mb-2 text-md-center text-lg-left">Complete Orders</p>
                            <h1 class="mb-0">
                                <asp:Label ID="CompleteOrders" runat="server" Text="Label"></asp:Label>
                            </h1>
                        </div>
                        <i class="typcn typcn-chart-pie icon-xl text-white"></i>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4 grid-margin stretch-card">
            <div class="card bg-gradient-danger">
                <div class="card-body">
                    <div class="d-flex align-items-center justify-content-between justify-content-md-center justify-content-xl-between flex-wrap mb-4">
                        <div>
                            <p class="mb-2 text-md-center text-lg-left">Pending Orders</p>
                            <h1 class="mb-0">
                                <asp:Label ID="PendingOrders" runat="server" Text="Label"></asp:Label>
                            </h1>
                        </div>
                        <i class="typcn typcn-clipboard icon-xl text-white"></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 grid-margin stretch-card">
            <div class="card bg-gradient-warning">
                <div class="card-body">
                    <div class="d-flex align-items-center justify-content-between justify-content-md-center justify-content-xl-between flex-wrap mb-4">
                        <div>
                            <p class="mb-2 text-md-center text-lg-left">Total Manufacturers</p>
                            <h1 class="mb-0">
                                <asp:Label ID="ManufacturerCount" runat="server" Text="Label"></asp:Label>
                            </h1>
                        </div>
                        <i class="typcn typcn-briefcase icon-xl text-white"></i>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4 grid-margin stretch-card">
            <div class="card bg-gradient-warning">
                <div class="card-body">
                    <div class="d-flex align-items-center justify-content-between justify-content-md-center justify-content-xl-between flex-wrap mb-4">
                        <div>
                            <p class="mb-2 text-md-center text-lg-left">Total Agents</p>
                            <h1 class="mb-0">
                                <asp:Label ID="AgentCount" runat="server" Text="Label"></asp:Label>
                            </h1>
                        </div>
                        <i class="typcn typcn-chart-pie icon-xl text-white"></i>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4 grid-margin stretch-card">
            <div class="card bg-gradient-warning">
                <div class="card-body">
                    <div class="d-flex align-items-center justify-content-between justify-content-md-center justify-content-xl-between flex-wrap mb-4">
                        <div>
                            <p class="mb-2 text-md-center text-lg-left">Total Consumers</p>
                            <h1 class="mb-0">
                                <asp:Label ID="ConsumerCount" runat="server" Text="Label"></asp:Label>
                            </h1>
                        </div>
                        <i class="typcn typcn-clipboard icon-xl text-white"></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
    <div class="col-md-4 grid-margin stretch-card">
        <div class="card">
            <div class="card-body">
                <div class="d-flex align-items-center justify-content-between justify-content-md-center justify-content-xl-between flex-wrap mb-4">
                    <div>
                        <p class="mb-2 text-md-center text-lg-left">Total Expenses</p>
                        <h1 class="mb-0">8742</h1>
                    </div>
                    <i class="typcn typcn-briefcase icon-xl text-secondary"></i>
                </div>
                <canvas id="expense-chart" height="80"></canvas>
            </div>
        </div>
    </div>
    <div class="col-md-4 grid-margin stretch-card">
        <div class="card">
            <div class="card-body">
                <div class="d-flex align-items-center justify-content-between justify-content-md-center justify-content-xl-between flex-wrap mb-4">
                    <div>
                        <p class="mb-2 text-md-center text-lg-left">Total Budget</p>
                        <h1 class="mb-0">47,840</h1>
                    </div>
                    <i class="typcn typcn-chart-pie icon-xl text-secondary"></i>
                </div>
                <canvas id="budget-chart" height="80"></canvas>
            </div>
        </div>
    </div>
    <div class="col-md-4 grid-margin stretch-card">
        <div class="card">
            <div class="card-body">
                <div class="d-flex align-items-center justify-content-between justify-content-md-center justify-content-xl-between flex-wrap mb-4">
                    <div>
                        <p class="mb-2 text-md-center text-lg-left">Total Balance</p>
                        <h1 class="mb-0">$7,243</h1>
                    </div>
                    <i class="typcn typcn-clipboard icon-xl text-secondary"></i>
                </div>
                <canvas id="balance-chart" height="80"></canvas>
            </div>
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="server">
    <!-- Custom js for this page-->
    <script src="../assets/admin/js/dashboard.js"></script>
    <!-- End custom js for this page-->
</asp:Content>
