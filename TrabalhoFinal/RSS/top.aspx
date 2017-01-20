<%@ Page Language="C#" ContentType="text/xml" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="TrabalhoFinal.RSS.top" %>

<asp:Repeater id="RepeaterRSS" runat="server">
        <HeaderTemplate>
           <rss version="2.0">
                <channel>
                    <title>EasyMovies</title>
                    <link>http://www.EasyMovies.com</link>
                    <description>
                        EasyMovies is an online platform that allows easy access to the best movies, providing all the information about your preferences.
                    </description>
                    <language>en-EN</language>
        </HeaderTemplate>
        <ItemTemplate>
            <item>
                <id><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "id")) %></id>
                <rating><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "rating")) %></rating>
                <year><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "year"))%></year>
                <poster><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "poster"))%></poster>
                <title><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "title"))%></title>
            </item>
        </ItemTemplate>
        <FooterTemplate>
                </channel>
            </rss>  
        </FooterTemplate>
</asp:Repeater>
