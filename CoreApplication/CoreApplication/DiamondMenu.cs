using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CoreApplication
{
    class DiamondMenu
    {
        // Menu that handles Rectangle type interactions
        public static void Diamond_menu(SqlConnection connect)
        {
            Console.Clear();
            Console.WriteLine("--DIAMOND MENU--");
            Console.WriteLine("1 - List diamonds");
            Console.WriteLine("2 - Add diamond");
            Console.WriteLine("3 - Search diamond");
            string opt = Console.ReadLine();
            if (opt == "1")
            {
                Console.Clear();
                Console.WriteLine("-- DIAMONDS LIST --");
                Console.WriteLine("D1\tD2\tField");
                string query = "SELECT shape.First_diagonal as D1, shape.Second_diagonal as D2, shape.Field as F from Diamonds";
                SqlCommand execute = new SqlCommand(query, connect);
                SqlDataReader getData = execute.ExecuteReader();
                while (getData.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}",
                        getData["D1"],
                        getData["D2"],
                        getData["F"]);
                }
                Console.WriteLine("\n");
                getData.Close();
            }
            if (opt == "2")
            {
                Console.Clear();
                Console.WriteLine("Insert 1st diagonal");
                string val = Console.ReadLine();
                val += ",";
                Console.WriteLine("Insert 2nd diagonal");
                val += Console.ReadLine();
                string query = "INSERT into Diamonds (shape) values('" + val + "')";
                SqlCommand sqlQuery = new SqlCommand(query, connect);
                SqlDataReader addData = sqlQuery.ExecuteReader();
                addData.Close();
                Console.WriteLine("SUCCESFULLY ADDED!\n");
            }
            if (opt == "3")
            {
                Console.Clear();
                Console.WriteLine("1 - Search by 1st diagonal");
                Console.WriteLine("2 - Search by 2nd diagonal");
                Console.WriteLine("3 - Search by field");
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
                Console.WriteLine("-- DIAMONDS LIST --");
                Console.WriteLine("D1\tD2\tField");
                string query = "SELECT shape.First_diagonal as D1, shape.Second_diagonal as D2, shape.Field as F from Diamonds";

                if (search_option == "1")
                {
                    query += " where shape.First_diagonal ";
                }
                if (search_option == "2")
                {
                    query += " where shape.Second_diagonal ";
                }
                if (search_option == "3")
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
                    Console.WriteLine("{0}\t{1}\t{2}",
                        getData["D1"],
                        getData["D2"],
                        getData["F"]);
                }
                Console.WriteLine("\n");
                getData.Close();
            }
        }
    }
}
