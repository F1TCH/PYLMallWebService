using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EWDTWebService.Class
{
    public class RentDBManager
    {



        public static UserProfile GetProfilebyUsername(string user) //get user profile
        {
            UserProfile m = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM ewdtdb. WHERE nric=@nric";
                comm.Parameters.AddWithValue("@username", user);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    m = new UserProfile();
                    m.nric = (string)dr["nric"];
                    m.Telno = Convert.ToInt32((int)dr["Telno"]);
                    m.Handphno = Convert.ToInt32((int)dr["Handphno"]);
                    m.gender = (string)dr["gender"];
                    m.address = (string)dr["address"];
                    m.DoB = (string)dr["DoB"];
                    m.SQ1 = (string)dr["SQ1"];
                    m.SQ2 = (string)dr["SQ2"];
                    m.SQAns1 = (string)dr["SQAns1"];
                    m.SQAns2 = (string)dr["SQAns2"];
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

        public static int InsertUserProfile(UserProfile u)//create profile
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
                comm.CommandText = "INSERT INTO UserProfile(nric,Telno,Handphno,gender,address,DoB,SQ1,SQ2,SQAns1,SQAns2)"
                    + " VALUES (@nric,@Telno,@Handphno,@gender,@address,@DoB,@SQ1,@SQ2,@SQAns1,@SQAns2)";
                comm.Parameters.AddWithValue("@nric", u.nric);
                comm.Parameters.AddWithValue("@Telno", u.Telno);
                comm.Parameters.AddWithValue("@Handphno", u.Handphno);
                comm.Parameters.AddWithValue("@gender", u.gender);
                comm.Parameters.AddWithValue("@address", u.address);
                comm.Parameters.AddWithValue("@DoB", u.DoB);
                comm.Parameters.AddWithValue("@SQ1", u.SQ1);
                comm.Parameters.AddWithValue("@SQ2", u.SQ2);
                comm.Parameters.AddWithValue("@SQAns1", u.SQAns1);
                comm.Parameters.AddWithValue("@SQAns2", u.SQAns2);
                rowsinserted = comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static int DeleteUserProfile(string user)
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
                comm.CommandText = "Delete * from UserProfile where Username=@Username";
                comm.Parameters.AddWithValue("@Username", user);
                rowsdeleted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsdeleted;
        }

        public static int UpdateUserProfile(UserProfile u)
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
                comm.CommandText = "UPDATE UserProfile SET nric=@nric,Telno=@Telno,Handphno=@Handphno,gender=@gender,address=@address,DoB=@DoB,SQ1=@SQ1,SQ2=@SQ2,SQAns1=@SQAns1,SQAns2=@SQAns2";
                comm.Parameters.AddWithValue("@nric", u.nric);
                comm.Parameters.AddWithValue("@Telno", u.Telno);
                comm.Parameters.AddWithValue("@Handphno", u.Handphno);
                comm.Parameters.AddWithValue("@gender", u.gender);
                comm.Parameters.AddWithValue("@address", u.address);
                comm.Parameters.AddWithValue("@DoB", u.DoB);
                comm.Parameters.AddWithValue("@SQ1", u.SQ1);
                comm.Parameters.AddWithValue("@SQ2", u.SQ2);
                comm.Parameters.AddWithValue("@SQAns1", u.SQAns1);
                comm.Parameters.AddWithValue("@SQAns2", u.SQAns2);
                rowsupdated = comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsupdated;
        }
        
    }
}