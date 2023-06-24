<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Registration.aspx.cs" Inherits="Web_Application_Registration.CS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body {
            background-color: olivedrab;
        }

        tbody {
            background-image: url(Css/Supercar.jpg);
            background-size: cover;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="margin: 2% 25% 2% 25%;">
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblUsername" runat="server" Text="UserName:"></asp:Label><span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.50;">
                <asp:TextBox ID="txtUsername" runat="server" OnTextChanged="txtUserName_TextChange" AutoPostBack="true" ></asp:TextBox>
                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
            <td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red"
                    ControlToValidate="txtUsername" ErrorMessage="UserName Start with letter and length will be 6 to 12.."
                    ValidationExpression="[a-zA-Z0-9]{5,11}"></asp:RegularExpressionValidator></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblFirstname" runat="server" Text="FirstName:"></asp:Label><span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox></td>           
            <td></td>
            
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblMiddlename" runat="server" Text="MiddleName:"></asp:Label><span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtMiddlename" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblLastname" runat="server" Text="LastName:"></asp:Label><span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox></td>
            <td></td>          
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label><span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.70">
                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Transgender</asp:ListItem>
                </asp:RadioButtonList></td>
            <td></td>           
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblMobile" runat="server" Text="Mobile:"></asp:Label><span style="color:red">*</span>
            </td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtMobile" runat="server" TextMode="Phone"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red"
                    ControlToValidate="txtMobile" ErrorMessage="Please Enter 10 Digit Indian Mobile Number."
                    ValidationExpression="[7-9][0-9]{9}"></asp:RegularExpressionValidator></td>           
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label><span style="color:red">*</span>
            </td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." /></td>                       
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td style="vertical-align: top">
                <asp:Label ID="Address" runat="server" Text="Address:"></asp:Label><span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.50; vertical-align: top">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            <td></td>            
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label><span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.70">
                <asp:DropDownList ID="ddlCountry" class="btn btn-primary dropdown-toggle" runat="server" OnSelectedIndexChanged="ddlCountry_OnSelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList></td>
            <td></td>
        </tr>
        <tr>
            <td style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
                <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label><span style="color:red">*</span>
            </td>
            <td style="background: transparent; opacity: 0.70">
                <asp:DropDownList ID="ddlState" class="btn btn-primary dropdown-toggle" runat="server" OnSelectedIndexChanged="ddlState_OnSelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList></td>
            <td></td>
        </tr>
        <tr>
            <td style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
                <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label><span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.70">
                <asp:DropDownList ID="ddlCity" class="btn btn-primary dropdown-toggle" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
            <td></td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label><span style="color:red">*</span>
            </td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Enter Strong Password Using Upper,lower,Number and it Should be between 8 to 15 "
                    ValidationExpression="^.*(?=.{8,15})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$" ForeColor="Red"
                    ControlToValidate="txtPassword"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td>
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label><span style="color:red">*</span></td>
            <td style="background: transparent; opacity: 0.50">
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            <td>
                <asp:CompareValidator ErrorMessage="Passwords does not match." ForeColor="Red" ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmPassword" runat="server" /></td>           
        </tr>
        <tr>
            <td style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">Isactive:<span style="color:red">*</span></td>
            <td  style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
                <asp:CheckBox ID="chkIsActive" runat="server" />User Active Status
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSubmit" class="btn btn-primary  btn-sm" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnCancel" class="btn btn-secondary btn-sm" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
            <td></td>            
        </tr>
        <tr style="background: Transparent; font-variant: small-caps; font-weight: 600; color: orange;">
            <td></td>
            <td>
                <asp:Label ID="lblLoginUp" runat="server" Text="Already Register? "></asp:Label><a href="Login.aspx">Login To Your Profile</a></td>
            <td></td>
        </tr>
    </table>
</asp:Content>
