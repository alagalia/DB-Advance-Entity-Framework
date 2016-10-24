using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Initial_Setup
{
    class Initial_Setup
    {
        static void Main(string[] args)
        {
            //string connectionString = _01.Initial_Setup.Properties.Settings.Default.ConnectionToMinions;
            //string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=MinionsDB; Trusted_Connection=True"

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                ["Data Source"] = "(localdb)\\MSSQLLocalDB",
                ["integrated Security"] = true
            };
            SqlConnection connection = new SqlConnection(builder.ToString());
            try
            {
                using (connection)
                {
                    connection.Open();
                    string queryCreateDB = "CREATE DATABASE MinionsDB";
                    SqlCommand command = new SqlCommand(queryCreateDB, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("DB Already exist!");
            }
            finally
            {
                connection.Close();
            }

            builder["Database"] = "MinionsDB";
            connection = new SqlConnection(builder.ToString());
            
            using (connection)
            {
                connection.Open();
                string createTownsSQL = "CREATE TABLE Towns (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), Country VARCHAR(50))";
                string createMinionsSQL = "CREATE TABLE Minions (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), Age INT, TownId INT, CONSTRAINT FK_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id))";
                string createVillainsSQL = "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactor VARCHAR(20))";
                string createMinionsVillainsSQL = "CREATE TABLE MinionsVillains(MinionId INT, VillainId INT, CONSTRAINT FK_Minions FOREIGN KEY (MinionId) REFERENCES Minions(Id), CONSTRAINT  FK_Villains FOREIGN KEY (VillainId) REFERENCES Villains(Id))";
                ExecuteCommand(createTownsSQL, connection);
                ExecuteCommand(createMinionsSQL, connection);
                ExecuteCommand(createVillainsSQL, connection);
                ExecuteCommand(createMinionsVillainsSQL, connection);


                string insertTownsSQL = "INSERT INTO Towns (Name, Country) VALUES ('Sofia','Bulgaria'), ('Burgas','Bulgaria'), ('Varna', 'Bulgaria'), ('London','UK'),('Liverpool','UK'),('Ocean City','USA'),('Paris','France')";
                string insertMinionsSQL = "INSERT INTO Minions (Name, Age, TownId) VALUES ('bob',10,1),('kevin',12,2),('steward',9,3), ('rob',22,3), ('michael',5,2),('pep',3,2)";
                string insertVillainsSQL = "INSERT INTO Villains (Name, EvilnessFactor) VALUES ('Gru','super evil'),('Victor','evil'),('Simon Cat','good'),('Pusheen','super good'),('Mammal','evil')";
                string insertMinionsVillainsSQL = "INSERT INTO MinionsVillains VALUES (1,2), (3,1),(1,3),(3,3),(4,1),(2,2),(1,1),(3,4), (1, 4), (1,5), (5, 1), (4,1), (3, 1)";

                ExecuteCommand(insertTownsSQL, connection);
                ExecuteCommand(insertMinionsSQL, connection);
                ExecuteCommand(insertVillainsSQL, connection);
                ExecuteCommand(insertMinionsVillainsSQL, connection);
            }

        }

        public static void ExecuteCommand(string commandText, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand(commandText, connection);
            cmd.ExecuteNonQuery();
        }
    }
}
