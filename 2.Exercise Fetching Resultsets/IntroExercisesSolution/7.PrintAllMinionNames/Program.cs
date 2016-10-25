using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _7.PrintAllMinionNames
{
    class Program
    {
        static void Main()
        {
            SqlConnection connection =
                new SqlConnection("Server=(localdb)\\MSSQLLocalDB; Database=MinionsDB; Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Minions", connection);

            List<string> names = new List<string>();

            using (connection)
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    names.Add(reader[0].ToString());
                }
            }

            int loops = names.Count;
            List<string> orderedNames = new List<string>();

            for (int i = 0; i < loops / 2; i++)
            {
                orderedNames.Add(names[i]);
                orderedNames.Add(names[loops - i - 1]);
            }
            if (loops % 2 != 0)
            { orderedNames.Add(names[loops / 2]); }
            Console.WriteLine(string.Join("\n", orderedNames));
        }
    }
}
