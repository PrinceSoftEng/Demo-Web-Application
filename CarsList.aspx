<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="CarsList.aspx.cs" Inherits="Web_Application_Registration.CarsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=GvCars]').footable();
            $('[id*=dvCarsModels]').footable();
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GvCars" CssClass="footable" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5"
        AllowSorting="true" DataKeyNames="CarId" AutoGenerateSelectButton="true"
        OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
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
    <asp:DetailsView ID="dvCarsModels" CssClass="footable" runat="server" 
        HeaderText="Car Model Data" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="X-Large"  
        HeaderStyle-BackColor="#ffff66" HeaderStyle-VerticalAlign="Middle" 
        AllowPaging="true" OnPageIndexChanging="DetailsView_OnPageIndexChanging">
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
