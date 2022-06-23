using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.WebApi.Features.Companies;

public class CreateCompanyRequest
{
    public CreateCompanyRequest()
    {
    }

    public string Name { get; set; }

    public CreateCompanyRequest(string name, string desrc, string logo)
    {
        Name = name;
        Description = desrc;
        Logo = logo;
    }

    public string Description { get; set; }

    public string Logo { get; set; }
}

public class CreateCompanyResponse
{
    public string Message { get; set; }

    public bool IsSuccessful { get; set; }

    public CreateCompanyResponse(string message, bool isSuccessful)
    {
        Message = message;
        IsSuccessful = isSuccessful;
    }

    public CreateCompanyResponse()
    {
    }

}

public class UserCompanyResponse
{

    public CompanyDto Company { get; set; }

    public bool IsSuccessful { get; set; } = false;

    public string Message { get; set; }

    public string DateCreated { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

    public UserCompanyResponse(CompanyDto company, bool isSuccessful, string message, string dateCreated)
    {
        Company = company;
        IsSuccessful = isSuccessful;
        Message = message;
        DateCreated = dateCreated;
    }

    public UserCompanyResponse(bool isSuccessful, string message)
    {
        IsSuccessful = isSuccessful;
        Message = message;
    }

    public UserCompanyResponse()
    {
    }
}

