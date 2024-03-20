using ISB.Renting.Business.Implementation;
using ISB.Renting.Business.Interface;
using ISB.Renting.Data;
using ISB.Renting.Data.Implementation;
using ISB.Renting.Data.Interface;
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

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        //services.AddTransient<IContactRepository, ContactRepository>();
        //services.AddTransient<IPropertyRepository, PropertyRepository>();
        //services.AddTransient<IPr, PropertyRepository>();
        services.AddTransient<IContactManager, ContactManager>();
        services.AddTransient<IPropertyManager, PropertyManager>();
        services.AddTransient<IDashboardManager, DashboardManager>();
    }
}
