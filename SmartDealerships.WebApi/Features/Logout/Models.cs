namespace SmartDealerships.WebApi.Features.Logout;

public class LogoutRequest
{
    public int UserId { get; set; }
}

public class LogoutResponse
{
    public string Message { get; set; }
}