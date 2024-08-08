<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="MediConnect.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid page-header mb-5 wow fadeIn" data-wow-delay="0.1s">
        <div class="container">
            <h1 class="display-3 mb-4 animated slideInDown">Forgot Password?</h1>
            
        </div>
    </div>
    <section class="container-fluid py-5">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 align-self-center">
                    <div class="card shadow p-4">
                        <h3>Enter email address</h3>
                        <p>A password reset link will be sent to this email address once we verify its you.</p>
                        <div class="form-group mb-3">
                            <asp:TextBox ID="Email" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Button ID="SendButton" runat="server" Text="Send" CssClass="btn btn-dark w-25" OnClick="SendButton_Click" />
                                <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                <asp:Label ID="SuccessMessage" runat="server" Text="" CssClass="text-success"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
