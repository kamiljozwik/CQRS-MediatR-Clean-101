using MediatR;
using ProductManagement.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception($"Product with ID {request.Id} not found.");
            }

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
