using System;
using System.Data.SqlClient;

namespace StudentMangement
{
    public class User
    {
        static string connectionString = "SERVER = LAPTOP-C59IR2RT\\SQLEXPRESS; DATABASE=SchoolManagement; USER ID=root; PASSWORD = root@123 ";
    
        static SqlConnection sqlconn = new SqlConnection(connectionString);
        public bool UsernameCheck(string? userEmailID)
    {
            // sqlconn.Open();
            bool isUserExisted=false;

            SqlCommand cmd = new SqlCommand("Select * from STUDENTDE where EMAIL= @EMAIL",sqlconn);
            cmd.Parameters.AddWithValue("@EMAIL", userEmailID);
            sqlconn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
            if (dr.HasRows == true)
            {
            isUserExisted=true;
            // sqlconn.Close();
            break;
            }
            }
            sqlconn.Close();
            return isUserExisted;
           
    }
    
    }
}