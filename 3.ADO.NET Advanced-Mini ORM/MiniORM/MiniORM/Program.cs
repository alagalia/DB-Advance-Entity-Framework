using System.Collections.Generic;
using System.Linq;

namespace MiniORM
{
    using System;
    using System.Data.SqlClient;

    using CustomORM.Core;

    using MiniORM.Entities;

    class Program
    {
        private static void Main()
        {
            string connectionString = new ConnectionStringBuilder("MyWebSiteDataBase").ConnectionString;
            IDbContext context = new EntityManager(connectionString, true);
            User michka = new User("Michka", "mica", 18, DateTime.Now);
            //context.Persist(user);

            //user.Username = "GerginaUpdated";
            //context.Persist(user);  
            context.Persist(michka);
            context.Delete<User>(michka);
        }
    }
}
