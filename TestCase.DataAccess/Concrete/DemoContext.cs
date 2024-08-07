using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Entities.Concrete;

namespace TestCase.DataAccess.Concrete
{
    public class DemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString: "Server=TOLGA\\SQLEXPRESS;Database=TestCase2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Title).HasMaxLength(200);
            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Category);//.HasForeignKey(p => p.CategoryId);
            //    //.WithMany(c => c.Products)
                

            base.OnModelCreating(modelBuilder);
        }
    }
}
