using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class DBLayer
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        public List<BObjects> GetAllDataFromPasteBin()
        {
            List<BObjects> AllFromPasteBin = new List<BObjects>();



            conn.Open();
            SqlCommand cmd = new SqlCommand($"Select * From PasteBinTable", conn);



            SqlDataReader reader = cmd.ExecuteReader();



            while (reader.Read())
            {
                BObjects afpb = new BObjects();
                afpb.ID = (int)reader["ID"];
                afpb.PasteBinText = (string)reader["PasteBinText"];
                afpb.GUID = (string)reader["GUID"];
                afpb.Private = (bool)reader["Private"];
                afpb.PrivatePassword = (string)reader["PrivatePassword"];
                afpb.CreationDate = (DateTime)reader["CreationDate"];
                afpb.LastVisited = (DateTime)reader["LastVisited"];
                afpb.ExpirationDate = (DateTime)reader["ExpirationDate"];
                afpb.BurnAfterReading = (bool)reader["BurnAfterReading"];
                afpb.BurnAfterReadingTrue = (int)reader["BurnAfterReadingTrue"];
                AllFromPasteBin.Add(afpb);
            }
            reader.Close();
            conn.Close();



            return AllFromPasteBin;
        }

        public void InsetPasteBinTextIntoDatabase(string PasteBinText, string GUID, bool Private, string PrivatePassword, DateTime CreationDate, DateTime LastVisited, DateTime ExpirationDate, bool BurnAfterReading, int BurnAfterReadingTrue)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO PasteBinTable (PasteBinText, GUID, Private, PrivatePassword, CreationDate, LastVisited, ExpirationDate, BurnAfterReading, BurnAfterReadingTrue) VALUES (@pbt, @gui, @pri, @prp, @cd, @lv, @ed, @bar, @bart);", conn);

                cmd.Parameters.AddWithValue("pbt", PasteBinText);
                cmd.Parameters.AddWithValue("gui", GUID);
                cmd.Parameters.AddWithValue("pri", Private);
                cmd.Parameters.AddWithValue("prp", PrivatePassword);
                cmd.Parameters.AddWithValue("cd", CreationDate);
                cmd.Parameters.AddWithValue("lv", LastVisited);
                cmd.Parameters.AddWithValue("ed", ExpirationDate);
                cmd.Parameters.AddWithValue("bar", BurnAfterReading);
                cmd.Parameters.AddWithValue("bart", BurnAfterReadingTrue);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        public void DeleteWhereExpirationDate()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM PasteBinTable WHERE ExpirationDate <= @dtn", conn);

                cmd.Parameters.AddWithValue("dtn", DateTime.Now);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        public void UpdateBurnAfterReadingTrue(int BurnAfterReadingTrue, string GUIDFromDB)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE PasteBinTable SET BurnAfterReadingTrue = @bart WHERE GUID = @guidfdb;", conn);

                cmd.Parameters.AddWithValue("bart", BurnAfterReadingTrue);
                cmd.Parameters.AddWithValue("guidfdb", GUIDFromDB);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        public void BurnAfterReadingDeleteWhereGUID(string GUIDFromDB)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM PasteBinTable WHERE GUID = @guidfdb", conn);

                cmd.Parameters.AddWithValue("guidfdb", GUIDFromDB);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        public void UpdateLastVisited(string GUID)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE PasteBinTable SET LastVisited = @dtn WHERE GUID = @guid;", conn);

                cmd.Parameters.AddWithValue("dtn", DateTime.Now);
                cmd.Parameters.AddWithValue("guid", GUID);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (ArgumentOutOfRangeException) { }
        }
    }
}
