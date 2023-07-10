<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProgramMaster.aspx.cs" Inherits="Web_Application_Registration.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblRoles" runat="server" Text="Select Roles"><b>Select Roles:</b></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlRoles" runat="server" AutoPostBack="true" 
                    class="btn btn-primary dropdown-toggle">
                </asp:DropDownList></td>
        </tr>
    </table>
    <br />
    <hr />
    <br />
    <br />
    <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="false" Width="100%" >
        <Columns>
            <%--<asp:BoundField DataField="PageID" HeaderText="PageID" />--%>
            <asp:BoundField DataField="Pages" HeaderText="Pages" />
            <asp:TemplateField HeaderText="Add" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkAdd" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkUpdate" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Read" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkRead" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkDelete" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="Export" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="chkExport" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnSave" runat="server" Text="Save Permissions" OnClick="btnSave_Click" Visible="false" />
    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
</asp:Content>
