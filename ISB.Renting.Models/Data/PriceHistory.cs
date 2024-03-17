namespace ISB.Renting.Models.Data;

public class PriceHistory
{
    public Guid Id { get; set; }
    public decimal NewPrice { get; set; }
    public DateTime CreationDate { get; set; }

    public virtual Property Property { get; } = new();

}
