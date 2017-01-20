<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MoviesList.aspx.cs" Inherits="TrabalhoFinal.MoviesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <h1 style="font-weight: 100; font-size: 2.6em; margin: 40px 0; float: left; width: 100%; text-shadow: 0px 0px 6px rgba(255,255,255,0.7);"><i class="fa fa-film"></i> Movies List</h1>
     <hr />
    <div id="wrapper">
        <div class ="center">
            <div class ="row">
                 <div>
                    <div class="col-md-4">
                        
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MoviesBSConnectionString2 %>" SelectCommand="SELECT DISTINCT [genre] FROM [Genres]"></asp:SqlDataSource>
    
                        Order by:
    
                        <asp:DropDownList AppendDataBoundItems="true" CssClass="btn btn-success dropdown-toggle" ID="DropDownList2" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" DataTextField="rating" DataValueField="rating">
                            <asp:ListItem>Any</asp:ListItem>         
                            <asp:ListItem>Higher Rating</asp:ListItem>
                            <asp:ListItem>Lower Rating</asp:ListItem>
                            <asp:ListItem>Newer</asp:ListItem>
                            <asp:ListItem>Older</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-5" style="text-align:right; ">
                        <label style="font-size:35px"><i class="fa fa-search fa-3"></i></label>
                    </div>
                    <div class="col-md-3">
                         <asp:TextBox runat="server" id="Text1" class="form-control" OnTextChanged="input_onClick" placeholder="Search" type="text"  />
                    </div>
                    <div class="col-md-12">
                    </div>
                </div>
                <div id="news" runat="server" class="list">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
