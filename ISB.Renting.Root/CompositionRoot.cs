using ISB.Renting.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ISB.Renting.Root;

public class CompositionRoot
{
    public CompositionRoot()
    {
    }

    public static void injectDependencies(IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<IsbDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IsbRentingDatabase")));

        
    }
}
