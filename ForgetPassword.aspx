<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="Web_Application_Registration.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body {
            background-color: olivedrab;
        }
        tbody {
            background:linear-gradient(207deg, #ef0685fa, transparent);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="margin: 20% 100% 20% 40%;">
        <tr>
            <td style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">Email:<span style="color:red">*</span></td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">                
                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="OnSendEmail_Click" />&nbsp;&nbsp;
                <asp:LinkButton ID="lnkBackbutton" runat="server" Text="Back to Login" OnClick="OnBackbtn_Click"></asp:LinkButton>
            </td>
            
        </tr>
    </table>
</asp:Content>
