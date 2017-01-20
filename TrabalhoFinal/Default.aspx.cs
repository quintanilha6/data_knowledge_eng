using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TrabalhoFinal
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getRecent();
            getTop();
        }

        

        private void getRecent()
        {
            string link = "http://localhost:49486/RSS/recent";

            XmlReader reader = XmlReader.Create(link);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            XmlDataSource3.Data = doc.OuterXml;
            XmlDataSource3.DataBind();
            XmlDataSource3.XPath = "/rss/channel";

            XmlDataSource2.Data = doc.OuterXml;
            XmlDataSource2.DataBind();
            XmlDataSource2.XPath = "/channel";

            XmlDocument xdoc1 = XmlDataSource3.GetXmlDocument();
            XmlDocument xdoc2 = XmlDataSource2.GetXmlDocument();
            XmlNodeList channel = xdoc1.SelectNodes("//channel");
            XmlNode info = channel[0];
            XmlNodeList noticias = xdoc2.SelectNodes("//item");

            recent.InnerHtml = "<ul>";

            foreach (XmlNode i in noticias)
            {
                recent.InnerHtml += "" +
                    "<li>" +
                        "<a href = \"/Movie?ID=" + i.Attributes["id"].Value + "\" >" +
                            "<div class=\"thumb\">" +
                                "<div class=\"img\" style=\"background-image: url('" + i.Attributes["poster"].Value + "');\"></div>" +
                            "</div>" +
                            "<div class=\"info\">" +
                                "<div class=\"title\">" + i.Attributes["title"].Value + "</div>" +
                                "<div class=\"infos\">" +
                                    "<div class=\"year\">" + i.Attributes["year"].Value + "</div>" +
                                    "<div class=\"imdb\">TMDB: " + i.Attributes["rating"].Value + "</div>" +
                                "</div>" +
                            "</div>" +
                        "</a>" +
                    "</li>";
            }
            recent.InnerHtml += "</ul>";
        }

        private void getTop()
        {
            string link = "http://localhost:49486/RSS/top";

            XmlReader reader = XmlReader.Create(link);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            XmlDataSource3.Data = doc.OuterXml;
            XmlDataSource3.DataBind();
            XmlDataSource3.XPath = "/rss/channel";

            XmlDataSource2.Data = doc.OuterXml;
            XmlDataSource2.DataBind();
            XmlDataSource2.XPath = "/channel";

            XmlDocument xdoc1 = XmlDataSource3.GetXmlDocument();
            XmlDocument xdoc2 = XmlDataSource2.GetXmlDocument();
            XmlNodeList channel = xdoc1.SelectNodes("//channel");
            XmlNode info = channel[0];
            XmlNodeList noticias = xdoc2.SelectNodes("//item");

            top.InnerHtml = "<ul>";

            foreach (XmlNode i in noticias)
            {
                top.InnerHtml += "" +
                    "<li>" +
                        "<a href = \"/Movie?ID=" + i.Attributes["id"].Value + "\" >" +
                            "<div class=\"thumb\">" +
                                "<div class=\"img\" style=\"background-image: url('" + i.Attributes["poster"].Value + "');\"></div>" +
                            "</div>" +
                            "<div class=\"info\">" +
                                "<div class=\"title\">" + i.Attributes["title"].Value + "</div>" +
                                "<div class=\"infos\">" +
                                    "<div class=\"year\">" + i.Attributes["year"].Value + "</div>" +
                                    "<div class=\"imdb\">TMDB: " + i.Attributes["rating"].Value + "</div>" +
                                "</div>" +
                            "</div>" +
                        "</a>" +
                    "</li>";
            }
            top.InnerHtml += "</ul>";
        }
    }
}