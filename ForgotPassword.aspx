<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="MediConnect.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="patient-area section-padding">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 offset-lg-3">
                    <div class="section-top text-center">
                        <h2>Forgot Password?</h2>
                    </div>
                </div>
            </div>
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
                            <asp:PlaceHolder ID="ErrorMessagePH" runat="server">
                                <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="SuccessMessagePH" runat="server">
                                <asp:Label ID="SuccessMessage" runat="server" Text="" CssClass="text-success"></asp:Label>
                            </asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
