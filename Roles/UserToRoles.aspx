<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="UserToRoles.aspx.cs" Inherits="Web_Application_Registration.Roles.UserToRoles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
    <%--<script type="text/javascript">
        $(document).ready(function () {
            debugger;
            // Attach an event handler to the dropdown list's change event
            $("#ddlUserName").change(function () {
                var selectedValue = $(this).val();

                // Call the server-side method to get the checked items from the database
                $.ajax({
                    type: "POST",
                    url: "UserToRoles.aspx/GetCheckedItemsFromDatabase",
                    data: "{ itemId: '" + selectedValue + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var checkedItems = response.d;

                        // Clear the checkbox list
                        $("#chkRoles").empty();

                        // If there are no checked items, add a message to the checkbox list
                        if (checkedItems.length === 0) {
                            $("#chkRoles").append("<option disabled='disabled'>No items available</option>");
                        } else {
                            // Add the checked items to the checkbox list
                            $.each(checkedItems, function (index, item) {
                                $("#chkRoles").append("<option value='" + item + "'>" + item + "</option>");
                            });
                        }
                    },
                    error: function (error) {
                        console.log(error);
                    }
                });
            });
        });
    </script>--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />

    <%--<script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".aspControls").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: 'POST',
                        url: 'UserToRoles.aspx/GetRoleNameBySearch',
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
    </script>   --%>
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

    <table id="tblUsers">
        <%-- <tr>
            <td><b>Enter UserName To Search:</b></td>
            <td>
                <div class="aspControls">
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>                  
                </div>
            </td>
        </tr>--%>
        <tr>
            <td><b>Select UserName:</b></td>
            <td>
                <div>
                    <asp:DropDownList ID="ddlUserName" runat="server"></asp:DropDownList>
                    <script>
                        $('#<%=ddlUserName.ClientID%>').chosen();
                    </script>
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
