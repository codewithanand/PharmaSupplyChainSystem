<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="EmailNotice.aspx.cs" Inherits="MediConnect.EmailNotice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="patient-area section-padding">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 offset-lg-3">
                    <div class="section-top text-center">
                        <h2>Verify Email</h2>
                    </div>
                </div>
            </div>
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
    </section>
</asp:Content>
