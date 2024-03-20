namespace ISB.Renting.Models.DTO;

public class PropertyDTO : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public DateTime RegistrationDate { get; set; }

}
