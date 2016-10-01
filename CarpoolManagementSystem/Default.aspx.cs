using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
    MySql.Data.MySqlClient.MySqlCommand mySqlCommand;
    MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader;
    String queryString,name;
    protected void Page_Load(object sender, EventArgs e)
    {
        String connString = "server=localhost;user id=root;password=password;database=test;persistsecurityinfo=True";
        mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);
    }

    protected void SubmitNameMethod(object sender, EventArgs e)
    {
        try
        {
            mySqlConnection.Open();
            queryString = "INSERT INTO `test`.`test` (`Name`) VALUES ('" + NameTextBox.Text + "');";
            mySqlCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, mySqlConnection);
            mySqlCommand.ExecuteReader();
            mySqlConnection.Close();
            Response.Write("<script>alert('Name Entered successfully');</script>");


            mySqlConnection.Open();
            queryString = "SELECT * FROM `test`.`test` ORDER BY 'Number' DESC LIMIT 1";
            mySqlCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, mySqlConnection);
            mySqlDataReader = mySqlCommand.ExecuteReader();
            mySqlConnection.Close();

            if (mySqlDataReader.HasRows)
            {
                while (mySqlDataReader.Read())
                {
                    name = mySqlDataReader.GetString(0);
                }
                name = mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("Name"));
            }
            
            Response.Write("<script>alert('Hello "+ name + "');</script>");
        }
        catch
        {
            Response.Write("<script>alert('Failed to enter in database');</script>");
        }
    }
}