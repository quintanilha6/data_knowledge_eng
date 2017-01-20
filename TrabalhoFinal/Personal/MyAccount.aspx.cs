using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabalhoFinal.Personal
{
    public partial class MyArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String sql = "SELECT Movies.id, rating, year, poster, title FROM dbo.Purchases, dbo.Movies WHERE email = '" + User.Identity.Name + "' AND Movies.id = Purchases.id";
                SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
                SqlCommand command = new SqlCommand(sql, connection);

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                connection.Open();
                movie.InnerHtml = "<ul>";
                foreach (DataRow row in table.Rows)
                {
                    Debug.WriteLine(row["title"].ToString());

                    movie.InnerHtml += "" +

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
                movie.InnerHtml += "</ul>";

                sql = "SELECT Movies.id, rating, year, poster, title FROM dbo.Whishlist, dbo.Movies WHERE email = '" + User.Identity.Name + "' AND Movies.id = Whishlist.id";
                connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
                command = new SqlCommand(sql, connection);

                table = new DataTable();
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                connection.Open();
                wish.InnerHtml = "<ul>";
                foreach (DataRow row in table.Rows)
                {
                    Debug.WriteLine(row["title"].ToString());

                    wish.InnerHtml += "" +

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
                wish.InnerHtml += "</ul>";

                sql = "SELECT id, email, commentDate, comment FROM dbo.Comments WHERE email = '" + User.Identity.Name + "'";
                connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
                command = new SqlCommand(sql, connection);

                table = new DataTable();
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                connection.Open();
                connection.Close();

                foreach (DataRow row in table.Rows)
                {

                    sql = "SELECT title FROM dbo.Movies WHERE id = '" + row["id"].ToString() + "'";
                    connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
                    command = new SqlCommand(sql, connection);

                    DataTable table2 = new DataTable();
                    SqlDataAdapter adapter2 = new SqlDataAdapter(command);
                    adapter2.Fill(table2);
                    connection.Open();
                    connection.Close();
 
                    sortable.InnerHtml += "<hr/>" +
                    "<strong class=\"pull-left primary-font\">" + table2.Rows[0]["title"].ToString() + "</strong>" +
                    "<small class=\"pull-right text-muted\">" +
                        "<span class=\"glyphicon glyphicon-time\"></span>" + " " + row["commentDate"].ToString() + "</small>" +
                    "</br>" +
                    "<li class=\"ui-state-default\">" + row["comment"].ToString() + "</li>";

                }
                
             

            }
            catch
            {
            }
            
        }
    }
}