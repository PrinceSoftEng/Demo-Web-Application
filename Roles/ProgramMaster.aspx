<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProgramMaster.aspx.cs" Inherits="Web_Application_Registration.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        th {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblRoles" runat="server" Text="Select Roles"><b>Select Roles:</b></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlRoles" runat="server" class="btn btn-primary dropdown-toggle" AutoPostBack="true">
                </asp:DropDownList>
        </tr>
    </table>
    <br />
    <hr />
    <br />
    <br />
    <asp:GridView ID="gvPermissions" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gvPermissions_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="PageName" HeaderText="Pages" />
            <asp:TemplateField HeaderText="Add" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="cbAdd" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="cbUpdate" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="cbDelete" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Read" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="cbRead" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Export" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="cbExport" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save Changes" OnClick="btnSave_Click" />
</asp:Content>
