using System;
using ExampleSolution.DataLayer;
using Npgsql;

namespace ExampleSolution
{
    class PostgresExample
    {
        public void Execute()
        {
            Console.WriteLine("PostgeSQL example solution");

            using (var con =
                new NpgsqlConnection(
                    "User ID=postgres; Password=1234; Host=localhost; Port=7000; Database=myExamplePostgres;"))
            {
                con.Open();
                
                //CreateTables(con);
                InsertToTables(con);

            }


                Console.ReadKey(false);
        }

        private void InsertToTables(NpgsqlConnection connection)
        {
            var cmd = new NpgsqlCommand("INSERT INTO author(id, name) VALUES(1, \"Kawe\");", connection);
            cmd.ExecuteReader();
            cmd.Dispose();
        }

        public void CreateTables(NpgsqlConnection connection)
        {
            var cmd = new NpgsqlCommand("CREATE TABLE Author (Id int, Name varchar(255))", connection);
            cmd.ExecuteReader();
            cmd.Dispose();
        }
    }
}
