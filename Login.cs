using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentMangement
{
    
    public class Login
    {
        static string connectionString = "SERVER = LAPTOP-C59IR2RT\\SQLEXPRESS; DATABASE=SchoolManagement; USER ID=root; PASSWORD = root@123 ";
        static SqlConnection sqlconn = new SqlConnection(connectionString);
        public void userLogin()
        {
            
            LoginOption loginoption = new LoginOption();
            UserAttendence attendence = new UserAttendence();
            userFee fee = new userFee();
            Results res = new Results();
            string? username;
            int? rCode;
            Console.WriteLine("Enter your username");
            string? userE = Console.ReadLine();

            Console.WriteLine("Enter your passCode");
            int uCode = Convert.ToInt32(Console.ReadLine());

            try
            {
                string querry = "SELECT * FROM STUDENTDE WHERE USERNAME = '" + userE +"' AND PASSWORD = '" + uCode +"'";
                SqlDataAdapter sqd = new SqlDataAdapter(querry,sqlconn);
                DataTable dtable = new DataTable();

                sqd.Fill(dtable);

                if(dtable.Rows.Count>0)
                {
                    username= userE;

                    rCode = uCode;

                    foreach(DataRow row in dtable.Rows)
                    {
                        Console.WriteLine($"Hello {row["NAME"]} welcome to dashboard");
                       
                    }
                      loginoption.loginOptionss();

                      int loginChoice = Convert.ToInt32(Console.ReadLine());

                     
                          switch(loginChoice)
                        {

                            #region Case
                                
                          
                            case 1:
                                res.userResult();
                                break;
                            
                            case 2:
                                fee.feeStatus();
                                break;

                            case 3:
                                attendence.userAttend();
                                break;

                            case 4:
                                Console.WriteLine("Ok ,bye");
                                break;

                            default:
                                Console.WriteLine("Enter information properly or contact admin");
                                break;

                            #endregion
                        }
                }
                else
                {
                    Console.WriteLine("Invalid email id or passcode");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    
    }
}