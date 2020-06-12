using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreApplication
{
    class Program
    {
        // Main application - handles all events
        static void Main(string[] args)
        {
            string sql = @"DATA SOURCE=MSSQLServer;" + 
                "INITIAL CATALOG=projectdb; INTEGRATED SECURITY=SSPI;";
            SqlConnection connect = new SqlConnection(sql);
            while(true)
            {
                Console.WriteLine(" -- MENU -- ");
                Console.Write("1. Rectangle\n");
                Console.Write("2. Square\n");
                Console.Write("3. Circle\n");
                Console.Write("4. Diamond\n");
                Console.Write("5. Triangle\n");
                Console.Write("6. Exit\n");
                string option = Console.ReadLine();
                try
                {
                    connect.Open();
                    switch (int.Parse(option))
                    {
                        case 1:
                            RectMenu.Rectangle_menu(connect);
                            break;
                        case 2:
                            SquareMenu.Square_menu(connect);
                            break;
                        case 3:
                            CircleMenu.Circle_menu(connect);
                            break;
                        case 4:
                            DiamondMenu.Diamond_menu(connect);
                            break;
                        case 5:
                            TriangleMenu.Triangle_menu(connect);
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Wrong option! Choose again");
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
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
