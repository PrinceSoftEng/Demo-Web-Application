<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Login.aspx.cs" Inherits="Web_Application_Registration.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body {
            background-color:olivedrab;
        }
        tbody {
            background-image:url(Css/Supercar.jpg);
            background-size:cover;
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
                <asp:Label ID="lblUsername" runat="server" Text="UserName:"></asp:Label><span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.50;">
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr style="background: Transparent;font-variant: small-caps;font-weight: 600;color: orange;">
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label><span style="color:red">*</span>
            </td>
            <td style="background:transparent;opacity:0.50">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr style="background: Transparent;font-variant: small-caps;font-weight: 600;color: orange;">
            <td></td>
            <td><asp:Button ID="btnLogin" class="btn btn-primary  btn-sm"  runat="server" Text="Login" OnClientClick="ValidateLoginCre" OnClick="OnLogin_Click" /></td>
            <td></td>
        </tr>
        <tr style="background: Transparent;font-variant: small-caps;font-weight: 600;color: orange;">
            <td></td>
            <td><asp:Label ID="lblLoginUp" runat="server" Text="New User? "></asp:Label><a href="Registration.aspx">Register Here</a></td>
            <td></td>
        </tr>
    </table>
</asp:Content>

