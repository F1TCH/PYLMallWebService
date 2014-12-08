using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace EWDTWebServiceApp.Models
{
    public class RentDBManager
    {
        public static ArrayList GetAllUser()
        {
            ArrayList result = new ArrayList();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * from User";
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    UserClass m = new UserClass();
                    m.Username = (string)dr["Username"];
                    m.Password = (string)dr["Password"];
                    m.NRIC = (string)dr["NRIC"];
                    m.Email = (string)dr["Email"];
                    m.TelephoneNo = (int)dr["TelephoneNo"];
                    m.HandphoneNo = (int)dr["HandphoneNo"];
                    m.Gender = (string)dr["Gender"];
                    m.Address = (string)dr["Address"];
                    m.DoB = (string)dr["DoB"];
                    m.SQ1 = (string)dr["SQ1"];
                    m.SQ2 = (string)dr["SQ2"];
                    m.SQAns1 = (string)dr["SQAns1"];
                    m.SQAns2 = (string)dr["SQAns2"];
                    result.Add(m);
                }
                dr.Close();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return result;
        }
        public static UserClass GetUserbyUsername(string user)
        {
            UserClass u = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM User WHERE Username=@Username";
                comm.Parameters.AddWithValue("@Username", user);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    u = new UserClass();
                    u.Username = (string)dr["Username"];
                    u.Password = (string)dr["Password"];
                    u.NRIC = (string)dr["NRIC"];
                    u.Email = (string)dr["Email"];
                    u.TelephoneNo = (int)dr["TelephoneNo"];
                    u.HandphoneNo = (int)dr["HandphoneNo"];
                    u.Gender = (string)dr["Gender"];
                    u.Address = (string)dr["Address"];
                    u.DoB = (string)dr["DoB"];
                    u.SQ1 = (string)dr["SQ1"];
                    u.SQ2 = (string)dr["SQ2"];
                    u.SQAns1 = (string)dr["SQAns1"];
                    u.SQAns2 = (string)dr["SQAns2"];
                }
                dr.Close();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }

            return u;
        }
        public static int InsertUser(UserClass u)
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
                comm.CommandText = "INSERT INTO User(Username,Password,NRIC,Email,TelephoneNo,HandphoneNo,Gender,Address,DoB,SQ1,SQ2,SQAns1,SQAns2)" +
                    " VALUES (@Username,@Password,@NRIC,@Email,@TelephoneNo,@HandphoneNo,@Gender,@Address,@DoB,@SQ1,@SQ2,@SQAns1,@SQAns2)";
                comm.Parameters.AddWithValue("@Username", u.Username);
                comm.Parameters.AddWithValue("@Password", u.Password);
                comm.Parameters.AddWithValue("@NRIC", u.NRIC);
                comm.Parameters.AddWithValue("@Email", u.Email);
                comm.Parameters.AddWithValue("@TelephoneNo", u.TelephoneNo);
                comm.Parameters.AddWithValue("@HandphoneNo", u.HandphoneNo);
                comm.Parameters.AddWithValue("@Gender", u.Gender);
                comm.Parameters.AddWithValue("@Address", u.Address);
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
        public static int UpdateUser(UserClass u)
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
                comm.CommandText = "UPDATE User SET Username=@Username,Password=@Password,NRIC=@NRIC,Email=@Email,TelephoneNo=@TelephoneNo,HandphoneNo=@HandphoneNo,Gender=@Gender,Address=@Address,DoB=@DoB,SQ1=@SQ1,SQ2=@SQ2,SQAns1=@SQAns1,SQAns2=@SQAns2";
                comm.Parameters.AddWithValue("@Username", u.Username);
                comm.Parameters.AddWithValue("@Password", u.Password);
                comm.Parameters.AddWithValue("@NRIC", u.NRIC);
                comm.Parameters.AddWithValue("@Email", u.Email);
                comm.Parameters.AddWithValue("@TelephoneNo", u.TelephoneNo);
                comm.Parameters.AddWithValue("@HandphoneNo", u.HandphoneNo);
                comm.Parameters.AddWithValue("@Gender", u.Gender);
                comm.Parameters.AddWithValue("@Address", u.Address);
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
                comm.CommandText = "Delete from User where Username=@Username";
                comm.Parameters.AddWithValue("@Username", user);
                rowsdeleted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsdeleted;
        }

        public static ArrayList GetAllBid()
        {
            ArrayList result = new ArrayList();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * from Bidding";
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    BidClass b = new BidClass();
                    b.BiddingAmt = (double)dr["BiddingAmt"];
                    b.Date = (string)dr["Date"];
                    b.Time = (string)dr["Time"];
                    result.Add(b);
                }
                dr.Close();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return result;
        }

        public static BidClass GetBidByBidAmt(double bid)
        {
            BidClass b = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM Bidding WHERE Bid=@BiddingAmt";
                comm.Parameters.AddWithValue("@BiddingAmt", bid);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    b = new BidClass();
                    b.BiddingAmt = (double)dr["BiddingAmt"];
                    b.Date = (string)dr["Date"];
                    b.Time = (string)dr["Time"];
                }
                dr.Close();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }

            return b;
        }

        public static int InsertBid(BidClass b)
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
                comm.CommandText = "INSERT INTO Bidding(BiddingAmt,Date,Time)" +
                    " VALUES (@BiddingAmt,@Date,@Time)";
                comm.Parameters.AddWithValue("@BiddingAmt", b.BiddingAmt);
                comm.Parameters.AddWithValue("@Date", b.Date);
                comm.Parameters.AddWithValue("@Time", b.Time);
                rowsinserted = comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static int UpdateBid(BidClass b)
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
                comm.CommandText = "UPDATE Bidding SET BiddingAmt=@BiddingAmt,Date=@Date,Time=@Time";
                comm.Parameters.AddWithValue("@BiddingAmt", b.BiddingAmt);
                comm.Parameters.AddWithValue("@Date", b.Date);
                comm.Parameters.AddWithValue("@Time", b.Time);
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsupdated;
        }
        public static int DeleteBid(double bid)
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
                comm.CommandText = "Delete from Bidding where BiddingAmt=@BiddingAmt";
                comm.Parameters.AddWithValue("@BiddingAmt", bid);
                rowsdeleted = comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsdeleted;
        }


        public static ArrayList GetAllFloorPlan()
        {
            ArrayList result = new ArrayList();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * from FloorPlan";
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    FloorPlanClass f = new FloorPlanClass();
                    f.Unit = (string)dr["Unit"];
                    f.UnitLevel = (int)dr["UnitLevel"];
                    f.Name = (string)dr["Name"];
                    f.Price = (double)dr["Price"];
                    f.Condition = (string)dr["Condition"];
                    f.Imagefile = (string)dr["Imagefile"];
                    result.Add(f);
                }
                dr.Close();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return result;
        }

        public static FloorPlanClass GetFloorPlanbyUnit(string unit)
        {
            FloorPlanClass f = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["EWDTdbConnectionString"].ConnectionString;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM FloorPlan WHERE Unit=@Unit";
                comm.Parameters.AddWithValue("@Unit", unit);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    f = new FloorPlanClass();
                    f.Unit = (string)dr["Unit"];
                    f.UnitLevel = (int)dr["UnitLevel"];
                    f.Name = (string)dr["Name"];
                    f.Price = (double)dr["Price"];
                    f.Condition = (string)dr["Condition"];
                    f.Imagefile = (string)dr["Imagefile"];
                }
                dr.Close();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }

            return f;
        }

        public static int InsertFloor(FloorPlanClass f)
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
                comm.Parameters.AddWithValue("@Unit", f.Unit);
                comm.Parameters.AddWithValue("@UnitLevel", f.UnitLevel);
                comm.Parameters.AddWithValue("@Name", f.Name);
                comm.Parameters.AddWithValue("@Price", f.Price);
                comm.Parameters.AddWithValue("@Condition", f.Condition);
                comm.Parameters.AddWithValue("@Imagefile", f.Imagefile);
                rowsinserted = comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsinserted;
        }

        public static int UpdateFloorPlan(FloorPlanClass f)
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
                comm.CommandText = "UPDATE FloorPlan SET Unit=@Unit,UnitLevel=@UnitLevel,Name=@Name,Price=@Price,Condition=@Condition,Imagefile=@Imagefile";
                comm.Parameters.AddWithValue("@Unit", f.Unit);
                comm.Parameters.AddWithValue("@UnitLevel", f.UnitLevel);
                comm.Parameters.AddWithValue("@Name", f.Name);
                comm.Parameters.AddWithValue("@Price", f.Price);
                comm.Parameters.AddWithValue("@Condition", f.Condition);
                comm.Parameters.AddWithValue("@Imagefile", f.Imagefile);
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rowsupdated;
        }
        public static int DeleteFloorPlan(string unit)
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
                comm.CommandText = "Delete from FloorPlan where Unit=@Unit";
                comm.Parameters.AddWithValue("@Unit", unit);
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