namespace _02.Create_User
{
    using Models;
    using System.Data.Entity;

    public class UserContext : DbContext
    {
        
        public UserContext()
            : base("name=UserContext")
        {
        }


        public virtual DbSet<User> Users { get; set; }
    }
}