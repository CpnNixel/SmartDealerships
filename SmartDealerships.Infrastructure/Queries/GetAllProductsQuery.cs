using MediatR;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Queries;

public class GetAllProductsQuery : IRequest<List<ProductDto>>
{
}