using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.Infrastructure.Reponses;

namespace SmartDealerships.Infrastructure.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly IDealershipDbContext _dbContext;

    public GetAllUsersHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<UserDto>> Handle(GetAllUsersQuery req, CancellationToken ct)
    {
        var users = _dbContext.Users.Include(x => x.Role);
        if (!users.Any())
        {
            throw new Exception("no users were found");
        }
        
        return Task.FromResult(users.Select(u => new UserDto
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Address = u.Address,
            Telephone = u.Telephone,
            CreatedAt = u.CreatedAt,
            ModifiedAt = u.ModifiedAt,
            RoleName = u.Role.RoleName
        }).ToList());
    }
}