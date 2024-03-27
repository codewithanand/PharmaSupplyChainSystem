<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MediConnect.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="patient-area section-padding">
    <div class="container">
        <div class="row">
            <div class="col-lg-6 offset-lg-3">
                <div class="section-top text-center">
                    <h2>Welcome!</h2>
                    <p>We are happy that you choose us.</p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-8 offset-lg-1 align-self-center">
                <div class="appointment-form mt-5 mt-lg-0">
                    <h3 class="mb-5 text-center">Register</h3>
                    <div class="form-group">
                        <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="text-center text-danger text-small"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="Name" runat="server" placeholder="Full Name" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Full Name'"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NameValidator" runat="server" ErrorMessage="*Required" ControlToValidate="Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
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
                    <div class="form-group">
                        <asp:TextBox ID="PasswordConfirmation" runat="server" placeholder="Confirm Password" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Confirm Password'" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordConfirmationValidator" runat="server" ErrorMessage="*Required" ControlToValidate="PasswordConfirmation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="ComparePasswordValidator" runat="server" ErrorMessage="Passwords do not match" Display="Dynamic" ControlToCompare="Password" ControlToValidate="PasswordConfirmation" ForeColor="Red"></asp:CompareValidator>
                    </div>
                    <div class="form-group text-center">
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="text-white" NavigateUrl="Login.aspx">Already have an account?</asp:HyperLink>
                    </div>
                    <asp:Button ID="RegisterButton" runat="server" Text="Register" CssClass="template-btn" OnClick="RegisterButton_Click" />
                </div>
            </div>
        </div>
    </div>
</section>
</asp:Content>
