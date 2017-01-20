<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="TrabalhoFinal.Personal.MyArea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><i class="fa fa-user"></i> My Account</h1>
    
    <hr />

    <div id="wrapper">
        <div class ="center">
            <div class ="row">
                <h2>My Movies</h2>
                <div id="movie" runat="server" class="list">
                </div>
                <h2>My Wishlist</h2>
                <div id="wish" runat="server" class="list">
                </div>
                <h2>My Reviews</h2>
                <div class="container">
                    <div class="col-lg-12 col-sm-6 text-left">
                        <div class="well">
                            <h4>Movie Reviews</h4>
                            
                
                            <ul id="sortable" runat="server" class="list-unstyled ui-sortable">
                    
                            </ul>

                        </div>    
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
