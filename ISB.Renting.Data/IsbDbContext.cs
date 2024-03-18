using ISB.Renting.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ISB.Renting.Data;


public class IsbDbContext : DbContext
{
    public DbSet<Property> Properties { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Ownership> Ownerships { get; set; }
    public DbSet<PriceHistory> PriceHistories { get; set; }

    public IsbDbContext(DbContextOptions<IsbDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ownership>()
            .ToTable("Ownership")
            .Property(o => o.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<PriceHistory>()
            .ToTable("PriceHistory")
            .Property(o => o.NewPrice)
            .HasColumnType("decimal(18,2)"); 

        modelBuilder.Entity<Property>()
            .ToTable("Property")
            .Property(o => o.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Contact>()
            .ToTable("Contact");

    }
}