using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CoreApplication
{
    class RectMenu
    {
        // Menu that handles Rectangle type interactions
        public static void Rectangle_menu(SqlConnection connect)
        {
            Console.Clear();
            Console.WriteLine("--RECTANGLE MENU--");
            Console.WriteLine("1 - List rectangles");
            Console.WriteLine("2 - Add rectangle");
            Console.WriteLine("3 - Search rectangle");
            string opt = Console.ReadLine();
            if (opt == "1")
            {
                Console.Clear();
                Console.WriteLine("-- RECTANGLES LIST --");
                Console.WriteLine("Height\tWidth\tField");
                string query = "SELECT shape.Height as H, shape.Width as W, shape.Field as F from Rectangles";
                SqlCommand execute = new SqlCommand(query, connect);
                SqlDataReader getData = execute.ExecuteReader();
                while (getData.Read())
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
                Console.Clear();
                Console.WriteLine("Insert width");
                string val = Console.ReadLine();
                val += ",";
                Console.Clear();
                Console.WriteLine("Insert height");
                val += Console.ReadLine();
                string query = "INSERT into Rectangles (shape) values('" + val + "')";
                SqlCommand sqlQuery = new SqlCommand(query, connect);
                SqlDataReader addData = sqlQuery.ExecuteReader();
                addData.Close();
                Console.Clear();
                Console.WriteLine("SUCCESFULLY ADDED!\n");
            }
            if (opt == "3")
            {
                Console.Clear();
                Console.WriteLine("1 - Search by width");
                Console.WriteLine("2 - Search by height");
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
                Console.WriteLine("-- RECTANGLES LIST --");
                Console.WriteLine("Height\tWidth\tField");
                string query = "SELECT shape.Height as H, shape.Width as W, shape.Field as F from Rectangles";

                if (search_option == "1")
                {
                    query += " where shape.Width ";
                }
                if (search_option == "2")
                {
                    query += " where shape.Height ";
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
                        getData["H"],
                        getData["W"],
                        getData["F"]);
                }
                Console.WriteLine("\n");
                getData.Close();
            }
        }
    }
}
