<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Agent.aspx.cs" Inherits="MediConnect.Agent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid py-5">
    </div>
    <div class="container-fluid pt-5">
        <div class="container p-3">
            <div class="row">
                <div class="col-md-12 mb-3">
                    <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox CssClass="form-control" ID="OrderId" runat="server" placeholder="Order Id"></asp:TextBox>
                            <asp:Button CssClass="btn btn-dark" ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
                        </div>
                    </div>
                </div>
                <asp:PlaceHolder ID="DetailsPlaceHolder" runat="server">
                    <div class="col-md-12 mb-3">
                        <div class="form-group">
                            <asp:DropDownList CssClass="form-control" ID="CheckPointDropDownList" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-12 mb-3">
                        <div class="form-floating">
                            <asp:TextBox CssClass="form-control" ID="Address" runat="server" placeholder="Address"></asp:TextBox>
                            <label for="Address">Recieving Address</label>
                        </div>
                    </div>
                    <div class="col-md-12 mb-3">
                        <div class="form-floating">
                            <asp:TextBox CssClass="form-control" ID="Remarks" runat="server" TextMode="MultiLine" placeholder="Remarks"></asp:TextBox>
                            <label for="Remarks">Remarks</label>
                        </div>
                    </div>
                    <div class="col-md-12 mb-3">
                        <div class="d-flex align-items-center gap-3 border rounded py-3">
                            <asp:CheckBox CssClass="form-check" ID="LastDeliveryCheckBox" runat="server" />
                            <label for="LastDeliveryCheckBox">Is this the last delivery?</label>
                        </div>
                    </div>
                    <div class="col-md-12 mb-3">
                        <div class="form-group">
                            <asp:Button CssClass="btn btn-success px-5 py-2" ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
                        </div>
                    </div>
                </asp:PlaceHolder>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
