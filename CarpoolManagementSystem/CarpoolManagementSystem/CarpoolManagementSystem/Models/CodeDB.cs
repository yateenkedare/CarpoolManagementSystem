using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;


namespace LoginSignup.Models
{
    public class CodeDB
    {
        //variable connection
        protected SqlConnection con;

        //open connection
        public bool Open(string Connection = "DefaultConnection")
        {
            con = new SqlConnection(@WebConfigurationManager.ConnectionStrings[Connection].ToString());
            try
            {
                bool bRet = true;
                if (con.State.ToString() != "Open")
                {
                    con.Open();
                }
                return bRet;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        //close connection
        public bool Close(string Connection = "DefaultConnection")
        {
            try
            {
                bool bRet = true;

                con.Close();
                return bRet;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public int ToInt(object s)
        {
            try
            {
                return Int32.Parse(s.ToString());
            }
            catch
            {
                return 0;
            }
        }

        //Insert into DB 
        public int DataInsert(string sql)
        {
            int iLastID = 0;
            string szQuery = sql + ";SELECT @@Identity;";
            try
            {
                if (con.State.ToString() == "Open")
                {
                    SqlCommand cmd = new SqlCommand(szQuery, con);

                    cmd.ExecuteReader();// */ExecuteNonQuery();

                    iLastID = this.ToInt(cmd.ExecuteScalar());                    
                }
                return this.ToInt(iLastID);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public SqlDataReader DataRetrieve(string sql)
        {
            int iLastID = 0;
            string szQuery = sql + ";SELECT @@Identity;";
            SqlDataReader reader=null;
            try
            {
                if (con.State.ToString() == "Open")
                {
                    SqlCommand cmd = new SqlCommand(szQuery, con);

                    reader = cmd.ExecuteReader();// */ExecuteNonQuery();

                    //iLastID = this.ToInt(cmd.ExecuteScalar());
                }
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}