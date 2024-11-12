using FastEndpoints;
using MediatR;
using ProductManagement.Application.Queries.GetProductById;
using ProductManagement.Domain.Entities;

namespace ProductManagement.API.Endpoints.GetProductById;

public class GetProductByIdRequest
{
    public required Guid Id { get; set; }
}

public class GetProductByIdEndpoint(IMediator mediator) : Endpoint<GetProductByIdRequest, Product>
{
    private readonly IMediator _mediator = mediator;

    public override void Configure()
    {
        Get("/products/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetProductByIdRequest req, CancellationToken ct)
    {
        var query = new GetProductByIdQuery(req.Id);
        var product = await _mediator.Send(query, ct);
        await SendAsync(product, cancellation: ct);
    }
}
