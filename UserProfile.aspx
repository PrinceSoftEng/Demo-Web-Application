<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Web_Application_Registration.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h5>Hello <asp:Label ID="lblUserHead" runat="server"></asp:Label></h5>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100 px" src="Images/UserProfile.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <b>
                                    <asp:Label ID="lblUserID" runat="server" Visible="false" Text='<%#Eval("UserId") %>'></asp:Label>
                                    <asp:Label ID="lblFirstName" runat="server" Text="FirstName"></asp:Label></b>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="txtFirstName" runat="server" placeholder="First Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <b>
                                    <asp:Label ID="lblMiddleName" runat="server" Text="MiddleName"></asp:Label></b>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtMiddeName" runat="server" placeholder="Middle Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <b>
                                    <asp:Label ID="lblLastName" runat="server" Text="LastName"></asp:Label></b>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtLastName" runat="server" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <b><asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label></b>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtMobile" runat="server" placeholder="Mobile"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <b><asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></b>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <b><asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label></b>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server" placeholder="Address"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <b><asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label></b>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtCountry" runat="server" placeholder="Country"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <b><asp:Label ID="lblState" runat="server" Text="State"></asp:Label></b>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtState" runat="server" placeholder="State"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <b><asp:Label ID="lblCity" runat="server" Text="City"></asp:Label></b>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtCity" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="btnUpdate" class="btn btn-lg btn-success" runat="server" Text="Update" OnClick="Update_UserData" />
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Home.aspx"><< Back to Home</a><br>
                <br>
            </div>
        </div>
    </div>
</asp:Content>
