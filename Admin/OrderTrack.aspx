<%@ Page Title="Order Tracking - MediConnect" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="OrderTrack.aspx.cs" Inherits="MediConnect.Admin.OrderTrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order Tracking</title>

    <style>
        .checkpoint-container{
            display: flex;
            gap: 20px;
            position: relative;
        }
        .checkpoint{
            position: absolute;
            top: 10px;
            width: 15px;
            height: 15px;
            background-color: white;
            box-shadow: 0 0 0 0 white, 0 0 0 8px #C70039;
        }
        .checkpoint.active{
            background-color: white;
            box-shadow: 0 0 0 0 white, 0 0 0 8px #32CD32;
        }
    </style>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-row justify-content-between mb-3">
                        <span class="h4">Order Tracking</span>
                        <a class="btn btn-primary btn-icon-text btn-sm" href="Orders.aspx"><i class="mdi mdi-database-plus btn-icon-prepend"></i>View Orders</a>
                    </div>
                    <div class="container pt-3">
                        <div class="row">
                            <div class="col-sm-12 col-md-6">
                                <asp:ListView ID="CheckpointListView" runat="server">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-md-12 checkpoint-container mb-4">
                                                <div class="rounded-pill checkpoint 
                                                    <%# Convert.ToBoolean(Eval("is_delivered")) ? 
                                                        "active" : 
                                                        string.Empty %>"
                                                ></div>
                                                <div class="pl-5">
                                                    <h4><%# Eval("name") %></h4>
                                                    <small class="
                                                        <%# Convert.ToBoolean(Eval("is_delivered")) ? 
                                                            "text-success" : 
                                                            "text-danger" %>"
                                                    >
                                                        <%# Convert.ToBoolean(Eval("is_delivered")) ? 
                                                                "Delivered" : 
                                                                "Expected delivery" %> 
                                                        on 
                                                        <%# Convert.ToBoolean(Eval("is_delivered")) ? 
                                                            String.Format("{0:dd-MM-yyyy}", Eval("delivery_date")) : 
                                                            String.Format("{0:dd-MM-yyyy}", Eval("expected_date")) %>
                                                    </small>
                                            
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                            <div class="col-sm-12 col-md-6">
                                <div class="row">
                                    <asp:ListView ID="TransportersListView" runat="server">
                                        <ItemTemplate>
                                            <div class="col-md-12 mb-3 border rounded p-3">
                                                <p>
                                                    <strong><%# Eval("name") %></strong>
                                                    <span><%# Eval("vehicle_no") %></span>
                                                </p>
                                                <p> 
                                                    Dispatching from
                                                    <strong><%# Eval("source") %></strong>
                                                    on <%# Eval("dispatch_date") %>
                                                    
                                                </p>
                                                <p>
                                                    Arrriving
                                                    <strong><%# Eval("destination") %></strong>
                                                    on <%# Eval("delivery_date") %>
                                                </p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
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
