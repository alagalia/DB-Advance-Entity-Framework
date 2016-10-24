using System;
using System.Data;
using System.Data.SqlClient;

namespace _3.GetMinionNames
{
    class GetMinionNames
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; Database=MinionsDB; Trusted_Connection=True");

            int villianId = int.Parse(Console.ReadLine());
            string queryGetVillianName = "SELECT Name FROM [dbo].[Villains] WHERE Id = @vilianId";
            string queryGetMinionsByVilianID = "SELECT m.Id, m.Name, m.Age FROM [dbo].[Minions] as m \n" +
                           "join[dbo].[MinionsVillains] as mv      \n" +
                           "ON m.Id = mv.MinionId \n" +
                           "JOIN[dbo].[Villains] as v \n" +
                           "ON mv.VillainId = v.Id \n" +
                           "WHERE v.Id = @vilianId";
            SqlCommand cmdGetVilian = new SqlCommand(queryGetVillianName, connection);
            cmdGetVilian.Parameters.AddWithValue("@vilianId", villianId);
            SqlCommand cmdGetMinions = new SqlCommand(queryGetMinionsByVilianID, connection);
            cmdGetMinions.Parameters.AddWithValue("@vilianId", villianId);

            using (connection)
            {
                connection.Open();
                using (SqlDataReader reader = cmdGetVilian.ExecuteReader(CommandBehavior.SingleRow))
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Console.WriteLine("Villain: " + reader["Name"]);
                    }
                    else
                    {
                        Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                    }
                }

                using (SqlDataReader reader = cmdGetMinions.ExecuteReader())
                {
                    int count = 1;
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("<no minions>");
                        return;
                    }
                    while (reader.Read())
                    {
                        Console.WriteLine($"{count}. {reader["Name"]} {reader["Age"]}");
                        count++;
                    }
                }
            }
        }
    }
}
