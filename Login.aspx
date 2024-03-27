<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MediConnect.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="patient-area section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-6 offset-lg-3">
                <div class="section-top text-center">
                    <h2>Welcome back!</h2>
                    <p>We are happy to see you back here.</p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-8 offset-lg-1 align-self-center">
                <div class="appointment-form mt-5 mt-lg-0">
                    <h3 class="mb-5 text-center">Login</h3>
                    <div class="form-group">
                        <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="text-center text-danger text-small"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="Email" runat="server" placeholder="Email Address" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Email Address'" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="EmailValidator" runat="server" ErrorMessage="*Required" ControlToValidate="Email" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EmailCheckValidator" ControlToValidate="Email" ForeColor="Red" runat="server" ErrorMessage="Not a valid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="Password" runat="server" placeholder="Password" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Password'" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ErrorMessage="*Required" ControlToValidate="Password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group d-flex align-items-center justify-content-between">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="mt-3 mb-3 text-white" NavigateUrl="ForgotPassword.aspx">Forgot Password</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="text-white" NavigateUrl="Register.aspx">Don't have an account?</asp:HyperLink>
                    </div>
                    <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="template-btn" OnClick="LoginButton_Click" />
                </div>
            </div>
        </div>
    </div>
</section>
</asp:Content>
