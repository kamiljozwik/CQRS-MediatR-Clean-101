using FastEndpoints;
using MediatR;
using ProductManagement.Application.Queries.GetAllProducts;
using ProductManagement.Domain.Entities;

namespace ProductManagement.API.Endpoints.GetAllProducts;

public class GetAllProductsEndpoint(IMediator mediator) : EndpointWithoutRequest<IEnumerable<Product>>
{
    private readonly IMediator _mediator = mediator;

    public override void Configure()
    {
        Get("/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetAllProductsQuery();
        var products = await _mediator.Send(query, ct);
        await SendAsync(products, cancellation: ct);
    }
}
