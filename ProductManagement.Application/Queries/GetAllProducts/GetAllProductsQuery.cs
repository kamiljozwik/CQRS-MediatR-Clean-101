using MediatR;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
}

