using ISB.Renting.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB.Renting.Data.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private IsbDbContext context;
    public UnitOfWork(IsbDbContext context)
    {
        this.context = context;

        Contact = new ContactRepository(this.context);
        Property = new PropertyRepository(this.context);
        PriceHistory = new PriceHistoryRepository(this.context);
        Ownership = new OwnershipRepository(this.context);
    }

    public IContactRepository Contact { get; private set; }
    public IPropertyRepository Property { get; private set; }
    public IPriceHistoryRepository PriceHistory { get; private set; }
    public IOwnershipRepository Ownership { get; private set; }

    public void Dispose()
    {
        context.Dispose();
    }
    public int Save()
    {
        return context.SaveChanges();
    }
}
