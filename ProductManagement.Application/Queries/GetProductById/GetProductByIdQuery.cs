using MediatR;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Queries.GetProductById;

// public class GetProductByIdQuery : IRequest<Product>
// {
//     public Guid Id { get; set; }
// }

public record GetProductByIdQuery(Guid Id) : IRequest<Product>;