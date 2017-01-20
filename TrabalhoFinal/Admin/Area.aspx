<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Area.aspx.cs" Inherits="TrabalhoFinal.Admin.Area" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Admin Area</h1>
   <asp:XmlDataSource ID="XmlDataSource1" runat="server" TransformFile="~/App_Data/Movie.xsl"></asp:XmlDataSource>
   <asp:XmlDataSource ID="XmlDataSource2" runat="server"></asp:XmlDataSource>

   <hr/>

    <div class="bs-docs-section">

        <div class="row">
          <div class="col-lg-6">
            <div class="well bs-component">
              <form class="form-horizontal">
                <fieldset>
                  <legend>Actions</legend>
                  
                  <div class="form-group">
                    <label class="col-lg-4 control-label">Insert Movie</label>
                    <div class="col-lg-6">
                      <input class="form-control" id="idInput" runat="server">
                    </div>
                    <div class="col-lg-2">
                      <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" OnClick="Button2_Click" Text="Insert" />
                      <p> </p>
                    </div>
                  </div>
                  

                
                </fieldset>
              </form>
            </div>
          </div>
          <div class="col-lg-6">
            <div class="well bs-component">
              <form class="form-horizontal">
                <fieldset>
                  <legend>Statistics</legend>
                  <div class="form-group">
                    <label class="col-lg-4 control-label" style="text-align:left;">  Number of Movies:</label>
                    <label id="movies" runat="server" class="col-lg-8 control-label" style="text-align:left;"></label>
                  </div>

                  <div class="form-group">
                    <label class="col-lg-4 control-label" style="text-align:left;">  Number of Users:</label>
                    <label id="users" runat="server" class="col-lg-8 control-label" style="text-align:left;"></label>
                  </div>

                  <div class="form-group">
                    <label class="col-lg-4 control-label" style="text-align:left;">  Number of Comments:</label>
                    <label id="comments" runat="server" class="col-lg-8 control-label" style="text-align:left;"></label>
                  </div>

                </fieldset>
              </form>
            </div>
          </div>
        </div>
      </div>
</asp:Content>
