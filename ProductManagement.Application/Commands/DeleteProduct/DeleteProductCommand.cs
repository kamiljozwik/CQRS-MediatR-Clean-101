using MediatR;

namespace ProductManagement.Application.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
