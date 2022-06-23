using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Handlers
{
    public class GetUserCompanyHandler : IRequestHandler<GetUserCompanyQuery, Result<CompanyDto>>
    {
        private readonly IDealershipDbContext _dbContext;

        public GetUserCompanyHandler(IDealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<CompanyDto>> Handle(GetUserCompanyQuery request, CancellationToken ct)
        {
            //var res = _dbContext.ShoppingSessions
            //    .Include(s => s.User)
            //    .ThenInclude(u => u.Company)
            //    .ThenInclude(c => c.Products)
            //    .ThenInclude(c => c.Category)
            //    .FirstOrDefault(x => x.Token == request.Token);

            var res = _dbContext.ShoppingSessions
            .Include(s => s.User)
            .ThenInclude(u => u.Company)
            .ThenInclude(c => c.Products)
            .ThenInclude(product => product.Category)
            .ThenInclude(c => c.Products)
            .ThenInclude(product => product.Orders)
            .FirstOrDefault(x => x.Token == request.Token);

            var companyId = res.User.CompanyId;
            var orders = _dbContext.OrderDetails.Where(x => x.CompanyId == companyId);

            return res != null && res.User != null && res.User.Company != null
                ? new Result<CompanyDto>(MapKek(res.User.Company, orders))
                : new Result<CompanyDto>(new NullReferenceException("The user has no companies"));
        }

        private CompanyDto MapKek(Company cp, IEnumerable<OrderDetails> orders)
        {
            var mappedOrders = new List<OrderDto>(orders.Select(x => new OrderDto(x.Id, x.Total, x.UserId ?? 0, x.CompanyId ?? 0)));
            return new CompanyDto(cp.Id, cp.Name, cp.Description, cp.LogoImage, Map(cp.Products), mappedOrders);
        }

        private IEnumerable<ProductDto> Map(ICollection<Product> products)
        {
            foreach (var p in products)
            {
                yield return new ProductDto(
                    p.Id,
                    p.Name ?? "test name",
                    p.Description ?? "some description",
                    p.Sku,
                    p.Price,
                    p.Category?.Name ?? "test category",
                    p.Company.Name
                );
            }
        }
    }
}
