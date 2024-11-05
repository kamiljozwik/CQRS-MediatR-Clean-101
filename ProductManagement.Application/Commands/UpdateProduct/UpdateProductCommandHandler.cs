using MediatR;
using ProductManagement.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Application.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            // Handle not found, could throw an exception or return a result indicating failure
            throw new Exception($"Product with ID {request.Id} not found.");
        }

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Price = request.Price;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

