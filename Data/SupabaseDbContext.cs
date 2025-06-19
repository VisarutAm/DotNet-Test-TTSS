using DotNet_Test_TTSS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotNet_Test_TTSS.Data
{
    public class SupabaseDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public SupabaseDbContext(DbContextOptions<SupabaseDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        // Add DbSet properties for your entities
        public DbSet<Area> Areas { get; set; }
        public DbSet<Truck> Trucks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("areas1");           // Map ชื่อตาราง
                entity.HasKey(e => e.AreaId);       // Primary Key

                // Map JSONB column
                entity.Property(e => e.RequiredResources)
                      .HasColumnType("jsonb");      // PostgreSQL jsonb
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.ToTable("trucks1");           // Map ชื่อตาราง
                entity.HasKey(e => e.TruckId);       // Primary Key

                // Map JSONB column
                entity.Property(e => e.AvailableResources)
                      .HasColumnType("jsonb");      // PostgreSQL jsonb
                      
                entity.Property(e => e.TravelTimeToArea)
                .HasColumnType("jsonb");      // PostgreSQL jsonb
            });
        }


    }

}
