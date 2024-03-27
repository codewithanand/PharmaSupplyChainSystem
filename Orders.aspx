<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="MediConnect.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="patient-area section-padding">
        <div class="container">
            <div class="row">
                <div class="container shadow-sm mb-3 p-2">
                    <div class="row">
                        <div class="col-md-2">
                            <img src="" alt="" width="200">
                        </div>
                        <div class="col-md-8 col-sm-12">
                            <h2 class="mb-3">My Order</h2>
                            <div class="mb-2">
                                Quantity:
                                <span class="badge badge-dark">4</span>
                            </div>
                            <div class="mb-2">
                                Payment Status:
                                <span class="badge badge-success">Paid</span>
                            </div>
                            <div class="mb-3">
                                Delivery Status:
                                <span class="badge badge-danger">In Transit</span>
                            </div>
                        </div>
                        <div class="col-md-2 p-2 col-sm-12">
                            <h2 class="text-danger price" style="font-size: 2rem !important;">₹ 1234</h2>
                            <div class="mb-2">
                                <a class="btn btn-dark mb-2" href="#">Print Receipt
                                </a>
                                <a class="btn btn-danger mb-2" onclick="return confirm('Are you sure want to cancel this order?')" href="#">Cancel Order
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container shadow-sm mb-3 p-2">
                    <div class="row">
                        <div class="col-md-2">
                            <img src="" alt="" width="200">
                        </div>
                        <div class="col-md-8 col-sm-12">
                            <h2 class="mb-3">My Order</h2>
                            <div class="mb-2">
                                Quantity:
                                <span class="badge badge-dark">4</span>
                            </div>
                            <div class="mb-2">
                                Payment Status:
                                <span class="badge badge-success">Paid</span>
                            </div>
                            <div class="mb-3">
                                Delivery Status:
                                <span class="badge badge-success">Delivered</span>
                            </div>
                        </div>
                        <div class="col-md-2 p-2 col-sm-12">
                            <h2 class="text-danger price" style="font-size: 2rem !important;">₹ 1234</h2>
                            <div class="mb-2">
                                <a class="btn btn-dark mb-2" href="#">Print Receipt
                                </a>
                                <a class="btn btn-danger mb-2" onclick="return confirm('Are you sure want to cancel this order?')" href="#">Cancel Order
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
