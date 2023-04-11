namespace ElectricCarChargers.Data
{
    using ElectricCarChargers.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ElectricCarChargersDbContext : IdentityDbContext
    {
        public ElectricCarChargersDbContext(DbContextOptions<ElectricCarChargersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Charger> Chargers { get; init; }

        public DbSet<Accesories> Accesories { get; init; }

        public DbSet<Category> Categories { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Charger>()
                .HasOne(c => c.Category)
                .WithMany(C => C.Chargers)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Accesories>()
                .HasOne(c => c.Charger)
                .WithMany(C => C.Accesories)
                .HasForeignKey(c => c.ChargerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}