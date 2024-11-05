using MediatR;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
