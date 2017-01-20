using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TrabalhoFinal.Personal
{
    public partial class ConfirmPurchases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.QueryString["ID"];
            //Button2.PostBackUrl = "~/Personal/MyArea";
            string apiLink = "http://www.omdbapi.com/?i=" + url + "&plot=short&r=xml";
            
            XmlReader reader = XmlReader.Create(apiLink);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlDataSource1.Data = doc.OuterXml;
            XmlDataSource1.DataBind();
            XmlDataSource1.XPath = "/root/movie";
            XmlDocument xdoc1 = XmlDataSource1.GetXmlDocument();
            XmlNode info = xdoc1.SelectSingleNode("/root/movie");

            movie.InnerText = info.Attributes["title"].Value;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String sql = "SELECT CASE WHEN EXISTS(SELECT id, email FROM MoviesBS.dbo.Purchases WHERE id = '"+ Request.QueryString["ID"] + "' and email = '"+ User.Identity.Name + "') THEN 'TRUE' ELSE 'FALSE' END AS[Exists] FROM MoviesBS.dbo.Purchases";
            SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
            SqlCommand command = new SqlCommand(sql, connection);

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            connection.Open();
            connection.Close();
            Debug.WriteLine(table.Rows[0]["Exists"].ToString());

            if (table.Rows[0]["Exists"].ToString() == "FALSE")
            {
                sql = "INSERT INTO dbo.Purchases (id,email) VALUES (@id,@email)";
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
                try
                {
                    sql = "SELECT CASE WHEN EXISTS(SELECT id, email FROM MoviesBS.dbo.Purchases WHERE id = '" + Request.QueryString["ID"] + "' and email = '" + User.Identity.Name + "') THEN 'TRUE' ELSE 'FALSE' END AS[Exists] FROM MoviesBS.dbo.Purchases";
                    connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
                    command = new SqlCommand(sql, connection);

                    table = new DataTable();
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                    connection.Open();
                    connection.Close();
                    
                    if (table.Rows[0]["Exists"].ToString() == "TRUE") {
                        sql = "Delete from MoviesBS.dbo.Whishlist where id = '" + Request.QueryString["ID"] + "' and email = '" + User.Identity.Name + "'";
                        connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");
                        command = new SqlCommand(sql, connection);

                        table = new DataTable();
                        adapter = new SqlDataAdapter(command);
                        adapter.Fill(table);
                        connection.Open();
                        connection.Close();
                    }

                   
                }
                catch { }
                Response.Redirect("~/Personal/MyAccount");
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR: You already have this movie')", true);

            }


        }
    }
}