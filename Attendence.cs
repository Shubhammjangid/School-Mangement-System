using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentMangement
{
    public class UserAttendence
    {
         static string connectionString = "SERVER = LAPTOP-C59IR2RT\\SQLEXPRESS; DATABASE=SchoolManagement; USER ID=root; PASSWORD = root@123 ";
         static SqlConnection sqlconn = new SqlConnection(connectionString);

        public void userAttend()
        {
            try
            {
                String? Attend;
                string Example = "NULL";
                string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
                Console.WriteLine("Enter your username once to go forther");
                string? attUsername = Console.ReadLine();
                Console.WriteLine("Press 1 to mark your attendence for today");
                Console.WriteLine("Press 2 to mark your leave/absent today");
            
                int userChoice = Convert.ToInt32(Console.ReadLine());

                sqlconn.Open();

                string InsertUsername = "INSERT INTO ATTENDENCE(USERNAME,DATE,ATTNENDE) VALUES('"+attUsername+"', '"+date+"' , '"+Example+"')";
                SqlCommand insertCommand = new SqlCommand(InsertUsername,sqlconn);
                insertCommand.ExecuteNonQuery();

                if(userChoice==1)
                {
                    Attend="PRESENT";
                    
                    string Attendence = "INSERT INTO ATTENDENCE(ATTEND) = '"+ Attend+"' ";
                    SqlCommand updateAttendence = new SqlCommand(Attendence,sqlconn);
                    updateAttendence.ExecuteNonQuery();
                   
                }
                else
                {
                    Attend="ABSENT";
                    string Attendence = "INSERT INTO ATTENDENCE(ATTEND) = '"+ Attend +"'  ";
                   
                    SqlCommand updateAttendence = new SqlCommand(Attendence,sqlconn);
                    updateAttendence.ExecuteNonQuery();
                    

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}