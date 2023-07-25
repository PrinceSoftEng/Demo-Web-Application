<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="UserToRoles.aspx.cs" Inherits="Web_Application_Registration.Roles.UserToRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table {
            padding:4px;
            margin:3px;
        }
        th, td {
            padding:3px;
            margin:2px;
        }        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td><b>Create a New Role</b></td>
            </tr>
        <tr>
            <td><b>Role Id:</b></td>
            <td><asp:TextBox ID="txtId" runat="server" OnTextChanged="txtUserName_TextChange" AutoPostBack="true"></asp:TextBox>
                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Role Name:</b></td>
            <td><asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnSave" class="btn btn-primary  btn-sm" runat="server" Text="Create Role" OnClick="btnSave_click" />
                <asp:Button ID="btnDelete" class="btn btn-danger  btn-sm" runat="server" Text="Delete Role" OnClick="btnDelete_click" />
            </td>
        </tr>
    </table>
    
    <asp:GridView ID ="gvRoles" runat="server" AutoGenerateColumns="false" Width="25%">
        <Columns>
            <asp:BoundField DataField="roleId" HeaderText="Role Id" />
            <asp:BoundField DataField="roleName" HeaderText="Role Name" />
        </Columns>
    </asp:GridView>
</asp:Content>
