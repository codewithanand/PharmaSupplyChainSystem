<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="TransportAssign.aspx.cs" Inherits="MediConnect.Admin.TransportAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Assign Transport</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Assign Transport
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-row justify-content-between mb-3">
                        <span class="h4">Assign Transport</span>
                        <a class="btn btn-primary btn-icon-text btn-sm" href="Orders.aspx"><i class="mdi mdi-database-plus btn-icon-prepend"></i>View Orders</a>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>OrderId</label>
                                <asp:TextBox ID="OrderId" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt-3">
                                <label>Transporter</label>
                                <asp:DropDownList ID="TransporterDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group mt-3">
                                <label>Start Place</label>
                                <asp:TextBox ID="Source" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt-3">
                                <label>Dispatch Date</label>
                                <asp:TextBox ID="DispatchDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="form-group mt-3">
                                <label>Destination Place</label>
                                <asp:TextBox ID="Destination" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt-3">
                                <label>Delivery Date</label>
                                <asp:TextBox ID="DeliveryDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="form-group mt-3">
                                <asp:Button ID="AssignButton" OnClick="AssignButton_Click" CssClass="btn btn-primary" runat="server" Text="Assign Transporter" />
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
