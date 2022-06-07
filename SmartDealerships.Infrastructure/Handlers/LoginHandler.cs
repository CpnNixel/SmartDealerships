using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartDealerships.DataAccess.Extensions;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.DTO;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.Infrastructure.Handlers;

public class LoginHandler : IRequestHandler<LoginUserQuery, LoginResponseDTO>
{
    private readonly IDealershipDbContext _dbContext;

    public LoginHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LoginResponseDTO> Handle(LoginUserQuery request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            return new LoginResponseDTO();
        }

        var kek = Base64Encode(request.Password);
        var user = await _dbContext.Users.FirstOrDefaultAsync(
            u => u.Email == request.Email 
                 && u.PasswordHash == kek, ct);

        if (user is null)
        {
            return new LoginResponseDTO();
        }

        var token = GenerateToken();

        await CreateSession(user, token);

        return new LoginResponseDTO {IsSuccessful = true, Token = GenerateToken()};
        
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
    
    private static string GenerateToken()
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
    
    private static string Base64Decode(string base64EncodedData) {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
    
    private static string Base64Encode(string plainText) {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
}