<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Unauthorized.aspx.cs" Inherits="MediConnect.Unauthorized" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="patient-area section-padding">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 offset-lg-3">
                    <div class="section-top text-center">
                        <h2>Unauthorized Access</h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 align-self-center text-center">
                    <p>You are not authorized to access the intended page. Please log in with the authorized credentials.</p>
                    <div>
                        <a href="Home.aspx" class="btn btn-dark text-white me-2">Home</a>
                        <a href="Login.aspx" class="btn btn-dark text-white">Login</a>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
