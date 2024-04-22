<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="MediConnect.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Welcome Area Starts -->
    <section class="welcome-area section-padding">
        <div class="container p-3">
            <div class="row">
                <div class="col-md-6 mb-3">
                    <div class="row">
                        <div class="col-12">
                            <h3 class="h3 mb-3">Account Information</h3>
                            <hr />
                            <div class="form-group">
                                <label>Name:</label>
                                <asp:Label CssClass="font-weight-bold" ID="UserNameLabel" runat="server" Text="User Name"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label>Email Address:</label>
                                <asp:Label CssClass="font-weight-bold" ID="EmailLabel" runat="server" Text="email@example.com"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-12">
                            <a href="Cart.aspx" class="text-decoration-none text-white d-flex align-items-center h3 card p-3 bg-info"><i class="mdi mdi-cart"></i> Cart</a>
                        </div>
                        <div class="col-12 mt-3">
                            <a href="Orders.aspx" class="text-decoration-none text-white d-flex align-items-center h3 card p-3 bg-info"><i class="mdi mdi-shopping"></i> Orders</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-12">
                            <h3 class="h3 mb-3">Shipping Address</h3>
                            <hr />
                            <div class="form-group">
                                <label>Full Name</label>
                                <asp:TextBox CssClass="form-control" ID="NameTextBox" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group mt-3">
                                <label>Contact</label>
                                <asp:TextBox CssClass="form-control" ID="ContactTextBox" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group mt-3">
                                <label>Street Address</label>
                                <asp:TextBox CssClass="form-control" ID="StreetTextBox" runat="server"></asp:TextBox>
                            </div>
                            <div class="row mt-3">
                                <div class="col-6 form-group">
                                    <label>Country</label>
                                    <asp:TextBox CssClass="form-control" ID="CountryTextBox" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-6 form-group">
                                    <label>State</label>
                                    <asp:TextBox CssClass="form-control" ID="StateTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-6 form-group">
                                    <label>City</label>
                                    <asp:TextBox CssClass="form-control" ID="CityTextBox" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-6 form-group">
                                    <label>Pincode</label>
                                    <asp:TextBox CssClass="form-control" ID="PincodeTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group mt-3">
                                <asp:Button CssClass="btn btn-dark" ID="AddAddressButton" runat="server" Text="Add Address" OnClick="AddAddressButton_Click" />
                                <asp:Button CssClass="btn btn-dark" ID="UpdateAddressButton" runat="server" Text="Update Address" OnClick="UpdateAddressButton_Click"  />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Patient Area Starts -->
</asp:Content>
