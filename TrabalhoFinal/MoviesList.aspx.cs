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
    public partial class MoviesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM dbo.Movies ORDER BY year DESC";
            renderMovies(sql);
        }

       
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropdownChanges();
        }

        private void dropdownChanges()
        {
            String sql;

            
                sql = "SELECT * FROM dbo.Movies ";
            
            if (DropDownList2.SelectedValue == "Any")
            {
                sql += "ORDER BY [year] DESC";
            }
            else if (DropDownList2.SelectedValue == "Higher Rating")
            {
                sql += "ORDER BY [rating] DESC";
            }
            else if (DropDownList2.SelectedValue == "Lower Rating")
            {
                sql += "ORDER BY [rating] ASC";
            }
            else if (DropDownList2.SelectedValue == "Newer")
            {
                sql += "ORDER BY [year] DESC";
            }
            else if (DropDownList2.SelectedValue == "Older")
            {
                sql += "ORDER BY [year] ASC";
            }

            renderMovies(sql);
        }

        private void renderMovies(String sql)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
                SqlCommand command = new SqlCommand(sql, connection);

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                connection.Open();
                news.InnerHtml = "<ul>";
                foreach (DataRow row in table.Rows)
                {
                    news.InnerHtml += "" +
                    "<li>" +
                        "<a href = \"/Movie?ID=" + row["id"].ToString() + "\" >" +
                            "<div class=\"thumb\">" +
                                "<div class=\"img\" style=\"background-image: url('" + row["poster"].ToString() + "');\"></div>" +
                            "</div>" +
                            "<div class=\"info\">" +
                                "<div class=\"title\">" + row["title"].ToString() + "</div>" +
                                "<div class=\"infos\">" +
                                    "<div class=\"year\">" + row["year"].ToString() + "</div>" +
                                    "<div class=\"imdb\">TMDB: " + row["rating"].ToString() + "</div>" +
                                "</div>" +
                            "</div>" +
                        "</a>" +
                    "</li>";
                }
                connection.Close();
            }
            catch
            {
            }
            news.InnerHtml += "</ul>";
        }

        protected void input_onClick(object sender, EventArgs e)
        {
            String sql = "select * from Movies where UPPER(title) like UPPER('%" + Text1.Text + "%');";
            renderMovies(sql);
        }
    }
}