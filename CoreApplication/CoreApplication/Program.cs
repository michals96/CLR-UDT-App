using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleExtender;
using System.Drawing;

namespace CoreApplication
{
    class Program
    {
        // Main application - handles all events
        static void Main(string[] args)
        {
            // Przydatne, jesli chcemy wyprintowac dostepne czcionki
            /*var fonts = ConsoleHelper.ConsoleFonts;
            for (int f = 0; f < fonts.Length; f++)
                Console.WriteLine("{0}: X={1}, Y={2}",
                   fonts[f].Index, fonts[f].SizeX, fonts[f].SizeY);*/

            // Jesli program sie nie buduje to prosze zakomentowac
            // dwie linijki ponizej
            ConsoleHelper.SetConsoleFont(9);
            ConsoleHelper.SetConsoleIcon(SystemIcons.Information);

            string sql = @"DATA SOURCE=MSSQLServer;" + 
                "INITIAL CATALOG=projectdb; INTEGRATED SECURITY=SSPI;";
            SqlConnection connect = new SqlConnection(sql);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("...::: Techniki Internetowe 2 :::...");
            Console.WriteLine("   :::    Michal Stefaniuk    :::");
            Console.WriteLine("   :::      Projekt nr 6      :::");
            Console.WriteLine("...:::    Aplikacja CLR UDT   :::...");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
            Console.Clear();
            while(true)
            {
                Console.WriteLine(" -- MENU -- ");
                Console.Write("1. Rectangle\n");
                Console.Write("2. Square\n");
                Console.Write("3. Circle\n");
                Console.Write("4. Diamond\n");
                Console.Write("5. Triangle\n");
                Console.Write("6. Trapezium\n");
                Console.Write("7. Exit\n");
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
                            TrapeziumMenu.Trapezium_menu(connect);
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
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
