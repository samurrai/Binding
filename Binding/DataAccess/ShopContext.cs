namespace Binding.DataAccess
{
    using Binding.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
        }
        public DbSet<Item> Items { get; set; }
    }
}