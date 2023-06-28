<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="ContactUs.aspx.cs" Inherits="Web_Application_Registration.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body {
            background:linear-gradient(40deg, #008075, #d93e0f);
        }
        tbody {
            background-image: url(Css/Supercar.jpg);
            background-size: cover;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="margin: 5% 50% 50% 35%;">
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>Name:<span style="color:red">*</span>
            </td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtName" runat="server" /></td>
            <td></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>Subject:<span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>Email:<span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            <td>
                <asp:RegularExpressionValidator ID="valRegEx" runat="server" ControlToValidate="txtEmail"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email address." ForeColor="Red" Display="dynamic" />                
            </td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td valign="top">Message:<span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtMessage" Rows="5" Columns="40" TextMode="MultiLine" runat="server" /></td>
            <td></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td></td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" /></td>
            <td></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td></td>
            <td>
                <asp:Button ID="btnSend" runat="server" class="btn btn-primary  btn-sm" Text="Send" OnClick="OnSend_Click" /></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green" /></td>
            <td></td>
        </tr>
    </table>

</asp:Content>
