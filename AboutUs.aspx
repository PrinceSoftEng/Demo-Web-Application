<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="AboutUs.aspx.cs" Inherits="Web_Application_Registration.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Css/AboutUsCss.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="about-section">
        <h1>About Us</h1>
        <p>Angel Autombile establish in 1992.Near the Dahisar East At S.V Road It was Known for its New Car Selling and Second Hand Car Selling</p>
    </div>

    <h2 style="text-align: center; text-orientation: initial;">Our Team</h2>
    <div class="row">
        <div class="column">
            <div class="card">
                <div class="container">
                    <h2>Sharukh Ansari</h2>
                    <p class="title">Founder</p>
                    <p>Sharukh Ansari was an 15 Years of experienece in automobile eastablish the Angel Automobile.</p>
                    <p>Sharukh@gmail.com</p>
                    <p>
                        <button class="button">
                            <a href="ContactUs.aspx">Contact Us</a>
                        </button>
                    </p>
                </div>
            </div>
        </div>

        <div class="column">
            <div class="card">
                <div class="container">
                    <h2>Ketan Shah</h2>
                    <p class="title">CEO & Partner</p>
                    <p>Have a 10 Years of Experience as car dealer in India.Partner at Angel automobile and CEO..!</p>
                    <p>Ketan@gmail.com</p>
                    <p>
                        <button class="button">
                            <a href="ContactUs.aspx">Contact Us</a>
                        </button>
                    </p>
                </div>
            </div>
        </div>

        <div class="column">
            <div class="card">
                <div class="container">
                    <h2>Rohit Khobe</h2>
                    <p class="title">Manager</p>
                    <p>Hardworking passionate with work within few Years get lots of knowledge in Automobile.</p>
                    <p>Rohit@gmail.com</p>
                    <p>
                        <button class="button">
                            <a href="ContactUs.aspx">Contact Us</a>
                        </button>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
