using MediatR;

namespace ProductManagement.Application.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public Guid Id { get; set; }
}
