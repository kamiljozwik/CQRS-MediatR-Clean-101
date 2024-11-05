using MediatR;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Application.Queries.GetProductById;

public class GetProductByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new Exception($"Product with ID {request.Id} not found.");
        }

        return entity;
    }
}

