using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentMangement
{
    internal class Program
    {
        
        static string connectionString = "SERVER = LAPTOP-C59IR2RT\\SQLEXPRESS; DATABASE=SchoolManagement; USER ID=root; PASSWORD = root@123 ";
        static SqlConnection sqlconn = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            Options option = new Options();
            AdminOptios admin = new AdminOptios();
            Addoption adduser = new Addoption();
            Login login = new Login();
            User user = new User();
            using(sqlconn)
            {
                try
                {
                    sqlconn.Open();

                    bool Value = false;

                    while(!Value)
                    {
                        option.opionss();
                        int userInput = Convert.ToInt32(Console.ReadLine());

                        switch (userInput)
                        {

                           case 1:
                                if(user.UsernameCheck())
                                {
                                    Console.WriteLine("You are already register");
                                }
                                else
                                {
                                    Console.WriteLine("You are not registered register yourself");
                                }
                                break;

                            case 2:
                                adduser.options();
                                sqlconn.Close();
                                break;

                            case 3:
                                login.userLogin();
                                break;

                            case 4:
                                Console.WriteLine("Enter 4 once again to exit");
                                int userExit = Convert.ToInt32(Console.ReadLine());

                                if(userExit==4)
                                {
                                    sqlconn.Close();
                                    Value=true;
                                }
                                else
                                {
                                    Value=false;
                                }
                                break;

                            case 5:
                                admin.adminOption();
                                break;
                                
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}