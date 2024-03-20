using ISB.Renting.Data.Interface;
using ISB.Renting.Models.Data;

namespace ISB.Renting.Data.Implementation;

public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
{
    public PropertyRepository(IsbDbContext context) : base(context)
    {
    }
}