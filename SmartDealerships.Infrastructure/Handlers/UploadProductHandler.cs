using LanguageExt.Common;
using MediatR;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.Infrastructure.Handlers
{
    public class UploadProductHandler : IRequestHandler<UploadProductCommand, Result<string>>
    {
        private readonly IDealershipDbContext _dbContext;

        public UploadProductHandler(IDealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Result<string>> Handle(UploadProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Result<string>("Ok"));
        }
    }
}
