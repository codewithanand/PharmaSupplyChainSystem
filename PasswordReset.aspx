﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="MediConnect.PasswordReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="patient-area section-padding">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 offset-lg-3">
                    <div class="section-top text-center">
                        <h2>Reset Password</h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 align-self-center">
                    <div class="card shadow p-4">
                        <div class="form-group mb-3">
                            <label for="Password">New Password</label>
                            <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ErrorMessage="*Required" ControlToValidate="Password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group mb-3">
                            <label for="PasswordConfirmation">Confirm Password</label>
                            <asp:TextBox ID="PasswordConfirmation" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordConfirmationValidator" runat="server" ErrorMessage="*Required" ControlToValidate="PasswordConfirmation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="ComparePasswordValidator" runat="server" ErrorMessage="Passwords do not match" Display="Dynamic" ControlToCompare="Password" ControlToValidate="PasswordConfirmation" ForeColor="Red"></asp:CompareValidator>
                        </div>
                        <div>
                            <asp:Button ID="ResetButton" runat="server" Text="Reset" CssClass="btn btn-dark w-25" OnClick="ResetButton_Click" />
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