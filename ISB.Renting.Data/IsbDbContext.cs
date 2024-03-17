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
}