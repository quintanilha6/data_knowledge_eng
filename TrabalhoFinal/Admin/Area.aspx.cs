using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TrabalhoFinal.Admin
{
    public partial class Area : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            stats();
        }
        private void stats() {
            try
            {
                String sql = "Select count(*) as [Count] from dbo.Movies";
                SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
                SqlCommand command = new SqlCommand(sql, connection);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                connection.Open();
                movies.InnerText = table.Rows[0]["Count"].ToString();
                connection.Close();

                sql = "Select count(*) as [Count] from dbo.Comments";
                command = new SqlCommand(sql, connection);
                table = new DataTable();
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                connection.Open();
                comments.InnerText = table.Rows[0]["Count"].ToString();
                connection.Close();

                sql = "SELECT count(*) as [Count] FROM [aspnet-TrabalhoFinal-20151128042339].[dbo].[AspNetUsers]";
                connection = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                command = new SqlCommand(sql, connection);
                table = new DataTable();
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                connection.Open();
                users.InnerText = table.Rows[0]["Count"].ToString();
                connection.Close();
            }
            catch { }
        }
       
        protected void Button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("dqwdqwdqw");
            XmlReader reader = XmlReader.Create("http://www.omdbapi.com/?i=" + idInput.Value.ToString() + "&plot=full&r=xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            XmlDataSource2.Data = doc.OuterXml;

            XmlDataSource2.DataBind();
            XmlDataSource2.XPath = "/root/movie";


            XmlDocument xdoc1 = XmlDataSource2.GetXmlDocument();
            XmlNode info = xdoc1.SelectSingleNode("/root/movie");

            String query = "INSERT INTO dbo.Movies (id,rating,year,poster,title) VALUES (@id,@rating, @year, @poster, @title)";
            using (SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False"))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //a shorter syntax to adding parameters
                command.Parameters.Add("@id", SqlDbType.NChar).Value = idInput.Value.ToString();

                command.Parameters.Add("@rating", SqlDbType.NChar).Value = info.Attributes["imdbRating"].Value;

                command.Parameters.Add("@year", SqlDbType.NChar).Value = info.Attributes["year"].Value;

                command.Parameters.Add("@poster", SqlDbType.NChar).Value = info.Attributes["poster"].Value;

                command.Parameters.Add("@title", SqlDbType.NChar).Value = info.Attributes["title"].Value;

                //make sure you open and close(after executing) the connection
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch { }
                connection.Close();
            }
            stats();
        

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XmlReader reader = XmlReader.Create("http://www.myapifilms.com/imdb/top?format=XML&start=1&end=200&data=S");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            String poster;


            XmlDataSource1.Data = doc.OuterXml;
            XmlDataSource1.DataBind();
            XmlDataSource1.XPath = "/channel";

            XmlDocument xdoc2 = XmlDataSource1.GetXmlDocument();
            XmlNodeList noticias = xdoc2.SelectNodes("//movie");
            String pattern = "_V1.*";
            String replacement = "jpg";
            Regex rgx;
            foreach (XmlNode i in noticias)
            {
                rgx = new Regex(pattern);
                poster = rgx.Replace(i.Attributes["urlPoster"].Value, replacement);
               
                String query = "INSERT INTO dbo.Movies (id,rating,year,poster,title) VALUES (@id,@rating, @year, @poster, @title)";
                using (SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False"))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    //a shorter syntax to adding parameters
                    command.Parameters.Add("@id", SqlDbType.NChar).Value = i.Attributes["idIMDB"].Value;

                    command.Parameters.Add("@rating", SqlDbType.NChar).Value = i.Attributes["rating"].Value;

                    command.Parameters.Add("@year", SqlDbType.NChar).Value = i.Attributes["year"].Value;

                    command.Parameters.Add("@poster", SqlDbType.NChar).Value = poster;

                    command.Parameters.Add("@title", SqlDbType.NChar).Value = i.Attributes["title"].Value;

                    //make sure you open and close(after executing) the connection
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch { }
                    connection.Close();
                }
            }

            reader = XmlReader.Create("http://www.myapifilms.com/imdb/top?format=XML&start=1&end=200&data=F");
            doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();


            XmlDataSource1.Data = doc.OuterXml;
            XmlDataSource1.DataBind();
            XmlDataSource1.XPath = "/channel";

            xdoc2 = XmlDataSource1.GetXmlDocument();
            noticias = xdoc2.SelectNodes("//movie");


            foreach (XmlNode i in noticias)
            {
                string[] genres = i.Attributes["genre"].Value.Split(',');

                foreach (String a in genres)
                {
                    string query = "INSERT INTO dbo.Genres (id,genre) VALUES (@id,@genre)";
                    using (SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False"))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //a shorter syntax to adding parameters
                        command.Parameters.Add("@id", SqlDbType.NChar).Value = i.Attributes["idIMDB"].Value;

                        command.Parameters.Add("@genre", SqlDbType.NChar).Value = a;
                        //make sure you open and close(after executing) the connection
                        connection.Open();
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch { }
                        connection.Close();
                    }
                }
            }
        }
    }
}