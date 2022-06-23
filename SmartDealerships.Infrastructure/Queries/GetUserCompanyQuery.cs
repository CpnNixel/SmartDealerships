using LanguageExt.Common;
using MediatR;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Queries
{
    public class GetUserCompanyQuery : IRequest<Result<CompanyDto>>
    {
        public string Token { get; set; }

        public GetUserCompanyQuery(string token)
        {
            Token = token;
        }

        public GetUserCompanyQuery()
        {
        }
    }
}
