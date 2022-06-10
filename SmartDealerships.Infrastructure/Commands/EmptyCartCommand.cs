using MediatR;

namespace SmartDealerships.Infrastructure.Commands;

public class EmptyCartCommand : IRequest<string>
{
    public EmptyCartCommand(string userToken)
    {
        UserToken = userToken;
    }

    public string UserToken { get; set; }
}