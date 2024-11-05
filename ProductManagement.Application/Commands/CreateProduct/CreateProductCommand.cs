using MediatR;

namespace ProductManagement.Application.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Guid>  // Returns the ID of the created product
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
