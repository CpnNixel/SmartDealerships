using FastEndpoints;

namespace SmartDealerships.WebApi.Features.Login;

public class LoginEndpoint // : Endpoint<LoginRequest, LoginResponse>
{
    // public override void Configure()
    // {
    //     Verbs(Http.POST);
    //     Routes("endpointlogin");
    //     AllowAnonymous();
    // }
    //
    // public override async Task<LoginResponse> HandleAsync(LoginRequest req, CancellationToken ct)
    // {
    //     if (req == null)
    //     {
    //         await SendNotFoundAsync(ct);
    //     }
    //
    //     if (req?.Email == "johndoe@gmail.com" && req.Password == "johndoe2410")
    //     {
    //         var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
    //         var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
    //
    //         var tokenOptions = new JwtSecurityToken(
    //             issuer: "CodeMaze",
    //             audience: "https://localhost:5001",
    //             claims: new List<Claim>{new Claim(ClaimTypes.Role, "admin")},
    //             expires: DateTime.Now.AddMinutes(5),
    //             signingCredentials: signinCredentials
    //         );
    //
    //         var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    //         await SendOkAsync(new { Token = tokenString }, ct);
    //     }
    //     else
    //     {
    //         await SendUnauthorizedAsync(ct);
    //     }
    // }
}