using LanguageExt.Common;
using MediatR;

namespace SmartDealerships.Infrastructure.Commands;

public class CreateCompanyCommand : IRequest<Result<string>>
{
    public string Token { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Logo { get; set; }

    public CreateCompanyCommand(string token, string name, string desrc, string logo)
    {
        Token = token;
        Name = name;
        Description = desrc;
        Logo = logo;
    }

    public CreateCompanyCommand()
    {
    }
}
