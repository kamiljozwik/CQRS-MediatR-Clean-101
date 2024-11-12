using FastEndpoints;
using MediatR;
using ProductManagement.Application.Commands.UpdateProduct;

namespace ProductManagement.API.Endpoints.UpdateProduct;

public class UpdateProductRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class UpdateProductEndpoint(IMediator mediator) : Endpoint<UpdateProductRequest, Guid>
{
    private readonly IMediator _mediator = mediator;

    public override void Configure()
    {
        Put("/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateProductRequest req, CancellationToken ct)
    {
        var command = new UpdateProductCommand
        {
            Id = req.Id,
            Name = req.Name,
            Description = req.Description,
            Price = req.Price
        };

        await _mediator.Send(command, ct);
        await SendAsync(req.Id, cancellation: ct);
    }
}

