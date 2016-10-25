
namespace _5.ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection =
                new SqlConnection("Server=(localdb)\\MSSQLLocalDB; Database=MinionsDB; Trusted_Connection=True");

            string townName = Console.ReadLine();

            string queryUpperTown = "UPDATE Towns SET Name = uper(Name) where Country = @townName";
            SqlCommand cmd = new SqlCommand(queryUpperTown, connection);
            cmd.Parameters.AddWithValue("@townName", townName);
            
            using (connection)
            {
                connection.Open();
                int afectedRow = cmd.ExecuteNonQuery();
                if (afectedRow<=0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                Console.WriteLine($"{afectedRow} town names were affected.");
                cmd = new SqlCommand("SELECT * FROM Towns WHERE Country = @townName", connection);
                cmd.Parameters.AddWithValue("@townName", townName);
                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    List<string> affectedRowNames = new List<string>();

                    while (reader.Read())
                    {
                        affectedRowNames.Add(reader["Name"].ToString());
                    }
                    Console.WriteLine("[" + string.Join(", ", affectedRowNames) + "]");
                }
            }
        }
    }
}
