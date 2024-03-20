using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ISB.Renting.Models.Data;

public class PriceHistory : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public decimal NewPrice { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid PropertyId { get; set; }

    [ForeignKey("PropertyId")]
    public virtual Property Property { get; } = new();

}
