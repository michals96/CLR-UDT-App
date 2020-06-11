using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CoreApplication
{
    class SquareMenu
    {
        // Menu that handles Square type interactions
        public static void Square_menu(SqlConnection connect)
        {
            Console.Clear();
            Console.WriteLine("--RECTANGLE MENU--");
            Console.WriteLine("1 - List squares");
            Console.WriteLine("2 - Add square");
            Console.WriteLine("3 - Search square");
            string opt = Console.ReadLine();
            if (opt == "1")
            {
                Console.Clear();
                Console.WriteLine("-- SQUARES LIST --");
                Console.WriteLine("Size\tField");
                string query = "SELECT shape.Size as S, shape.Field as F from Squares";
                SqlCommand execute = new SqlCommand(query, connect);
                SqlDataReader getData = execute.ExecuteReader();
                while (getData.Read())
                {
                    Console.WriteLine("{0}\t{1}",
                        getData["S"],
                        getData["F"]);
                }
                Console.WriteLine("\n");
                getData.Close();
            }
            if (opt == "2")
            {
                Console.Clear();
                Console.WriteLine("Insert size");
                string val = Console.ReadLine();
                string query = "INSERT into Squares (shape) values('" + val + "')";
                SqlCommand sqlQuery = new SqlCommand(query, connect);
                SqlDataReader addData = sqlQuery.ExecuteReader();
                addData.Close();
                Console.WriteLine("SUCCESFULLY ADDED!\n");
            }
            if (opt == "3")
            {
                Console.Clear();
                Console.WriteLine("1 - Search by size");
                Console.WriteLine("2 - Search by field");
                string search_option = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("1 - Greater values >");
                Console.WriteLine("2 - Lesser values  <");
                Console.WriteLine("3 - Equal values  ==");
                string order_option = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter Value");
                string val = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("-- RECTANGLES LIST --");
                Console.WriteLine("Size\tField");
                string query = "SELECT shape.Size as S, shape.Field as F from Squares";

                if (search_option == "1")
                {
                    query += " where shape.Size ";
                }
                if (search_option == "2")
                {
                    query += " where shape.Field ";
                }

                if (order_option == "1")
                {
                    query += "> " + val;
                }
                if (order_option == "2")
                {
                    query += "< " + val;
                }
                if (order_option == "3")
                {
                    query += "= " + val;
                }
                SqlCommand execute = new SqlCommand(query, connect);
                SqlDataReader getData = execute.ExecuteReader();
                while (getData.Read())
                {
                    Console.WriteLine("{0}\t{1}",
                        getData["S"],
                        getData["F"]);
                }
                Console.WriteLine("\n");
                getData.Close();
            }
        }
    }
}
