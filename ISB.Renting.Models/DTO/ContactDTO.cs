using System.ComponentModel.DataAnnotations;

namespace ISB.Renting.Models.DTO;

public class ContactDTO: IEntity
{
    public Guid Id { get; set; }
    [Length(0, 50)]
    public string FirstName { get; set; }
    [Length(0, 50)]
    public string LastName { get; set; }
    [RegularExpression(@"^\+\d{5,10}$", ErrorMessage = "Phone number has to have between 5 and 10 numbers and starts with +")]
    [Length(0, 10)]
    public string PhoneNumber { get; set; }
    [EmailAddress]
    [Length(0, 50)]
    public string Email { get; set; }
}
