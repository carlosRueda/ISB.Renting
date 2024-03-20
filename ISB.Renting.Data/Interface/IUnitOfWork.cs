using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB.Renting.Data.Interface;

public interface IUnitOfWork : IDisposable
{
    IContactRepository Contact { get; }
    IPropertyRepository Property { get; }
    IPriceHistoryRepository PriceHistory { get; }
    IOwnershipRepository Ownership { get; }

    int Save();
}
