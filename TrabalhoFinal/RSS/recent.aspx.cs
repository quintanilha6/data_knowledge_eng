using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabalhoFinal.RSS
{
    public partial class recent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create SqlConnection object
            SqlConnection sqlConn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MoviesBS;Integrated Security=True;Pooling=False");

            // SQL query to retrieve data from database
            string sqlQuery = "select top 14 * from dbo.Movies order by insertDate DESC;";

            // Create SqlCommand object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlQuery;

            // open connection and then binding data into RepeaterRSS control
            try
            {
                sqlConn.Open();
                RepeaterRSS.DataSource = cmd.ExecuteReader();
                RepeaterRSS.DataBind();
                sqlConn.Close();
            }catch { }
        }

        protected string RemoveIllegalCharacters(object input)
        {
            // cast the input to a string
            string data = input.ToString();

            // replace illegal characters in XML documents with their entity references
            data = data.Replace("&", "&amp;");
            data = data.Replace("\"", "&quot;");
            data = data.Replace("'", "&apos;");
            data = data.Replace("<", "&lt;");
            data = data.Replace(">", "&gt;");

            return data;
        }
    }
}