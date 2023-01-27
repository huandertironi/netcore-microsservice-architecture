using Microsoft.EntityFrameworkCore;
using netcore5_core.Infrastructure.Config;
using netcore5_core.Models;

namespace netcore5_core.Infrastructure.Repository
{
    public class DatabaseContext : DbContext
    {
        readonly string _connectionString;
        
        public DatabaseContext(DatabaseConfig config) {
             
            _connectionString = config.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql(_connectionString);

        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {

                entity.HasKey(e => e.Id)
                    .HasName("Id");

                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasColumnName("Name");

            });
        }   
    }
}