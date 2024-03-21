using System.ComponentModel.DataAnnotations;

namespace ISB.Renting.Models.DTO;

public class PropertyDTO : IEntity
{
    public Guid Id { get; set; }
    [Length(0, 50)]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public DateTime RegistrationDate { get; set; }

}
