using System;
using System.Data.SqlClient;

namespace FirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=SoftUni; Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            using(connection)
            {
                connection.Open();
                string selectionString = "SELECT COUNT(*) FROM Towns";
                SqlCommand command = new SqlCommand(selectionString, connection);
                Console.WriteLine((int)command.ExecuteScalar()/2);
                connection.Close();

            }





            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            //using (connection)
            //{
            //    Selecting("Guy", connection);
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("First query passed");
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Selecting("' OR 1=1 --", connection);
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("Second query passed");
            //    Console.ForegroundColor = ConsoleColor.White;
            //}
        }

        static void Selecting(string name, SqlConnection connection)
        {
            string selectionCommandString = $"SELECT * FROM Employees WHERE FirstName = '{name}'";
            SqlCommand command = new SqlCommand(selectionCommandString, connection);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
