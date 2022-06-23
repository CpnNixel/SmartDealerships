using LanguageExt.Common;
using MediatR;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Queries
{
    public class FindProductByNameQuery : IRequest<Result<List<ProductDto>>>
    {
        public string SearchName { get; set; }

        public FindProductByNameQuery(string name)
        {
            SearchName = name;
        }

        public FindProductByNameQuery()
        {
        }
    }
}
