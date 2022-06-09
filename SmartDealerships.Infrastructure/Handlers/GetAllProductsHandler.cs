using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.Infrastructure.Reponses;

namespace SmartDealerships.Infrastructure.Handlers;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly IDealershipDbContext _dbContext;

    public GetAllProductsHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = _dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Company);

        return Task.FromResult(products.Select(p => new ProductDto
        (
            p.Id,
            p.Name,
            p.Description,
            p.Sku,
            p.Price,
            p.Category.Name,
            p.Company.Name
        )).ToList());

    }
}