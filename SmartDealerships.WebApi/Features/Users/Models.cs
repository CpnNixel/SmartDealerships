using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.WebApi.Features.Users;

public class UserDataRequest
{
    public string token { get; set; }
}

public class UsersResponse
{
    public string Token { get; set; }
    public List<UserDto> Users { get; set; }
}
