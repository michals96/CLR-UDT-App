using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nHello world!\n");
            Console.WriteLine("\npress any key to exit the process...");
            string sql = @"DATA SOURCE=MSSQLServer;" + 
                "INITIAL CATALOG=projectdb; INTEGRATED SECURITY=SSPI;";
            SqlConnection connect = new SqlConnection(sql);
            Console.Write("1. Rectangle\n");
            Console.Write("2. Exit\n");
            string option = Console.ReadLine();
            switch (int.Parse(option))
            {
                case 1:
                    Console.WriteLine("RECTANGLE\n");
                    break;
                case 2:
                    Console.WriteLine("EXIT\n");
                    break;
                default:
                    break;
            }
            Console.ReadKey(); 
        }
    }
}
