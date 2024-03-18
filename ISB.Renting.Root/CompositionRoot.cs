using ISB.Renting.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ISB.Renting.Root;

public class CompositionRoot
{
    public CompositionRoot()
    {
    }

    public static void injectDependencies(IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<IsbDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("IsbRentingDatabase"), 
                b => b.MigrationsAssembly("ISB.Renting.Data")));


    }
}
