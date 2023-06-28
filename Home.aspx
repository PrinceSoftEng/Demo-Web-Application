<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Home.aspx.cs" Inherits="Web_Application_Registration.Home" %>
<%@ MasterType VirtualPath="~/Site1.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.carousel-indicators').carousel({
                intervel: 1000 * 1
            });
        });
    </script>
    <h3 style="font-variant-caps: small-caps;">WelCome To Angel Automobile</h3>
    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="5"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="6"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="7"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img style="width: 80%;height: 450px;margin-right:auto;margin-left: auto;display: block;" src="Images/Cars.jpg" alt="First slide">
            </div>
            <div class="carousel-item">
                <img style="width: 80%;height: 450px;margin-right:auto;margin-left: auto;display: block;" src="Images/Cars2.jpg" alt="Second slide">
            </div>
            <div class="carousel-item">
                <img style="width: 80%;height: 450px;margin-right:auto;margin-left: auto;display: block;" src="Images/car3.jpg" alt="Third slide">
            </div>
            <div class="carousel-item">
                <img style="width: 80%;height: 450px;margin-right:auto;margin-left: auto;display: block;" src="Images/Car4.jpg" alt="Fourth slide">
            </div>
            <div class="carousel-item">
                <img style="width: 80%;height: 450px;margin-right:auto;margin-left: auto;display: block;" src="Images/Cras5.png" alt="Five slide">
            </div>
            <div class="carousel-item">
                <img style="width: 80%;height: 450px;margin-right:auto;margin-left: auto;display: block;" src="Images/Cars6.jpg" alt="Six slide">
            </div>
            <div class="carousel-item">
                <img style="width: 80%;height: 450px;margin-right:auto;margin-left: auto;display: block;" src="Images/cars7.jpg" alt="Seven slide">
            </div>
            <div class="carousel-item">
                <img style="width: 80%;height: 450px;margin-right:auto;margin-left: auto;display: block;" src="Images/Cars8.jpg" alt="Eight slide">
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
</asp:Content>

