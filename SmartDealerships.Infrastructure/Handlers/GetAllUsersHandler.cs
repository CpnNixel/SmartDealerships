using MediatR;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.Infrastructure.DTO;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.Infrastructure.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetUsersByNothing, List<UserDTO>>
{
    private readonly IDealershipDbContext _dbContext;

    public GetAllUsersHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<UserDTO>> Handle(GetUsersByNothing req, CancellationToken ct)
    {
        var users = _dbContext.Users.ToList();
        
        return Task.FromResult(users.Select(u => new UserDTO
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Address = u.Address,
            Telephone = u.Telephone,
            CreatedAt = u.CreatedAt,
            ModifiedAt = u.ModifiedAt
        }).ToList());
    }
}