<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Login.aspx.cs" Inherits="Web_Application_Registration.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Css/RegisNLogin.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="margin: 25% 25% 25% 25%;">
        <tr>
            <td>
                <asp:Label ID="lblUsername" runat="server" Text="UserName:"></asp:Label></td>
            <td style="background:transparent;opacity:0.1;">
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="UserName Cannot be Empty" ForeColor="Red" ControlToValidate="txtUsername"
                    runat="server" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            </td>
            <td style="background:transparent;opacity:0.1">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="Password Required" ForeColor="Red" ControlToValidate="txtPassword"
                    runat="server" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnLogin" class="btn btn-primary  btn-sm"  runat="server" Text="Login" OnClick="OnLogin_Click" /></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Label ID="lblLoginUp" runat="server" Text="New User? "></asp:Label><a href="Registration.aspx">Register</a></td>
        </tr>
    </table>
</asp:Content>

