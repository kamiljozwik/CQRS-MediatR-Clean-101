using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application.Interfaces;
using ProductManagement.Infrastructure.Persistence;

namespace ProductManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Using In-Memory database for simplicity
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("ProductManagementDb"));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
        // services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
