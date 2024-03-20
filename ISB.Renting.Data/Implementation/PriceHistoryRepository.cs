using ISB.Renting.Data.Implementation;
using ISB.Renting.Models.Data;

namespace ISB.Renting.Data.Interface;

public class PriceHistoryRepository : GenericRepository<PriceHistory>, IPriceHistoryRepository
{
    public PriceHistoryRepository(IsbDbContext context) : base(context)
    {
    }
}