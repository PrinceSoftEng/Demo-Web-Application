<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RoleMaster.aspx.cs" Inherits="Web_Application_Registration.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .myGridStyle
        {
            border-collapse:collapse;
             
        }
         
        .myGridStyle th
        {
            text-align:center;
            padding: 3px;
            color: Black;
            border: 1px solid black;
            background-color:#27c8c8
        }
         
         
        .myGridStyle tr:nth-child(even)
        {
            background-color: #ede77f;
        }
         
        .myGridStyle tr:nth-child(odd)
        {
            background-color: #f3ef32;
        }
         
        .myGridStyle td
        {
            border:1px solid black;
            padding: 5px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID ="lblRoles" runat="server">Select Roles:</asp:Label>
        <asp:DropDownList ID="ddlRoles" runat="server" style="margin:8px;padding:5px;" AutoPostBack="true" class="btn btn-primary dropdown-toggle" >
        </asp:DropDownList>
        <br />
        <hr />
        <asp:GridView ID="gvPermissions" CssClass="myGridStyle" runat="server" AutoGenerateColumns="False" Width="50%">
            <Columns>
                <asp:BoundField DataField="ProgramList" HeaderText="programList" />
                <asp:TemplateField HeaderText="Read"  ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRead" runat="server" Checked='<%# Eval("Read") %>'  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Add" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAdd" runat="server" Checked='<%# Eval("Add") %>'  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkUpdate" runat="server" Checked='<%# Eval("Update") %>'  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkDelete" runat="server" Checked='<%# Eval("Delete") %>'  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Export" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkExport" runat="server" Checked='<%# Eval("Export") %>'  />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
