<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="ActivateAccount.aspx.cs" Inherits="MediConnect.ActivateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="patient-area section-padding">
        <div class="container">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <div class="row">
                    <div class="col-lg-6 offset-lg-3">
                        <div class="section-top text-center">
                            <h2>One more step!</h2>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 align-self-center">
                        <div class="p-4 text-center">
                            <p>Click on the activate button to activate your account.</p>
                            <div>
                                <asp:Button ID="ActivateButton" runat="server" class="btn btn-dark w-25" Text="Activate" OnClick="ActivateButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="SuccessActivation" runat="server">
                <div class="row">
                    <div class="col-lg-6 offset-lg-3">
                        <div class="section-top text-center">
                            <h2 class="text-success">Congratulations!</h2>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 align-self-center">
                        <div class="p-4 text-center">
                            <p>Your email is verified now and you can access your account.</p>
                            <div>
                                <a href="Account.aspx" class="btn btn-dark w-25">Go to account</a>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="ErrorActivation" runat="server">
                <div class="row">
                    <div class="col-lg-6 offset-lg-3">
                        <div class="section-top text-center">
                            <h2 class="text-danger">Activation Failed!</h2>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 align-self-center">
                        <div class="p-4 text-center">
                            <p>Your email is not verified and your account activation is failed.</p>
                            <div>
                                <a href="EmailNotice.aspx" class="btn btn-dark w-25">Try Again</a>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </div>
    </section>
</asp:Content>
