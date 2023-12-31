﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Login.aspx.cs" Inherits="Web_Application_Registration.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body {
            background-color: aqua;
        }

        tbody {
            background-image: url(Css/Supercar.jpg);
            background-size: cover;
        }
    </style>    
    <%--<script type="text/javascript">
        function ValidateLoginCre()
        {
            var username = document.getElementById('txtUsername');
            var password = document.getElementById('txtPassword');
            if ((username.value == ' ') || (password.value == ' ')) {
                alert('Username and Password Cannot be Blank');
            }
            else
            {
                return true;
            }
        }
    </script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="margin: 15% 100% 15% 40%;">
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblUsername" runat="server" Text="UserName:"></asp:Label><span style="color: red">*</span></td>
            <td style="background: transparent; opacity: 0.50;">
                <asp:TextBox ID="txtUsername" placeholder="UserName" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label><span style="color: red">*</span>
            </td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            </td>
            <td style="color:#ffffff">
                <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
                <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"
                    rel="stylesheet" type="text/css" />
                <span id="toggle_pwd" class="fa fa-fw fa-eye field_icon"></span>
                <script type="text/javascript">
                    $(function () {
                        $("#toggle_pwd").click(function () {
                            $(this).toggleClass("fa-eye fa-eye-slash");
                            var type = $(this).hasClass("fa-eye-slash") ? "text" : "password";
                            $("[id*=txtPassword]").attr("type", type);
                        });
                    });
                </script>
            </td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblRemember" runat="server" Text="Remember Me"></asp:Label><span style="color: red">*</span></td>
            <td style="background: transparent; opacity: 0.70">
                <asp:CheckBox ID="chkRemember" runat="server" /></td>
            <td></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<asp:Button ID="btnLogin" class="btn btn-primary  btn-sm" runat="server" Text="Login" OnClientClick="ValidateLoginCre" OnClick="OnLogin_Click" /></td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lnkForgetPassword" OnClick="OnForget_Password">Forget Password?</asp:LinkButton></td>
            <td></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td></td>
            <td>
                <asp:Label ID="lblLoginUp" runat="server" Text="New User? "></asp:Label><a href="Registration.aspx">Register Here</a></td>
            <td></td>
        </tr>
    </table>
</asp:Content>

