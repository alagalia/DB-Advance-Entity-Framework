using ProductShop.Models;

namespace ProductsShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopContext : DbContext
    {
        
        public ShopContext()
            : base("name=ShopContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Friends)
                .WithMany()
                .Map(config =>
                {
                    config.MapLeftKey("userId");
                    config.MapRightKey("friendId");
                    config.ToTable("UserFriends");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}