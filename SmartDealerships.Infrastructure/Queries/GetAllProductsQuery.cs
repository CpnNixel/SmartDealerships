using MediatR;
using SmartDealerships.Infrastructure.DTO;

namespace SmartDealerships.Infrastructure.Queries;

public class GetAllProducts : IRequest<ProductsDto>
{
}