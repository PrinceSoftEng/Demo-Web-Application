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
    </style>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {            
            $("#txtSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: 'POST',
                        url: '~/UserToRoles.aspx/GetRoleNameBySearch',                       
                        dataType: 'json',    
                        data: '{ "searchTerm": "' + request.term + '"}',
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (err) {
                            alert("show error");
                        }
                    });
                },
                minLength: 1 // Minimum characters required to trigger autocomplete
            });
        });
    </script>
    <%--<script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id=txtSearch]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: '<%=ResolveUrl("~/UserToRoles.aspx/GetRolesName") %>',
                        data: '{ "prefixText": "' + request.term + '"}',
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                minLength: 1
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td><b>Create a New Role</b></td>
        </tr>
        <tr>
            <td><b>Role Id:</b></td>
            <td>
                <asp:TextBox ID="txtId" runat="server" OnTextChanged="txtUserName_TextChange" AutoPostBack="true"></asp:TextBox>
                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Role Name:</b></td>
            <td>
                <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSave" class="btn btn-primary  btn-sm" runat="server" Text="Create Role" OnClick="btnSave_click" />
                <asp:Button ID="btnDelete" class="btn btn-danger  btn-sm" runat="server" Text="Delete Role" OnClick="btnDelete_click" />
            </td>
        </tr>
    </table>

    <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="false" Width="25%">
        <Columns>
            <asp:BoundField DataField="roleId" HeaderText="Role Id" />
            <asp:BoundField DataField="roleName" HeaderText="Role Name" />
        </Columns>
    </asp:GridView>

    <table>
        <tr>
            <td><b>Enter UserName To Search:</b></td>
            <td>
                <div>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: text-top;"><b>Assign Roles:</b></td>
            <td>
                <asp:CheckBoxList ID="chkRoles" runat="server">
                </asp:CheckBoxList></td>
        </tr>
    </table>
</asp:Content>
