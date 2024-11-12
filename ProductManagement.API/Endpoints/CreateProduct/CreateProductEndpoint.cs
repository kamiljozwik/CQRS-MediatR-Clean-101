using FastEndpoints;
using MediatR;
using ProductManagement.Application.Commands.CreateProduct;

namespace ProductManagement.API.Endpoints.CreateProduct;

public class CreateProductRequest
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class CreateProductEndpoint(IMediator mediator) : Endpoint<CreateProductRequest, Guid>
{
    private readonly IMediator _mediator = mediator;

    public override void Configure()
    {
        Post("/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
    {
        var command = new CreateProductCommand
        {
            Name = req.Name,
            Description = req.Description,
            Price = req.Price
        };

        var result = await _mediator.Send(command, ct);
        await SendAsync(result, cancellation: ct);
    }
}

