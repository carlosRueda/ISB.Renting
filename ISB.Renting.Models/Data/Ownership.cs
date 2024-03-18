using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ISB.Renting.Models.Data;

public class Ownership
{
    [Key]
    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public Guid ContactId { get; set; }
    public decimal Price { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTill { get; set; }

    [ForeignKey("PropertyId")]
    public virtual Property Property { get; set; } = new();
    
    [ForeignKey("ContactId")]
    public virtual Contact Contact { get; set; } = new();
}
