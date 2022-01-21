using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentMangement
{
    public class Results
    {
        static string connectionString = "SERVER = LAPTOP-C59IR2RT\\SQLEXPRESS; DATABASE=SchoolManagement; USER ID=root; PASSWORD = root@123 ";
        static SqlConnection sqlconn = new SqlConnection(connectionString);
        public void userResult()
        {
           
            sqlconn.Open();
            string userRemark;
            int total = 500;

            Console.WriteLine("Enter your username");
            string? UserName = Console.ReadLine();

            Console.WriteLine("Enter your mark of firs subect S01");
            int S01 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your mark of firs subect S02");
            int S02 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your mark of firs subect S04");
            int S04 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your mark of firs subect S05");
            int S05 = Convert.ToInt32(Console.ReadLine());

            int Totalobatined = S01 + S02 + S04 + S05;

            double Percentage = (Totalobatined/total)*100;

            if(Percentage>35)
            {
                userRemark = "PASS";
            }
            else
            {
                 userRemark = "FAIL";
            }

            string insertQuery = "INSERT INTO RESULT(USERNAME,S01,S02,S04,S05,REMARK,TOTAL) VALUES('"+UserName +"','"+ S01 +"','"+ S02 +"','" + S04 + "' ,'" + S05 + "','" +userRemark+"','"+Totalobatined+"' )";
            SqlCommand insertCommand = new SqlCommand(insertQuery,sqlconn);
            insertCommand.ExecuteNonQuery();

            
        }
    }
}