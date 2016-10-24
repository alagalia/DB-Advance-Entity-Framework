namespace _2.GetVillainsNames
{
    using System;
    using System.Data.SqlClient;

    class GetVillainsNames
    {
        static void Main()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=MinionsDB; Trusted_Connection=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT v.Name, COUNT(m.Id) AS minionsCount FROM [dbo].[Villains] as v \n" +
                           "JOIN[dbo].[MinionsVillains] as mv \n" +
                           "ON v.Id = mv.VillainId \n" +
                           "join[dbo].[Minions] as m \n" +
                           "ON mv.MinionId = m.Id \n" +
                           "GROUP BY v.Name \n" +
                           "HAVING COUNT(m.Id) > 1 \n" +
                           "ORDER BY minionsCount DESC";
            SqlCommand command = new SqlCommand(query,connection);
            using (connection)
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Name"] +" " +reader["minionsCount"]);
                    }
                }
            }
        }
    }
}
