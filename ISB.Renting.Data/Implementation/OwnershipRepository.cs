using ISB.Renting.Data.Implementation;
using ISB.Renting.Models.Data;

namespace ISB.Renting.Data.Interface;

public class OwnershipRepository : GenericRepository<Ownership>, IOwnershipRepository
{
    public OwnershipRepository(IsbDbContext context) : base(context)
    {
    }
}