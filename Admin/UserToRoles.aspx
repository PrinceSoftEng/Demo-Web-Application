<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="UserToRoles.aspx.cs" Inherits="Web_Application_Registration.Roles.UserToRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table {
            padding: 4px;
            margin: 3px;
        }

        th, td {
            padding: 3px;
            margin: 2px;
        }

        .row {
            padding: 4px;
        }

        .lnkButton {
            display: block;
            text-align: center;
            outline: auto;
            outline-color: darkorange;
            background: darkorange;
            font-size: smaller;
        }

            .lnkButton:hover {
                background-color: #e5e124
            }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="column">
            <table style="appearance: auto; border-collapse: separate;">
                <tr>
                    <td><b>Create a New Role</b></td>
                </tr>
                <tr>
                    <td><b>Role Id:</b></td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server" OnTextChanged="txtUserName_TextChange" AutoPostBack="true"></asp:TextBox>
                        <b>
                            <asp:Label ID="lblStatus" runat="server"></asp:Label></b></td>
                </tr>
                <tr>
                    <td><b>Role Name:</b></td>
                    <td>
                        <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSave" class="btn btn-primary  btn-sm" runat="server" Text="Create Role" OnClick="btnSave_Click" />
                        <asp:Button ID="btnDelete" class="btn btn-danger  btn-sm" runat="server" Text="Delete Role" OnClick="btnDelete_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="column" style="appearance: auto; border-collapse: separate; margin: 40px 0px 0px 20px;">
            <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="false" Width="100%">
                <Columns>
                    <asp:BoundField DataField="roleId" HeaderText="Role Id" />
                    <asp:BoundField DataField="roleName" HeaderText="Role Name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div>
        <b>
            <asp:Label ID="lblUsers" runat="server" Text="Select Users:"></asp:Label></b>
        <asp:DropDownList ID="ddlUsers" runat="server" DataTextField="UserName" DataValueField="UserId">
        </asp:DropDownList>
        <script>
            $('#<%=ddlUsers.ClientID%>').chosen();
        </script>
        <br />
        <div style="float: left">
            <b>
                <asp:Label ID="lblRoles" runat="server" Text="Select Roles:"></asp:Label></b>
        </div>
        <div style="float: left; margin: -4px 1000px 0 2px; width: 12%">
            <asp:RadioButtonList ID="rblRoles" runat="server" RepeatColumns="5" RepeatDirection="Vertical"
                DataTextField="roleName" DataValueField="roleId">
            </asp:RadioButtonList>
        </div>
        <div>
            <asp:GridView ID="gvUTR" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:TemplateField HeaderText="UserId" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblUserId" runat="server" Text='<%#Eval("UserId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                    <asp:TemplateField HeaderText="Role Id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblRoleId" runat="server" Text='<%#Eval("roleId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="roleName" HeaderText="Role Name" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblRemove" runat="server" CssClass="lnkButton" Text="Remove" 
                                OnClientClick="return confirm('Are you sure you want to delete this Row?');" OnClick="btnRemove_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary  btn-sm" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
