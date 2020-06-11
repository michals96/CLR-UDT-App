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
            Console.ReadKey(); 
        }
    }
}
