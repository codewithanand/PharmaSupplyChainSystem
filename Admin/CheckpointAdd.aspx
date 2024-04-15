<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="CheckpointAdd.aspx.cs" Inherits="MediConnect.Admin.CheckpointAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Checkpoint</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
    Add Checkpoint
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card w-100">
            <div class="card-body">
                <div class="d-flex flex-row justify-content-between mb-3">
                    <span class="h4">Add New Checkpoint</span>
                    <a class="btn btn-primary btn-icon-text btn-sm" href="Checkpoints.aspx"><i class="mdi mdi-database btn-icon-prepend"></i>View Checkpoints</a>
                </div>
                <div class="form-group">
                    <label for="OwnerDropDownList">Owner</label>
                    <asp:DropDownList CssClass="form-control" ID="OwnerDropDownList" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="OrderId">Order Id</label>
                    <asp:TextBox CssClass="form-control" ID="OrderId" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="CheckpointName">Checkpoint Name</label>
                    <asp:TextBox CssClass="form-control" ID="CheckpointName" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ExpectedDate">Expected Date</label>
                    <asp:TextBox CssClass="form-control" ID="ExpectedDate" runat="server" placeholder="dd-MM-yyyy"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button CssClass="btn btn-primary" ID="CreateCheckpointBtn" OnClick="CreateCheckpointBtn_Click" runat="server" Text="Create Checkpoint" />
                    <asp:Label CssClass="text-danger text-small" ID="ErrorMessage" runat="server" Text=""></asp:Label>
                    <asp:Label CssClass="text-success text-small" ID="SuccessMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="server">
   
</asp:Content>
