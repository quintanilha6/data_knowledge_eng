<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrabalhoFinal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:XmlDataSource ID="XmlDataSource3" runat="server" TransformFile="~/App_Data/channel.xsl" EnableCaching="false"></asp:XmlDataSource>
    <asp:XmlDataSource ID="XmlDataSource2" runat="server" TransformFile="~/App_Data/noticias.xsl" EnableCaching="false"></asp:XmlDataSource>
    <p></p>
    <div class="jumbotron">
        <h1>
            EasyMovies</h1>
        <p class="lead"> EasyMovies is an online platform that allows easy access to the best movies, providing all the information about your preferences.</p>
    </div>
    
    
    <div id="wrapper">
        <div class ="center">
            <div class ="row">
                <div class="col-md-12">
                    <a href ="RSS/recent"><h2>Recent Movies <i class="fa fa-rss-square"></i></h2></a>
                    <div id="recent" runat="server" class="list">
                    </div>
                </div>
                <div class="col-md-12">
                    <a href ="RSS/top"><h2>Top Sellers <i class="fa fa-rss-square"></i></h2></a>
                    <div id="top" runat="server" class="list">
                    </div>
                </div>
            </div>
        </div>
     </div>


</asp:Content>
