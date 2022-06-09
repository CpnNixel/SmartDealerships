using MediatR;
using SmartDealerships.Infrastructure.Reponses;

namespace SmartDealerships.Infrastructure.Queries;

public class GetAllProductsQuery : IRequest<List<ProductDto>>
{
}