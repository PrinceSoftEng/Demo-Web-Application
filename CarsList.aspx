<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="CarsList.aspx.cs" Inherits="Web_Application_Registration.CarsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <%--<script type="text/javascript">
        $(function () {
            $('[id*=GvCars]').footable();
            $('[id*=dvCarsModels]').footable();
        });
    </script>--%>
    <style type="text/css">
        .container {
            margin: 2px;
            padding: 5px;
        }

        table tr {
            height: 40px;
            vertical-align: middle;
            text-align: left;
            margin-top: 10px;
        }
         
        .myGridStyle
        {
            border-collapse:collapse;
             
        }
         
        .myGridStyle tr th
        {
            padding: 8px;
            color: white;
            border: 1px solid black;
        }
         
         
        .myGridStyle tr:nth-child(even)
        {
            background-color: #E1FFEF;
        }
         
        .myGridStyle tr:nth-child(odd)
        {
            background-color: #00C157;
        }
         
        .myGridStyle td
        {
            border:1px solid black;
            padding: 8px;
        }
         
        .myGridStyle tr:last-child td
        {
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <table class="">
                    <tr>
                        <td><b>
                            <asp:Label ID="lblCarCode" runat="server" Text="CarCode:"></asp:Label></b></td>
                        <td>
                            <asp:TextBox ID="txtCarCode" runat="server"></asp:TextBox></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <b>
                            <asp:Label ID="lblCarName" runat="server" Text="CarName:"></asp:Label></b></td>
                        <td>
                            <asp:TextBox ID="txtCarName" runat="server"></asp:TextBox></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <b>
                            <asp:Label ID="lblCarColor" runat="server" Text="CarColor:"></asp:Label></b></td>
                        <td>
                            <asp:DropDownList ID="ddlCarColor" runat="server" class="btn btn-primary dropdown-toggle">
                                <asp:ListItem Text="----Select Value---"></asp:ListItem>
                                <asp:ListItem Text="Yellow" Value="Yellow"></asp:ListItem>
                                <asp:ListItem Text="Blue" Value="Blue"></asp:ListItem>
                                <asp:ListItem Text="Green" Value="Green"></asp:ListItem>
                                <asp:ListItem Text="Black" Value="Black"></asp:ListItem>
                                <asp:ListItem Text="White" Value="White"></asp:ListItem>
                                <asp:ListItem Text="Red" Value="Red"></asp:ListItem>
                                <asp:ListItem Text="Silver" Value="Pink"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><b>
                            <asp:Label ID="lblCarYear" runat="server" Text="CarYear:"></asp:Label></b></td>
                        <td>
                            <asp:DropDownList ID="ddlCarYear" runat="server" class="btn btn-primary dropdown-toggle">
                                <asp:ListItem Text="----Select Value---"></asp:ListItem>
                                <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <b>
                            <asp:Label ID="lblCarMakerComp" runat="server" Text="CarMakerComp:"></asp:Label></b></td>
                        <td>
                            <asp:TextBox ID="txtCarMakerComp" runat="server"></asp:TextBox></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <b>
                            <asp:Label ID="lblCarModel" runat="server" Text="CarModel:"></asp:Label></b></td>
                        <td>
                            <asp:TextBox ID="txtCarModel" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><b>
                            <asp:Label ID="lblCarMileage" runat="server" Text="CarMileage:"></asp:Label></b></td>
                        <td>
                            <asp:TextBox ID="txtCarMileage" runat="server"></asp:TextBox></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <b>
                            <asp:Label ID="lblCarCondition" runat="server" Text="CarCondition:"></asp:Label></b></td>
                        <td>
                            <asp:TextBox ID="txtCarCondition" runat="server"></asp:TextBox></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <b>
                            <asp:Label ID="lblCarPrice" runat="server" Text="CarPrice:"></asp:Label></b></td>
                        <td>
                            <asp:TextBox ID="txtCarPrice" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:Button ID="btnInSave" class="btn btn-primary  btn-sm" runat="server" Text="Save" OnClick="btnSave_click" /></td>
                    </tr>
                    <tr>
                        <td><b><asp:Label ID="lblCarsSearch" Text="Search Cars:" runat="server"></asp:Label></b></td>
                        <td><asp:TextBox ID="txtSearch" runat="server" OnTextChanged="CarsSearch_OnTextChanged" AutoPostBack="true"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:GridView ID="GvCars" CssClass="myGridStyle" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5"
        AllowSorting="true" DataKeyNames="CarId" OnRowEditing="GridView_OnRowEditing" OnRowCancelingEdit="GridView_OnRowCancelingEdit"
        OnRowUpdating="GridView_OnRowUpdating" OnRowDeleting="GridView_OnRowDeleting" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView_OnRowDataBound" Width="100%">
        <Columns>
            <asp:BoundField DataField="CarID" HeaderText="Car Id" ReadOnly="true" ItemStyle-Width="50" />
            <asp:TemplateField HeaderText="Car Code" ItemStyle-Width="50">
                <ItemTemplate>
                    <asp:Label ID="lblCarCode" runat="server" Text='<%#Eval("CarCode") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCarCode" runat="server" Text='<%#Eval("CarCode") %>' Width="80"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Car Name" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblCarName" runat="server" Text='<%#Eval("CarName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCarName" runat="server" Text='<%#Eval("CarName") %>' Width="80"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Car Color" ItemStyle-Width="80">
                <ItemTemplate>
                    <asp:Label ID="lblCarColor" runat="server" Text='<%#Eval("CarColor") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCarColor" runat="server" Text='<%#Eval("CarColor") %>' Width="80"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Car Year" ItemStyle-Width="80">
                <ItemTemplate>
                    <asp:Label ID="lblCarYear" runat="server" Text='<%#Eval("CarYear") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCarYear" runat="server" Text='<%#Eval("CarYear") %>' Width="80"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Car MakerComp" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblCarMakerComp" runat="server" Text='<%#Eval("CarMakerComp") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCarMakerComp" runat="server" Text='<%#Eval("CarMakerComp") %>' Width="80"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Car Model" ItemStyle-Width="80">
                <ItemTemplate>
                    <asp:Label ID="lblCarModel" runat="server" Text='<%#Eval("CarModel") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCarModel" runat="server" Text='<%#Eval("CarModel") %>' Width="80"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Car Mileage" ItemStyle-Width="80">
                <ItemTemplate>
                    <asp:Label ID="lblCarMileage" runat="server" Text='<%#Eval("CarMileage") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCarMileage" runat="server" Text='<%#Eval("CarMileage") %>' Width="80"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Car Condition" ItemStyle-Width="80">
                <ItemTemplate>
                    <asp:Label ID="lblCarCondition" runat="server" Text='<%#Eval("CarCondition") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCarCondition" runat="server" Text='<%#Eval("CarCondition") %>' Width="80"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Car Price" ItemStyle-Width="80">
                <ItemTemplate>
                    <asp:Label ID="lblCarPrice" runat="server" Text='<%#Eval("CarPrice") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCarPrice" runat="server" Text='<%#Eval("CarPrice") %>' Width="80"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Action" ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
    <br />
    <u>Selected Data:</u>
    <br />
    <br />
    <asp:DetailsView ID="dvCarsModels" CssClass="footable" runat="server" AutoGenerateRows="false"
        HeaderText="Car Model Data" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="X-Large"
        HeaderStyle-BackColor="#ffff66" HeaderStyle-VerticalAlign="Middle"
        AllowPaging="true" OnPageIndexChanging="DetailsView_OnPageIndexChanging" Width="100%">
        <Fields>
            <asp:BoundField DataField="ModelId" HeaderText="ModelId" />
            <asp:BoundField DataField="ModelName" HeaderText="ModelName" />
            <asp:BoundField DataField="ModelPrice" HeaderText="ModelPrice" />
            <asp:BoundField DataField="ModelYear" HeaderText="ModelYear" />
            <asp:BoundField DataField="ModelEngine" HeaderText="ModelEngine" />
            <asp:BoundField DataField="ModelTransmission" HeaderText="ModelTransmission" />
        </Fields>
    </asp:DetailsView>
</asp:Content>
