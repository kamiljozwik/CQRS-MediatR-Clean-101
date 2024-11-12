using FastEndpoints;
using MediatR;
using ProductManagement.Application.Commands.DeleteProduct;

namespace ProductManagement.API.Endpoints.DeleteProduct;

public class DeleteProductRequest
{
    public required Guid Id { get; set; }
}

public class DeleteProductEndpoint(IMediator mediator) : Endpoint<DeleteProductRequest, Guid>
{
    private readonly IMediator _mediator = mediator;

    public override void Configure()
    {
        Delete("/products/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteProductRequest req, CancellationToken ct)
    {
        var command = new DeleteProductCommand
        {
            Id = req.Id,
        };

        await _mediator.Send(command, ct);
        await SendAsync(req.Id, cancellation: ct);
    }
}

