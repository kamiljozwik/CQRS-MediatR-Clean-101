using MediatR;

namespace ProductManagement.Application.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<Unit>
{
    public Guid Id { get; set; }  // Product ID to update
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

