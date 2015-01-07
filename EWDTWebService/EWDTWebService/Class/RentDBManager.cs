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
        //Login CRUD//
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

        public static int Register(UserAccount u)
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
                comm.CommandText = "INSERT INTO UserAccount(username, password, email)" +
                    " VALUES (@username, @password, @email)";
                comm.Parameters.AddWithValue("@username", u.username);
                comm.Parameters.AddWithValue("@password", u.password);
                comm.Parameters.AddWithValue("@email", u.email);
                rowsinserted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static int UpdateEmail(UserAccount u)
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
                comm.CommandText = "UPDATE UserAccount SET email=@email where username = @username";
                comm.Parameters.AddWithValue("@email", u.email);
                comm.Parameters.AddWithValue("@username", u.username);
                rowsinserted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static int UpdatePassword(UserAccount u)
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
                comm.CommandText = "UPDATE UserAccount SET password=@password where username = @username";
                comm.Parameters.AddWithValue("@password", u.password);
                comm.Parameters.AddWithValue("@username", u.username);
                rowsinserted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static string GetPassword(UserAccount u)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT password FROM UserAccount where username = @username";
                comm.Parameters.AddWithValue("@username", u.username);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    return dr.GetString(0);
                }
                dr.Close();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return "";
        }

        public static string GetEmail(string username)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT email FROM UserAccount where username = @username";
                comm.Parameters.AddWithValue("@username", username);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    return dr.GetString(0);
                }
                dr.Close();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return "";
        }

        public static int DeleteAccount(string username)
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
                comm.CommandText = "DELETE FROM UserAccount where username=@username";
                comm.Parameters.AddWithValue("@username", username);
                rowsdeleted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsdeleted;
        }
        //END//


        public static int RegisterProfile(UserClass u)
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
                comm.CommandText = "INSERT INTO UserProfile(nric, Telno, Handphno, gender, DoB, SQ1, SQ2, SQAns1, SQAns2, username)" +
                    " VALUES (@nric, @Telno, @Handphno, @gender, @DoB, @SQ1, @SQ2, @SQAns1, @SQAns2, @username)";
                comm.Parameters.AddWithValue("@nric", u.NRIC);
                comm.Parameters.AddWithValue("@Telno", u.TelephoneNo);
                comm.Parameters.AddWithValue("@Handphno", u.HandphoneNo);
                comm.Parameters.AddWithValue("@gender", u.Gender);
                comm.Parameters.AddWithValue("@DoB", u.DoB);
                comm.Parameters.AddWithValue("@SQ1", u.SQ1);
                comm.Parameters.AddWithValue("@SQ2", u.SQ2);
                comm.Parameters.AddWithValue("@SQAns1", u.SQAns1);
                comm.Parameters.AddWithValue("@SQAns2", u.SQAns2);
                comm.Parameters.AddWithValue("@username", u.Username);

                rowsinserted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static int UpdateProfile(UserClass u)
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
                comm.CommandText = "Update UserProfile SET Telno = @Telno, Handphno = @Handphno WHERE username = @username";
                comm.Parameters.AddWithValue("@Telno", u.TelephoneNo);
                comm.Parameters.AddWithValue("@Handphno", u.HandphoneNo);
                comm.Parameters.AddWithValue("@username", u.Username);
                rowsinserted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static UserClass GetProfile(string username)
        {
            UserClass b = new UserClass();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM UserProfile where username = @username";
                comm.Parameters.AddWithValue("@username", username);
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {

                    b.NRIC = (string)dr["nric"];
                    b.TelephoneNo = (int)dr["Telno"];
                    b.HandphoneNo = (int)dr["Handphno"];
                    b.Gender = (string)dr["Gender"];
                }

                dr.Close();
                conn.Close();
                return b;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public static int DeleteProfile(string username)
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
                comm.CommandText = "DELETE FROM UserAccount where username=@username";
                comm.Parameters.AddWithValue("@username", username);
                rowsdeleted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsdeleted;
        }

        public static int CreateFloorPlan(FloorPlanClass c)
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
                comm.CommandText = "INSERT INTO FloorPlan(Unit,UnitLevel,Name,Price,Condition,Imagefile)" +
                    " VALUES (@Unit,@UnitLevel,@Name,@Price,@Condition,@Imagefile)";
                comm.Parameters.AddWithValue("@Unit", c.Unit);
                comm.Parameters.AddWithValue("@UnitLevel", c.UnitLevel);
                comm.Parameters.AddWithValue("@Name", c.Name);
                comm.Parameters.AddWithValue("@Price", c.Price);
                comm.Parameters.AddWithValue("@Condition", c.Condition);
                comm.Parameters.AddWithValue("@Imagefile", c.Imagefile);
                rowsinserted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static int RetrieveFloorPlan(FloorPlanClass r)
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
                comm.CommandText = "SELECT * FROM FloorPlan";

                comm.Parameters.AddWithValue("@Unit", r.Unit);
                comm.Parameters.AddWithValue("@UnitLevel", r.UnitLevel);
                comm.Parameters.AddWithValue("@Name", r.Name);
                comm.Parameters.AddWithValue("@Price", r.Price);
                comm.Parameters.AddWithValue("@Condition", r.Condition);
                comm.Parameters.AddWithValue("@Imagefile", r.Imagefile);
                rowsinserted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static int UpdateFloorPlan(FloorPlanClass u)
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
                comm.CommandText = "UPDATE FloorPlan SET Unit=@Unit,UnitLevel=@UnitLevel,Name=@Name,Price=@Price,Condition=@Condition,Imagefile=@Imagefile";

                comm.Parameters.AddWithValue("@Unit", u.Unit);
                comm.Parameters.AddWithValue("@UnitLevel", u.UnitLevel);
                comm.Parameters.AddWithValue("@Name", u.Name);
                comm.Parameters.AddWithValue("@Price", u.Price);
                comm.Parameters.AddWithValue("@Condition", u.Condition);
                comm.Parameters.AddWithValue("@Imagefile", u.Imagefile);
                rowsinserted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static int DeleteFloorPlan(string d)
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
                comm.CommandText = "DELETE * FROM Floorplan where Unit=@Unit";
                comm.Parameters.AddWithValue("@Unit", d);
                rowsdeleted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsdeleted;
        }

        public static int CreateBid(BidClass c)
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
                comm.CommandText = "INSERT INTO Bidding(BiddingAmt,Time,Date,username)" +
                    " VALUES (@BiddingAmt,@Time,@Date,@username)";
                comm.Parameters.AddWithValue("@BiddingAmt", c.BiddingAmt);
                comm.Parameters.AddWithValue("@Time", c.Time);
                comm.Parameters.AddWithValue("@Date", c.Date);
                comm.Parameters.AddWithValue("@username", c.Username);
                rowsinserted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static BidClass RetrieveBid(string username)
        {
            BidClass s = new BidClass();

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM Bidding WHERE username = @username";

                comm.Parameters.AddWithValue("@username", username);
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    s.BiddingAmt = (string)dr["BiddingAmt"];
                    s.Date = (string)dr["Date"].ToString();
                    s.Time = (string)dr["Time"];
                }

                dr.Close();
                conn.Close();
                return s;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public static int UpdateBid(BidClass u)
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
                comm.CommandText = "UPDATE Bidding SET BiddingAmt=@BiddingAmt,Time=@Time,Date=@Date where username = @Username";

                comm.Parameters.AddWithValue("@BiddingAmt", u.BiddingAmt);
                comm.Parameters.AddWithValue("@Time", u.Time);
                comm.Parameters.AddWithValue("@Date", u.Date);
                comm.Parameters.AddWithValue("@Username", u.Username);

                rowsinserted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static int DeleteBid(string username)
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
                comm.CommandText = "DELETE FROM bidding where username=@Username";
                comm.Parameters.AddWithValue("@Username", username);
                rowsdeleted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsdeleted;
        }
    }
}