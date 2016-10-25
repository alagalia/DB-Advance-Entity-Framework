namespace _8.IncreaseMinionsAge
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    internal class IncreaseMinionsAge
    {
        private static void Main()
        {
            SqlConnection connection =
                new SqlConnection("Server=(localdb)\\MSSQLLocalDB; Database=MinionsDB; Trusted_Connection=True");

            List<int> ids = Console.ReadLine().Split().Select(int.Parse).ToList();

            using (connection)
            {
                connection.Open();
                foreach (int id in ids)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Minions SET Age += 1 WHERE ID = @id", connection);
                    SqlCommand cmdTitleCase =
                        new SqlCommand(
                            "UPDATE Minions SET Name = UPPER(LEFT(Name,1))+LOWER(SUBSTRING(Name,2,LEN(Name))) WHERE ID = @id",
                            connection);

                    cmd.Parameters.AddWithValue("@id", id);
                    cmdTitleCase.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    cmdTitleCase.ExecuteNonQuery();
                }

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM Minions", connection);
                SqlDataReader minionsReader = selectCommand.ExecuteReader();
                while (minionsReader.Read())
                {
                    for (int i = 0; i < minionsReader.FieldCount; i++)
                    {
                        Console.Write($"{minionsReader[i]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
