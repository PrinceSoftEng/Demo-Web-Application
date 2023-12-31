﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RoleMaster.aspx.cs" Inherits="Web_Application_Registration.WebForm3" %>

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
    <b><asp:Label ID="lblRoles" runat="server">Select Roles:</asp:Label></b>
        <asp:DropDownList ID="ddlRoles" runat="server" Style="margin: 8px; padding: 5px;" AutoPostBack="true" class="btn btn-primary dropdown-toggle" OnSelectedIndexChanged="ddlRole_OnSelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <hr />
        <asp:GridView ID="gvPermissions" CssClass="myGridStyle" runat="server" AutoGenerateColumns="False" Width="50%">
            <Columns>
                <asp:BoundField DataField="programList" HeaderText="ProgramList" />
                <asp:TemplateField HeaderText="ProgramList" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblProgramList" runat="server" Text='<%# Eval("programId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Read" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRead" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Add" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAdd" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkUpdate" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkDelete" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Export" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkExport" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />
</asp:Content>
