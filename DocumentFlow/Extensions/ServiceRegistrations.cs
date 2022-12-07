using DocumentFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentFlow.Extensions;

public  static class ServiceRegistrations
{
    public static void ConfigureDataContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<DataContext>(builder => builder.UseNpgsql(configuration.GetConnectionString("DB_CONNECTIONS")).UseLazyLoadingProxies());

}