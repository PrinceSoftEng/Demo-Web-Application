<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ResetPasswordLink.aspx.cs" Inherits="Web_Application_Registration.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1 {
            width:44%
        }
        .style2 {
            width: 128px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table class="style1" align="center">
            <tr>
                <td class="style2">
                    New Password:<span style="color:red">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtNewPass" runat="server" Width="158px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Confirm Password:<span style="color:red">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPass" runat="server" Width="158px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ControlToCompare="txtpwd"
                        ControlToValidate="txtcofrmpwd" ErrorMessage="Password does not match" Font-Names="Rockwell"
                        ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnsubmit" runat="server" class="btn btn-primary  btn-sm" Text="Submit" Width="156px" OnClick="btnsubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
