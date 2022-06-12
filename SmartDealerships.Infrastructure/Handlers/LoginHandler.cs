using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartDealerships.DataAccess.Extensions;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using BC = BCrypt.Net.BCrypt;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.Infrastructure.Responses;

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
        
        var user = await _dbContext.Users.FirstOrDefaultAsync(
            u => u.Email == request.Email, ct);

        if (user is null || !BC.Verify(request.Password, user.PasswordHash))
        {
            return new LoginResponseDto();
        }

        #region Change to trigger BEFORE INSERT CONSTRAINT UniqueSessionPerUser
        
        var sessions = _dbContext.ShoppingSessions
            .Where(u => u.UserId == user.Id)
            .Include(s => s.CartItems);
        
        _dbContext.CartItems.RemoveRange(sessions.SelectMany(s=>s.CartItems));
        
        _dbContext.ShoppingSessions.RemoveRange(sessions);

        await _dbContext.SaveChangesAsync(ct);

        #endregion

        var token = GenerateToken();

        await CreateSession(user, token);

        return new LoginResponseDto {IsSuccessful = true, Token = token};
        
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
    
    public static string GenerateToken()
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
    
        var tokenOptions = new JwtSecurityToken(
            issuer: "CodeMaze",
            audience: "https://localhost:5001",
            claims: new List<Claim>{new Claim(ClaimTypes.Role, "admin")},
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: signinCredentials
        );
    
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}