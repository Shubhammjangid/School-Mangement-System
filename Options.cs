using System;
using System.Data.SqlClient;

namespace StudentMangement
{
    public class Options
    {
        public void opionss()
        {
            Console.WriteLine("Press 1 to check if your alerdy registered");
            Console.WriteLine("Press 2 to register in our school )");
            Console.WriteLine("Press 3 to login");
            Console.WriteLine("Press 4 to exit ");
            Console.WriteLine("Press 5 if your teacher/Admin login");
            Console.WriteLine("Enter your choice");
        }
    }

    public class LoginOption
    {
        public void loginOptionss()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Press 1 to check your result");
            Console.WriteLine("Press 2 to check your remaining fee");
            Console.WriteLine("Press 3 to mark  your attendence");
            Console.WriteLine("press 4 to logout from your account");
            Console.Write("Your reponse ---->");
        }
    }

    public class AdminOptios
    {
        public void adminOption()
        {
            Console.WriteLine("Press 1 to see recent logs");
            Console.WriteLine("Press 2 to UPDATE from database");
            Console.WriteLine("Press 3 to DELETE user from database");
            Console.WriteLine("Press 4 to exit");
        }
    }
}