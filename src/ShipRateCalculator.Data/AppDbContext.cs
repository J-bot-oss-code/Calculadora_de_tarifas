using Microsoft.EntityFrameworkCore;
using ShipRateCalculator.Domain;

namespace ShipRateCalculator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<CountryRate> CountryRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CountryRate>(entity =>
            {
                entity.ToTable("CountryRates");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CountryCode)
                      .IsRequired()
                      .HasMaxLength(5)          
                      .HasColumnName("Code");   

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100)
                      .HasColumnName("Name");

                entity.Property(e => e.RatePerKg)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)")
                      .HasColumnName("RatePerKg");
            });
        }
    }
}