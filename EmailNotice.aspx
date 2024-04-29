<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="EmailNotice.aspx.cs" Inherits="MediConnect.EmailNotice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid page-header mb-5 wow fadeIn" data-wow-delay="0.1s">
        <div class="container">
            <h1 class="display-3 mb-4 animated slideInDown">Verify Email</h1>
        </div>
    </div>
    <div class="container-fluid">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 align-self-center">
                    <div class="card shadow p-4">
                        <h3>Check your email account</h3>
                        <p>We have already sent an email activation link to your register email address. Please follow the link in order to activate your account.</p>
                        <div>
                            <asp:Button ID="ResendButton" runat="server" Text="Resend Activation Link" CssClass="btn btn-dark w-25 me-2" OnClick="ResendButton_Click" />
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
    </div>
</asp:Content>
