using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartDealerships.DataAccess.Extensions;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.Infrastructure.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace SmartDealerships.Infrastructure.Handlers;

public class LoginHandler : IRequestHandler<LoginUserQuery, LoginResponseDto>
{
    private readonly IDealershipDbContext _dbContext;

    public LoginHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LoginResponseDto> Handle(LoginUserQuery request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            return new LoginResponseDto();
        }

        var user = await _dbContext.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == request.Email, ct);

        if (user is null || !BC.Verify(request.Password, user.PasswordHash))
        {
            return new LoginResponseDto();
        }

        #region Change to trigger BEFORE INSERT CONSTRAINT UniqueSessionPerUser

        var sessions = _dbContext.ShoppingSessions
            .Where(u => u.UserId == user.Id)
            .Include(s => s.CartItems);

        _dbContext.CartItems.RemoveRange(sessions.SelectMany(s => s.CartItems));

        _dbContext.ShoppingSessions.RemoveRange(sessions);

        await _dbContext.SaveChangesAsync(ct);

        #endregion

        var token = GenerateToken();

        await CreateSession(user, token);

        return new LoginResponseDto { IsSuccessful = true, Token = token, User = Map(user) };

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

    private UserDto Map(User u)
    {
        return new UserDto
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Address = u.Address,
            PhoneNumber = u.Telephone,
            CreatedAt = u.CreatedAt,
            ModifiedAt = u.ModifiedAt,
            RoleName = u.Role.RoleName
        };
    }

    public static string GenerateToken()
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: "CodeMaze",
            audience: "https://localhost:5001",
            claims: new List<Claim> { new Claim(ClaimTypes.Role, "admin") },
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: signinCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}