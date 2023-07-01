<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="CarsList.aspx.cs" Inherits="Web_Application_Registration.CarsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<style type="text/css">
        table {
            border: solid 1px black;
        }

            table td {
                border-right: solid 1px black;
                border-bottom: solid 1px black;
            }

            table th {
                border-right: solid 1px black;
                border-bottom: solid 1px black;
                text-align: center;
            }

        .expand {
            background-position: -14px -187px;
            height: 14px;
            width: 13px;
            background-repeat: no-repeat;
            background-image: url('DXR.png');
            cursor: pointer;
        }

        .arrow-link {
            font-size: 14px;
            color: #4800ff;
            text-decoration: none;
            padding: 0 5px;
        }

        .SUBDIV table {
            border: 0px;
            border-left: 1px solid black;
        }
    </style>


    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript">
    </script>
    <script language="javascript">
        $(document).ready(function () {
            $(".SUBDIV table tr:not(:first-child)").not("tr tr").hide();
            $(".SUBDIV .btncolexp").click(function () {
                $(this).closest('tr').next('tr').toggle();
                if ($(this).attr('class').toString() == "btncolexp collapse") {
                    $(this).addClass('expand');
                    $(this).removeClass('collapse');
                }
                else {
                    $(this).removeClass('expand');
                    $(this).addClass('collapse');
                }
            });
        });
    </script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div>
        <asp:ListView ID="lstCars" runat="server" OnItemDataBound="ListView1_ItemDataBound">
            <LayoutTemplate>
                <table width="100%">
                    <tr>
                        <th width="30px"></th>
                        <th width="5%">CarID</th>
                        <th width="5%">CarCode</th>
                        <th width="15%">CarName</th>
                        <th width="10%">CarColor</th>
                        <th width="10%">CarYear</th>
                        <th width="10%">CarMakerComp</th>
                        <th width="10%">CarModel</th>
                        <th width="10%">CarMileage</th>
                        <th width="10%">CarCondition</th>
                        <th>CarPrice</th>
                    </tr>
                </table>
                <div runat="server" id="itemPlaceHolder"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="SUBDIV" runat="server">
                    <table width="100%">
                        <tr>
                            <td width="30px">
                                <div class="btncolexp collapse">
                                    <asp:LinkButton ID="lnkArrow" runat="server" CssClass="arrow-link">&#9658;
                                    </asp:LinkButton>
                                </div>
                            </td>
                            <td width="5%"><%#Eval("CarID") %></td>
                            <td width="5%"><%#Eval("CarCode") %></td>
                            <td width="15%"><%#Eval("CarName") %></td>
                            <td width="10%"><%#Eval("CarColor") %></td>
                            <td width="10%"><%#Eval("CarYear") %></td>
                            <td width="10%"><%#Eval("CarMakerComp") %></td>
                            <td width="10%"><%#Eval("CarModel") %></td>
                            <td width="10%"><%#Eval("CarMileage") %></td>
                            <td width="10%"><%#Eval("CarCondition") %></td>
                            <td><%#Eval("CarPrice") %></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div style="margin: 20px">
                                    <asp:GridView ID="gvCarModel" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="ModelId" HeaderText="Model Id" />
                                            <asp:BoundField DataField="ModelName" HeaderText="Model Name" />
                                            <asp:BoundField DataField="ModelPrice" HeaderText="Model Price" />
                                            <asp:BoundField DataField="ModelYear" HeaderText="Model Year" />
                                            <asp:BoundField DataField="ModelEngine" HeaderText="Model Engine" />
                                            <asp:BoundField DataField="ModelTransmission" HeaderText="Model Transmission" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>--%>
    <asp:GridView ID="GvCars" runat="server" AutoGenerateColumns="false" AllowPaging="true" 
        AllowSorting="true" DataKeyNames="CarId" AutoGenerateSelectButton="true" 
        OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" onpage="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="CarID" HeaderText="Cae Id" />
            <asp:BoundField DataField="CarCode" HeaderText="Car Code" />
            <asp:BoundField DataField="CarName" HeaderText="Car Name" />
            <asp:BoundField DataField="CarColor" HeaderText="Car Color" />
            <asp:BoundField DataField="CarYear" HeaderText="Car Year" />
            <asp:BoundField DataField="CarMakerComp" HeaderText="Car MakerComp" />
            <asp:BoundField DataField="CarModel" HeaderText="Car Model" />
            <asp:BoundField DataField="CarMileage" HeaderText="Car Mileage" />
            <asp:BoundField DataField="CarCondition" HeaderText="Car Condition" />
            <asp:BoundField DataField="CarPrice" HeaderText="Car Price" />
        </Columns>
    </asp:GridView>
    <br />
    <u>Selected Data:</u>
    <br />
    <br />
    <asp:DetailsView ID="dvCarsModels" runat="server" HeaderText="DetailsView" HeaderStyle-BackColor="#ffff66" HeaderStyle-VerticalAlign="Middle" 
    AllowPaging="true" OnPageIndexChanging="DetailsView_OnPageIndexChanging"></asp:DetailsView>
</asp:Content>
