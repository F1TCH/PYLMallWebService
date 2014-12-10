using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EWDTWebService.Class
{
    public class RentDBManager
    {
        public static bool Login(string input_username, string input_password)
        {
            bool successful = false;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.
                    ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM UserAccount  WHERE username=@username and password=@password";
                comm.Parameters.AddWithValue("@username", input_username);
                comm.Parameters.AddWithValue("@password", input_password);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read()) //dr.Read() will return true if there is at least one row
                {
                    successful = true;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return successful;
        }
        public static UserAccount GetUserbyUsername(string user)
        {
            UserAccount m = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MusicDBConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM UserAccount WHERE username=@username";
                comm.Parameters.AddWithValue("@username", user);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    m = new UserAccount();
                    m.username = (string)dr["username"];
                    m.password = (string)dr["password"];
                }
                dr.Close();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }

            return m;

        }
        public static int InsertUser(UserAccount u)
        {
            int rowsinserted = 0;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO User(Username,Password,Email)" +
                    " VALUES (@Username,@Password,@Email)";
                comm.Parameters.AddWithValue("@Username", u.username);
                comm.Parameters.AddWithValue("@Password", u.password);
                comm.Parameters.AddWithValue("@Email", u.email);
                rowsinserted = comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static int UpdateUserPassword(UserAccount u)
        {
            int rowsupdated = 0;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "UPDATE User SET Password=@Password WHERE username=@username";
                comm.Parameters.AddWithValue("@Username", u.username);
                comm.Parameters.AddWithValue("@Password", u.password);
                rowsupdated = comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsupdated;
        }
        public static int UpdateUserEmail(UserAccount u)
        {
            int rowsupdated = 0;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "UPDATE User SET email=@email WHERE username=@username";
                comm.Parameters.AddWithValue("@Username", u.username);
                comm.Parameters.AddWithValue("@email", u.email);
                rowsupdated = comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsupdated;
        }
        public static int DeleteUser(string user)
        {
            int rowsdeleted = 0;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "Delete from [User] where Username=@Username";
                comm.Parameters.AddWithValue("@Username", user);
                rowsdeleted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsdeleted;
        }
        public static int InsertUserProfile(UserAccount u)
        {

        }
    }
}