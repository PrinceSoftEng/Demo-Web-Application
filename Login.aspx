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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="margin: 15% 100% 15% 40%;">
        <tr style="background: Transparent;font-variant: small-caps;font-weight: 600;color: orange;">
            <td>
                <asp:Label ID="lblUsername" runat="server" Text="UserName:"></asp:Label></td>
            <td style="background:transparent;opacity:0.50;">
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
            <td style="font-size: x-small;">
                <asp:RequiredFieldValidator ErrorMessage="UserName Cannot be Empty" ForeColor="Red" ControlToValidate="txtUsername"
                    runat="server" /></td>
        </tr>
        <tr style="background: Transparent;font-variant: small-caps;font-weight: 600;color: orange;">
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            </td>
            <td style="background:transparent;opacity:0.50">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="font-size: x-small;">
                <asp:RequiredFieldValidator ErrorMessage="Password Required" ForeColor="Red" ControlToValidate="txtPassword"
                    runat="server" /></td>
        </tr>
        <tr style="background: Transparent;font-variant: small-caps;font-weight: 600;color: orange;">
            <td></td>
            <td>
                <asp:Button ID="btnLogin" class="btn btn-primary  btn-sm"  runat="server" Text="Login" OnClick="OnLogin_Click" /></td>
            <td></td>
        </tr>
        <tr style="background: Transparent;font-variant: small-caps;font-weight: 600;color: orange;">
            <td></td>
            <td><asp:Label ID="lblLoginUp" runat="server" Text="New User? "></asp:Label><a href="Registration.aspx">Register Here</a></td>
            <td></td>
        </tr>
    </table>
</asp:Content>

