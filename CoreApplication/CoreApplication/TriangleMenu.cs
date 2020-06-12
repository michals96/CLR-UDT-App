using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CoreApplication
{
    class TriangleMenu
    {
        // Menu that handles Rectangle type interactions
        public static void Triangle_menu(SqlConnection connect)
        {
            Console.Clear();
            Console.WriteLine("--TRIANGLE MENU--");
            Console.WriteLine("1 - List triangles");
            Console.WriteLine("2 - Add triangle");
            Console.WriteLine("3 - Search triangle");
            string opt = Console.ReadLine();
            if (opt == "1")
            {
                Console.Clear();
                Console.WriteLine("-- TRIANGLES LIST --");
                Console.WriteLine("Length\tHeight\tField");
                string query = "SELECT shape.Length as H, shape.Height as W, shape.Field as F from Triangles";
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
                Console.WriteLine("Insert length");
                string val = Console.ReadLine();
                val += ",";
                Console.WriteLine("Insert height");
                val += Console.ReadLine();
                string query = "INSERT into Triangles (shape) values('" + val + "')";
                SqlCommand sqlQuery = new SqlCommand(query, connect);
                SqlDataReader addData = sqlQuery.ExecuteReader();
                addData.Close();
                Console.WriteLine("SUCCESFULLY ADDED!\n");
            }
            if (opt == "3")
            {
                Console.Clear();
                Console.WriteLine("1 - Search by legnth");
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
                Console.WriteLine("-- TRIANGLES LIST --");
                Console.WriteLine("Length\tHeight\tField");
                string query = "SELECT shape.Length as H, shape.Height as W, shape.Field as F from Triangles";

                if (search_option == "1")
                {
                    query += " where shape.Length ";
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
