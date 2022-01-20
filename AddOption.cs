using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentMangement
{
    
    public class Addoption
    {
        static string connectionString = "SERVER = LAPTOP-C59IR2RT\\SQLEXPRESS; DATABASE=SchoolManagement; USER ID=root; PASSWORD = root@123 ";
        static SqlConnection sqlconn = new SqlConnection(connectionString);
 
       
        public void options()
        {
           
            Console.WriteLine("Enter your Name");
            string? NameEx = Console.ReadLine();

            Console.WriteLine("Enter your Email");
            string? userEmail =Console.ReadLine();

            Console.WriteLine("Enter your Father's Name");
            string? userFather = Console.ReadLine();

            Console.WriteLine("Enter your Mother's Name");
            string? userMother = Console.ReadLine();

            Console.WriteLine("Enter your perment address");
            string? userAddress = Console.ReadLine();

            Console.WriteLine("Enter your Mobile Number");
            string? userNumber = Console.ReadLine();

            Console.WriteLine("Enter your username to futher login in system");
            string? userUname = Console.ReadLine();

            Console.WriteLine("Enter your passCode");
            int Code  = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your passcode once again");
            int ReCode = Convert.ToInt32(Console.ReadLine());

            if(Code==ReCode)
            {
                sqlconn.Open();
                string insertQuery = "INSERT INTO STUDENTDE(USERNAME,EMAIL,PASSWORD,NAME,FATHER_NAME,MOTHER_NAME,ADDRESS,MOBILE) VALUES('"+userUname +"','"+ userEmail +"','"+ Code +"','"+ NameEx +"','" + userFather + "' ,'" + userMother + "','" +userAddress+"' , '" +userNumber+"' )";
                SqlCommand insertCommand = new SqlCommand(insertQuery,sqlconn);
                insertCommand.ExecuteNonQuery();
                sqlconn.Close();
            }

            else
            {
                Console.WriteLine("Something went wrong");
                sqlconn.Close();
                
            }

        }
    }
}