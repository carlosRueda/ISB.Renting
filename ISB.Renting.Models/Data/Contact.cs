﻿using System.ComponentModel.DataAnnotations;

namespace ISB.Renting.Models.Data;

public class Contact
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public virtual ICollection<Ownership> Ownerships { get; } = new List<Ownership>();
}
