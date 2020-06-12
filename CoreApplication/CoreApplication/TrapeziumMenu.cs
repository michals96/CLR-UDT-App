using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CoreApplication
{
    class TrapeziumMenu
    {
        // Menu that handles Rectangle type interactions
        public static void Trapezium_menu(SqlConnection connect)
        {
            Console.Clear();
            Console.WriteLine("--TRAPEZIUM MENU--");
            Console.WriteLine("1 - List trapeziums");
            Console.WriteLine("2 - Add trapezium");
            Console.WriteLine("3 - Search trapezium");
            string opt = Console.ReadLine();
            if (opt == "1")
            {
                Console.Clear();
                Console.WriteLine("-- RECTANGLES LIST --");
                Console.WriteLine("B1\tB2\tHeight\tField");
                string query = "SELECT shape.Upper_base as B1, shape.Lower_base as B2, shape.Height as H, shape.Field as F from Trapeziums";
                SqlCommand execute = new SqlCommand(query, connect);
                SqlDataReader getData = execute.ExecuteReader();
                while (getData.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                        getData["B1"],
                        getData["B2"],
                        getData["H"],
                        getData["F"]);
                }
                Console.WriteLine("\n");
                getData.Close();
            }
            if (opt == "2")
            {
                Console.Clear();
                Console.WriteLine("Insert upper base");
                string val = Console.ReadLine();
                val += ",";
                Console.WriteLine("Insert lower base");
                val += Console.ReadLine();
                val += ",";
                Console.WriteLine("Insert height");
                val += Console.ReadLine();
                string query = "INSERT into Trapeziums (shape) values('" + val + "')";
                SqlCommand sqlQuery = new SqlCommand(query, connect);
                SqlDataReader addData = sqlQuery.ExecuteReader();
                addData.Close();
                Console.WriteLine("SUCCESFULLY ADDED!\n");
            }
            if (opt == "3")
            {
                Console.Clear();
                Console.WriteLine("1 - Search by upper base");
                Console.WriteLine("2 - Search by lower base");
                Console.WriteLine("3 - Search by height");
                Console.WriteLine("4 - Search by field");
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
                Console.WriteLine("-- TRAPEZIUMS LIST --");
                Console.WriteLine("B1\tB2\tHeight\tField");
                string query = "SELECT shape.Upper_base as B1, shape.Lower_base as B2, shape.Height as H, shape.Field as F from Trapeziums";

                if (search_option == "1")
                {
                    query += " where shape.Upper_base ";
                }
                if (search_option == "2")
                {
                    query += " where shape.Lower_base ";
                }
                if (search_option == "3")
                {
                    query += " where shape.Height ";
                }
                if (search_option == "4")
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
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                        getData["B1"],
                        getData["B2"],
                        getData["H"],
                        getData["F"]);
                }
                Console.WriteLine("\n");
                getData.Close();
            }
        }
    }
}
