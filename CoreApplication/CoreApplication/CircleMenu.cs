using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CoreApplication
{
    class CircleMenu
    {
        // Menu that handles Rectangle type interactions
        public static void Circle_menu(SqlConnection connect)
        {
            Console.Clear();
            Console.WriteLine("--CIERCLE MENU--");
            Console.WriteLine("1 - List circles");
            Console.WriteLine("2 - Add circle");
            Console.WriteLine("3 - Search circle");
            string opt = Console.ReadLine();
            if (opt == "1")
            {
                Console.Clear();
                Console.WriteLine("-- CIRCLE LIST --");
                Console.WriteLine("Radius\tCircuit\tField");
                string query = "SELECT shape.Radius as R, shape.Circuit as C, shape.Field as F from Circles";
                SqlCommand execute = new SqlCommand(query, connect);
                SqlDataReader getData = execute.ExecuteReader();
                while (getData.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}",
                        getData["R"],
                        getData["C"],
                        getData["F"]);
                }
                Console.WriteLine("\n");
                getData.Close();
            }
            if (opt == "2")
            {
                Console.Clear();
                Console.WriteLine("Insert radius");
                string val = Console.ReadLine();
                string query = "INSERT into Circles (shape) values('" + val + "')";
                SqlCommand sqlQuery = new SqlCommand(query, connect);
                SqlDataReader addData = sqlQuery.ExecuteReader();
                addData.Close();
                Console.WriteLine("SUCCESFULLY ADDED!\n");
            }
            if (opt == "3")
            {
                Console.Clear();
                Console.WriteLine("1 - Search by radius");
                Console.WriteLine("2 - Search by circuit");
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
                Console.WriteLine("-- CIRCLES LIST --");
                Console.WriteLine("Radius\tCircuit\tField");
                string query = "SELECT shape.Radius as R, shape.Circuit as C, shape.Field as F from Circles";

                if (search_option == "1")
                {
                    query += " where shape.Radius ";
                }
                if (search_option == "2")
                {
                    query += " where shape.Circuit ";
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
                        getData["R"],
                        getData["C"],
                        getData["F"]);
                }
                Console.WriteLine("\n");
                getData.Close();
            }
        }
    }
}
