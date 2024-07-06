using Microsoft.EntityFrameworkCore;
using StoreBackendQL.Models;
using System;

namespace StoreBackendQL.Essentials
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
    }
}
