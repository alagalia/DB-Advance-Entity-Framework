using System;
using System.Data.SqlClient;

namespace _4.AddMinion
{
    class AddMinion
    {
        private static void Main(string[] args)
        {
            SqlConnection connection =
                new SqlConnection("Server=(localdb)\\MSSQLLocalDB; Database=MinionsDB; Trusted_Connection=True");

            //get input
            string[] minionTokens = Console.ReadLine().Split();
            string[] villianTokens = Console.ReadLine().Split();
            string minionName = minionTokens[1];
            int minionAge = int.Parse(minionTokens[2]);
            string minionTown = minionTokens[3];
            string villianName = villianTokens[1];

            SqlCommand cmd = new SqlCommand("SELECT Id FROM Towns WHERE Name = @townName", connection);
            cmd.Parameters.AddWithValue("@townName", minionTown);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            //check for town
            if (!reader.HasRows)
            {
                //add town to db
                reader.Close();
                string townInsert = "INSERT INTO [dbo].[Towns] (Name) VALUES (@townName)";
                SqlCommand addTown = new SqlCommand(townInsert, connection);
                addTown.Parameters.AddWithValue("@townName", minionTown);
                addTown.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }
            reader.Close();
            int townId = (int) cmd.ExecuteScalar();
            reader.Close();


            SqlCommand comandForViliain = new SqlCommand("SELECT * FROM [dbo].[Villains] WHERE Name = @villianName",
                connection);
            comandForViliain.Parameters.AddWithValue("@villianName", @villianName);
            reader = comandForViliain.ExecuteReader();
            if (!reader.HasRows) // ако няма такъв злодей
            {
                reader.Close();
                string villainInsert =
                    "INSERT INTO [dbo].[Villains] (Name, EvilnessFactor) VALUES (@villainName, 'evil')";
                SqlCommand addVillain = new SqlCommand(villainInsert, connection);
                addVillain.Parameters.AddWithValue("@villainName", villianName);
                addVillain.ExecuteNonQuery();
                Console.WriteLine($"Villain {villianName} was added to the database.");
            }
            reader.Close();

            int villainId = (int) comandForViliain.ExecuteScalar();
            reader.Close();

            //add minion
            string insertMinionSQL = "INSERT INTO minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            SqlCommand insertMinionCmd = new SqlCommand(insertMinionSQL, connection);
            insertMinionCmd.Parameters.AddWithValue("@name", minionName);
            insertMinionCmd.Parameters.AddWithValue("@age", minionAge);
            insertMinionCmd.Parameters.AddWithValue("@townId", townId);
            insertMinionCmd.ExecuteNonQuery();

            // get minion Id
            string getMinionId = "SELECT Id FROM Minions WHERE Name = @minionName";
            SqlCommand getMinionIdCmd = new SqlCommand(getMinionId, connection);
            getMinionIdCmd.Parameters.AddWithValue("@minionName", minionName);
            int minionId = (int) getMinionIdCmd.ExecuteScalar();

            //make many-to-many connection in MinionsVillains table
            string insertIntoMinionsVillains = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
            SqlCommand cmdMinionsVillains = new SqlCommand(insertIntoMinionsVillains, connection);
            cmdMinionsVillains.Parameters.AddWithValue("@minionId", minionId);
            cmdMinionsVillains.Parameters.AddWithValue("@villainId", villainId);
            cmdMinionsVillains.ExecuteNonQuery();
            Console.WriteLine("Successfully added {0} to be minion of {1}", minionName, villianName);
            connection.Close();
        }
    }
}
