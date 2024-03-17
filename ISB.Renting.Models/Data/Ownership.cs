namespace ISB.Renting.Models.Data;

public class Ownership
{
    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public Guid ContactId { get; set; }
    public decimal Price { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTill { get; set; }

    public virtual Property Property { get; set; } = new();
    public virtual Contact Contact { get; set; } = new();
}
