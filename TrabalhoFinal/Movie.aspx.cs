using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TrabalhoFinal
{
    public partial class Movie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String jsonString = new WebClient().DownloadString("http://api.myapifilms.com/trailerAddict/taapi?idIMDB=" + Request.QueryString["ID"] + "&width=270&token=244f0fe9-66e4-41f4-8d7c-f4b1dcf8b39d&featured=&count=1&credit=&format=json"); ;
                JObject hh = JObject.Parse(jsonString);
                string name = (string)hh["data"]["trailer"][0]["embed"];


                trailer.InnerHtml = name;
            }
            catch { }

            string url = Request.QueryString["ID"];
            Button1.PostBackUrl= "~/Personal/ConfirmPurchases?ID=" + url;
            string apiLink = "http://www.omdbapi.com/?i=" + url + "&plot=full&r=xml";
            if (url == null)
            {
                apiLink = "http://www.omdbapi.com/?i=tt0111161&plot=full&r=xml";
            }
            
            XmlReader reader = XmlReader.Create(apiLink);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            
            XmlDataSource1.Data = doc.OuterXml;
            
            XmlDataSource1.DataBind();
            XmlDataSource1.XPath = "/root/movie";

            DetailsView1.DataBind();

            XmlDocument xdoc1 = XmlDataSource1.GetXmlDocument();
            XmlNode info = xdoc1.SelectSingleNode("/root/movie");
            DetailsView1.DataBind();
            String pattern = "_V1.*";
            String replacement = "jpg";
            Regex rgx;
            rgx = new Regex(pattern);
            String poster = rgx.Replace(info.Attributes["poster"].Value, replacement);

            image.InnerHtml = "<img width=\"300px\" border=\"0\" alt=\"" + info.Attributes["title"].Value + "\" src=\"" + poster + "\">";
            movieName.InnerHtml = "<i class=\"fa fa-video-camera\"></i>  "+ info.Attributes["title"].Value;

            try
            {
                String sql = "SELECT id, email, commentDate, comment FROM dbo.Comments WHERE id = '" + Request.QueryString["ID"] + "'";
                SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
                SqlCommand command = new SqlCommand(sql, connection);

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                connection.Open();

                foreach (DataRow row in table.Rows)
                {

                    sortable.InnerHtml += "<hr/>" +
                    "<strong class=\"pull-left primary-font\">" + row["email"].ToString().Substring(0, row["email"].ToString().IndexOf('@')) + "</strong>" +
                    "<small class=\"pull-right text-muted\">" +
                       "<span class=\"glyphicon glyphicon-time\"></span>" +" "+ row["commentDate"].ToString() + "</small>" +
                    "</br>" +
                    "<li class=\"ui-state-default\">" + row["comment"].ToString() + "</li>";

                }
                connection.Close();
            }
            catch { }



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String sql = "SELECT CASE WHEN EXISTS(SELECT id, email FROM MoviesBS.dbo.Purchases WHERE id = '" + Request.QueryString["ID"] + "' and email = '" + User.Identity.Name + "') THEN 'TRUE' ELSE 'FALSE' END AS[Exists] FROM MoviesBS.dbo.Purchases";
            SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
            SqlCommand command = new SqlCommand(sql, connection);

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            connection.Open();
            connection.Close();
            Debug.WriteLine(table.Rows[0]["Exists"].ToString());

            if (table.Rows[0]["Exists"].ToString() == "TRUE" && User.Identity.IsAuthenticated)
            {
                sql = "INSERT INTO dbo.Comments (id,email, comment) VALUES (@id,@email,@comment)";
                using (connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False"))
                using (command = new SqlCommand(sql, connection))
                {
                    //a shorter syntax to adding parameters
                    command.Parameters.Add("@id", SqlDbType.NChar).Value = Request.QueryString["ID"];

                    command.Parameters.Add("@email", SqlDbType.NChar).Value = User.Identity.Name;

                    command.Parameters.Add("@comment", SqlDbType.NChar).Value = userComment.Value;

                    //make sure you open and close(after executing) the connection
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                Response.Redirect("~/Movie?ID="+ Request.QueryString["ID"]);
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR: Only authenticated users who bought this film can comment')", true);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String sql = "SELECT CASE WHEN EXISTS(SELECT id, email FROM MoviesBS.dbo.Whishlist WHERE id = '" + Request.QueryString["ID"] + "' and email = '" + User.Identity.Name + "') THEN 'TRUE' ELSE 'FALSE' END AS[Exists] FROM MoviesBS.dbo.Whishlist";
            SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
            SqlCommand command = new SqlCommand(sql, connection);

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            connection.Open();
            connection.Close();
            Debug.WriteLine(table.Rows[0]["Exists"].ToString());

            if (table.Rows[0]["Exists"].ToString() == "FALSE" && User.Identity.IsAuthenticated)
            {
                sql = "INSERT INTO dbo.Whishlist (id,email) VALUES (@id,@email)";
                using (connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False"))
                using (command = new SqlCommand(sql, connection))
                {
                    //a shorter syntax to adding parameters
                    command.Parameters.Add("@id", SqlDbType.NChar).Value = Request.QueryString["ID"];

                    command.Parameters.Add("@email", SqlDbType.NChar).Value = User.Identity.Name;

                    //make sure you open and close(after executing) the connection
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                Response.Redirect("~/Personal/MyAccount");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR: Not authenticated or already on wishlist')", true);
            }
        }
    }
}