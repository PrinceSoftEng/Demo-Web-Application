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
            <td>Name:
            </td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtName" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Name" ForeColor="Red" ControlToValidate="txtName" /></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>Subject:</td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Enter Subject"
                    ControlToValidate="txtSubject" /></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>Email:</td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            <td>
                <asp:RegularExpressionValidator ID="valRegEx" runat="server" ControlToValidate="txtEmail"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email address." ForeColor="Red" Display="dynamic" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email Is Mandotory"
                    ControlToValidate="txtEmail" ForeColor="Red" />
            </td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td valign="top">Message:</td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtMessage" Rows="5" Columns="40" TextMode="MultiLine" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="Enter Message "
                    ControlToValidate="txtMessage" /></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td></td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="Please select File like .pdf,.png format"
                    ControlToValidate="FileUpload1" /></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td></td>
            <td>
                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="OnSend_Click" /></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green" /></td>
        </tr>
    </table>

</asp:Content>
