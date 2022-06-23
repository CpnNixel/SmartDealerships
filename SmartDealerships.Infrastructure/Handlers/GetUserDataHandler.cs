using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Handlers
{
    public class GetUserDataHandler : IRequestHandler<GetUserDataQuery, UserDto>
    {
        private readonly IDealershipDbContext _dbContext;

        public GetUserDataHandler(IDealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
        {
            var shoppingSession = await _dbContext.ShoppingSessions
                .Include(x => x.User)
                .Include(x => x.User.Role)
                .FirstOrDefaultAsync(s => s.Token == request.Token);

            if (shoppingSession is null)
            {
                throw new Exception("no users were found");
            }

            return Map(shoppingSession);

        }

        private UserDto Map(ShoppingSession s)
        {
            return new UserDto
            {
                Id = s.UserId,
                FirstName = s.User.FirstName,
                LastName = s.User.LastName,
                Address = s.User.Address,
                PhoneNumber = s.User.Telephone,
                CreatedAt = s.User.CreatedAt,
                ModifiedAt = s.User.ModifiedAt,
                RoleName = s.User.Role.RoleName
            };
        }
    }
}
