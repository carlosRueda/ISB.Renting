using ISB.Renting.Data.Interface;
using ISB.Renting.Models.Data;

namespace ISB.Renting.Data.Implementation;

public class ContactRepository : GenericRepository<Contact>, IContactRepository
{
    public ContactRepository(IsbDbContext context) : base(context)
    {
    }
}