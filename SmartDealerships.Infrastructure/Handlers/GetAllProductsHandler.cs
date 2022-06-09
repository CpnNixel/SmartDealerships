using MediatR;
using SmartDealerships.Infrastructure.DTO;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.Infrastructure.Handlers;

public class GetCategoriesAndProductsHandler : IRequestHandler<GetCategoriesAndProducts, CategoriesAndProductsDTO>
{
    public Task<CategoriesAndProductsDTO> Handle(GetCategoriesAndProducts request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}