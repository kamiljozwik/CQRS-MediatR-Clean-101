using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Product> Products { get; set; }  // DbSet for Products

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Additional logic before saving changes can be added here
        return base.SaveChangesAsync(cancellationToken);
    }
}
