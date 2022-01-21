using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentMangement
{
    public class userFee
    {
        static string connectionString = "SERVER = LAPTOP-C59IR2RT\\SQLEXPRESS; DATABASE=SchoolManagement; USER ID=root; PASSWORD = root@123 ";
        static SqlConnection sqlconn = new SqlConnection(connectionString);
        public void feeStatus()
        {
           
            string? UserName;
            Console.WriteLine("RE-enter your username to check your fee");
            string? feeUsername = Console.ReadLine();

            try
            {
                string Feequerry = "SELECT * FROM FEE WHERE USERNAME = '" + feeUsername + "' ";
                 SqlDataAdapter sqd = new SqlDataAdapter(Feequerry,sqlconn);
                 DataTable feetable = new DataTable();

                 sqd.Fill(feetable);

                 if(feetable.Rows.Count>0)
                 {
                     UserName=feeUsername;

                     foreach(DataRow row in feetable.Rows)
                     {
                         int fee = (int)row["FEE"]; //remaining fee
                         string Name = (string)row["USERNAME"];
                         string? feeRemark;
                         Console.WriteLine($"HELLO {row["USERNAME"]} your remaining fee is {row["FEE"]}");
                         if(fee>0)
                         {
                             Console.WriteLine("press 1 to pay remaininf fee");
                             Console.WriteLine("Press 2 to exit");
                             int feeChoice = Convert.ToInt32(Console.ReadLine());

                             switch(feeChoice)
                             {
                                 case 1:
                                    Console.WriteLine($"{row["USERNAME"]} remaining fee is {fee}");
                                    Console.WriteLine("How much do you want to pay now");
                                    int remainFee = Convert.ToInt32(Console.ReadLine());
                                    int Finalfee = fee - remainFee;
                                    if(Finalfee>0)
                                    {
                                        feeRemark="UNPAID";
                                    }
                                    else
                                    {
                                        feeRemark="PAID";
                                    }
                                    if(remainFee>0 && fee>=remainFee)
                                    {
                                        sqlconn.Open();
                                        string payingFee = "UPDATE FEE SET FEE = '" + Finalfee + "'  WHERE USERNAME = '"+Name+"' ";
                                        string userFeeRemark = "UPDATE FEE SET REMARK = '" + feeRemark +"' WHERE USERNAME = '"+Name+"'  ";
                                        SqlCommand updaCommand = new SqlCommand(userFeeRemark,sqlconn);
                                        SqlCommand updateCommand = new SqlCommand(payingFee,sqlconn);
                                        updaCommand.ExecuteNonQuery();
                                        updateCommand.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Try again later or conatct admin");
                                    }
                                    break;
                             }
                         }

                     }
                 }
                 else
                 {
                     Console.WriteLine("No record was found please try again or contact admin");
                 }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}