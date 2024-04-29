<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MediConnect.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid py-5">
        
    </div>
    <div class="container-fluid callback my-5 pt-5">
        <div class="container pt-5">
            <div class="row justify-content-center">
                <div class="col-lg-7">
                    <div class="bg-white border rounded shadow p-4 p-sm-5 wow fadeInUp" data-wow-delay="0.5s">
                        <div class="text-center mx-auto wow fadeInUp" data-wow-delay="0.1s" style="max-width: 600px;">
                            <p class="d-inline-block border rounded text-primary fw-semi-bold py-1 px-3">
                                Login
                            </p>
                            <h1 class="display-5 mb-5">Welcome back!</h1>
                        </div>
                        <div class="row g-3">
                            <div class="col-12">
                                <div class="form-floating">
                                    <asp:TextBox CssClass="form-control" ID="Email" runat="server" placeholder="Your Email"></asp:TextBox>
                                    <label for="Email">Your Email</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="Email" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="Email" ForeColor="Red" runat="server" ErrorMessage="Not a valid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-floating">
                                    <asp:TextBox CssClass="form-control" ID="Password" runat="server" placeholder="Your Password" TextMode="Password"></asp:TextBox>
                                    <label for="Password">Your Password</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="Password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group d-flex align-items-center justify-content-between">
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="mt-3 mb-3" NavigateUrl="ForgotPassword.aspx">Forgot Password</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="" NavigateUrl="Register.aspx">Don't have an account?</asp:HyperLink>
                            </div>
                            <div class="col-12 text-center">
                                <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="btn btn-primary py-3 px-5" OnClick="LoginButton_Click" />
                                <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="text-center text-danger text-small"></asp:Label>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
