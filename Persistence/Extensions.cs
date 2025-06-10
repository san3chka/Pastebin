using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class Extensions
{
    public static void AddDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<PastebinContext>(o =>
        {
            o.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}