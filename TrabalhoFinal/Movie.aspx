<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movie.aspx.cs" Inherits="TrabalhoFinal.Movie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 id="movieName" runat="server"></h1>
    <hr/>
    
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" EnableCaching="false"></asp:XmlDataSource>
    
    <div runat="server" class="row">
        <div class="col-lg-8">
            <h3 style="text-decoration: underline;">Movie Info</h3>
            <asp:DetailsView CssClass="table" GridLines="None" ID="DetailsView1" runat="server" DataSourceID="XmlDataSource1" AutoGenerateRows="False" >
                <Fields>
                    <asp:BoundField  DataField="title" HeaderText="Title" SortExpression="title" >
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="year" HeaderText="Year" SortExpression="year" >
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="released" HeaderText="Release Date" SortExpression="released" >
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="runtime" HeaderText="Runtime" SortExpression="runtime" >
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="genre" HeaderText="Genres" SortExpression="genre" >
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="director" HeaderText="Director" SortExpression="director" >
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="writer" HeaderText="Writer" SortExpression="writer" >
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="actors" HeaderText="Actors" SortExpression="actors" >   
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="plot" HeaderText="Plot" SortExpression="plot"  >   
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="language" HeaderText="Language" SortExpression="language" >   
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="country" HeaderText="Country" SortExpression="country"  >   
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="awards" HeaderText="Awards" SortExpression="awards"  >   
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="metascore" HeaderText="Metascore" SortExpression="metascore"  >   
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="imdbRating" HeaderText="IMDB Rating" SortExpression="imdbRating"  >   
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="imdbID" HeaderText="IMDB ID" SortExpression="imdbID"  >   
                    <HeaderStyle Font-Bold="True" ForeColor="#bc2727" Font-Size="Medium" />
                    </asp:BoundField>

                </Fields>
            </asp:DetailsView>
        </div>
        <div class="col-lg-4">
            <h3 style="text-decoration: underline;">Poster</h3>
            <div id="image" runat="server">
            </div>
            <p>

            </p>
            <div>
                    <asp:Button CssClass="btn btn-success" ID="Button1" runat="server" Text="Purchase" Width="300" Font-Size="Medium" />
            </div>
            <p>

            </p>
            <div>
                    <asp:Button CssClass="btn btn-danger" ID="Button3" runat="server" OnClick="Button3_Click" Text="Add to Wishlist" Width="300" Font-Size="Medium"/>
            </div>
             <p>

             </p>
            <div style="width:300px;" class="panel-group">
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse1" style="font-size:medium; text-align:center;">Featured Video</a>
                  </h4>
                </div>
                <div id="collapse1" class="panel-collapse collapse">
                  <div style="text-align:center" class="panel-body" runat="server" id="trailer"></div>
                </div>
              </div>
            </div>
        </div>
    </div> 
     <p>

      </p>
     
    
    <hr/>

    <div class="container">
        <div class="col-lg-12 col-sm-6 text-left">
            <div class="well">
                <h4>Review this movie</h4>
                <div class="input-group">
                    <input type="text" id="userComment" class="form-control input-sm chat-input" runat="server" placeholder="Write your review here..." />
	                <span class="input-group-btn"> 
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="Button2" runat="server" Text="Add Review" OnClick="Button2_Click" />  
                    </span>
                </div>
                
                <ul id="sortable" runat="server" class="list-unstyled ui-sortable">
                    
                </ul>

       </div>    
     </div>
</div>


</asp:Content>
