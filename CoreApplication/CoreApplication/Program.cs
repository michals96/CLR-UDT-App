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
            string sql = @"DATA SOURCE=MSSQLServer;" + 
                "INITIAL CATALOG=projectdb; INTEGRATED SECURITY=SSPI;";
            SqlConnection connect = new SqlConnection(sql);
            while(true)
            {
                Console.WriteLine(" -- MENU -- \n");
                Console.Write("1. Rectangle\n");
                Console.Write("2. Exit\n");
                string option = Console.ReadLine();
                try
                {
                    connect.Open();
                    switch (int.Parse(option))
                    {
                        case 1:
                            {
                                Console.WriteLine("--RECTANGLE MENU--");
                                Console.WriteLine("1 - List rectangle");
                                Console.WriteLine("2 - Add rectangles");
                                string opt = Console.ReadLine();
                                if (opt == "1")
                                {
                                    Console.WriteLine("Height\tWidth\tField");
                                    string query = "SELECT shape.Height as H, shape.Width as W, shape.Field as F from Rectangles";
                                    SqlCommand execute = new SqlCommand(query, connect);
                                    SqlDataReader getData = execute.ExecuteReader();
                                    while(getData.Read())
                                    {
                                        Console.WriteLine("{0}\t{1}\t{2}",
                                            getData["H"],
                                            getData["W"],
                                            getData["F"]);
                                    }
                                    Console.WriteLine("\n");
                                    getData.Close();
                                }
                                if (opt == "2")
                                {
                                    Console.WriteLine("Insert width");
                                    string val = Console.ReadLine();
                                    val += ",";
                                    Console.WriteLine("Insert height");
                                    val += Console.ReadLine();
                                    string query = "INSERT into Rectangles (shape) values('" + val + "')";
                                    SqlCommand sqlQuery = new SqlCommand(query, connect);
                                    SqlDataReader addData = sqlQuery.ExecuteReader();
                                    addData.Close();
                                    Console.WriteLine("\n");
                                }
                                break;
                            }
                        case 2:
                            Console.WriteLine("EXIT\n");
                            break;
                        default:
                            break;
                    }
                }
                catch (SqlException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    connect.Close();
                }

                Console.ReadKey(); 
            }
        }
    }
}
