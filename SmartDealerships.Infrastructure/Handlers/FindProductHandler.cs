using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Handlers;

public class FindProductHandler : IRequestHandler<FindProductByNameQuery, Result<List<ProductDto>>>
{
    private readonly IDealershipDbContext _dbContext;

    public FindProductHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<List<ProductDto>>> Handle(FindProductByNameQuery request, CancellationToken cancellationToken)
    {
        List<ProductDto> result = new();

        try
        {
            var products = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Company)
                .Where(x => x.Name == request.SearchName || x.Name.Contains(request.SearchName));


            result = products.Select(p => new ProductDto
            (
                p.Id,
                p.Name,
                p.Description,
                p.Sku,
                p.Price,
                p.Category.Name,
                p.Company.Name
            )).ToList();


        }
        catch (Exception ex)
        {
            return new Result<List<ProductDto>>(ex);
        }

        return new Result<List<ProductDto>>(result);
    }
}
