﻿using System.ComponentModel.DataAnnotations;

namespace ISB.Renting.Models.Data;

public class Contact : IEntity
{
    [Key]
    public Guid Id { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(10)]
    public string PhoneNumber { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }

    public virtual ICollection<Ownership> Ownerships { get; } = new List<Ownership>();
}
