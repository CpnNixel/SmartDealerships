using MediatR;
using SmartDealerships.DataAccess.Extensions;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.Commands;
using SmartDealerships.Infrastructure.DTO;

namespace SmartDealerships.Infrastructure.Handlers;

public class RegisterHandler : IRequestHandler<RegisterCommand, LoginResponseDTO>
{
    private readonly IDealershipDbContext _dbContext;

    public RegisterHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LoginResponseDTO> Handle(RegisterCommand req, CancellationToken ct)
    {
        var user = new User
        {
            Email = req.Email,
            FirstName = req.FirstName,
            LastName = req.LastName,
            RoleId = 1,
            Role = new Role {RoleName = "User"},
            PasswordHash = LoginHandler.Base64Encode(req.Password),
            Address = req.Address,
            Telephone = req.Telephone,
            CreatedAt = DateTime.Now.SetKindUtc(),
            ModifiedAt = DateTime.Now.SetKindUtc(),
        };
        _dbContext.Users.Add(user);

        await _dbContext.SaveChangesAsync(ct);
        
        var token = LoginHandler.GenerateToken();

        await CreateSession(user, token);

        return new LoginResponseDTO {IsSuccessful = true, Token = LoginHandler.GenerateToken()};
    }
    
    private async Task CreateSession(User user, string token)
    {
        _dbContext.ShoppingSessions.Add(
        
            new ShoppingSession
            {
                UserId = user.Id,
                User = user,
                Token = token,
                Total = 0,
                CreatedAt = DateTime.Now.SetKindUtc(),
                ModifiedAt = DateTime.Now.SetKindUtc(),

            }
        );

        await _dbContext.SaveChangesAsync();
    }
}