<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MediConnect.Register" %>

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
                                Register
                       
                            </p>
                            <h1 class="display-5 mb-5">Create an account</h1>
                        </div>
                        <div class="row g-3">
                            <div class="col-12">
                                <div class="form-floating">
                                    <asp:TextBox CssClass="form-control" ID="Name" runat="server" placeholder="Your Name"></asp:TextBox>
                                    <label for="Name">Your Name</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ControlToValidate="Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
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
                            <div class="col-12">
                                <div class="form-floating">
                                    <asp:TextBox CssClass="form-control" ID="PasswordConfirmation" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                    <label for="PasswordConfirmation">Confirm Password</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ControlToValidate="PasswordConfirmation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match" Display="Dynamic" ControlToCompare="Password" ControlToValidate="PasswordConfirmation" ForeColor="Red"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="" NavigateUrl="Login.aspx">Already have an account?</asp:HyperLink>
                            </div>
                            <div class="col-12 text-center">
                                <asp:Button ID="RegisterButton" runat="server" Text="Register" CssClass="btn btn-primary py-3 px-5" OnClick="RegisterButton_Click" />
                                <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="text-center text-danger text-small"></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
