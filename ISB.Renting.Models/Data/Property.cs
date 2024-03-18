using System.ComponentModel.DataAnnotations;

namespace ISB.Renting.Models.Data;

public class Property
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public DateTime RegistrationDate { get; set; }

    public virtual ICollection<Ownership> Ownerships { get; } = new List<Ownership>();
    public virtual ICollection<PriceHistory> PriceHistories { get; } = new List<PriceHistory>();

}
