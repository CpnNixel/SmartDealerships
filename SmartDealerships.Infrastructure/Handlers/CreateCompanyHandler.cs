using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.Infrastructure.Handlers;

public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, Result<string>>
{
    private readonly IDealershipDbContext _dbContext;

    public CreateCompanyHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<string>> Handle(CreateCompanyCommand request, CancellationToken ct)
    {
        var session = await _dbContext.ShoppingSessions
           .Include(s => s.User)
           .FirstOrDefaultAsync(x => x.Token == request.Token);

        if (session == null && session.User == null)
        {
            return new Result<string>(new NullReferenceException("Cannot find user"));
        }
        else
        {
            _dbContext.Companies.Add(new Company
            {
                Name = request.Name,
                Description = request.Description,
                LogoImage = new byte[4],//request.Logo
                Owners = new List<User>() { session.User }
            });

            await _dbContext.SaveChangesAsync(ct);
            return new Result<string>("success");
        }

    }
}

//public int Id { get; set; }

//public string Name { get; set; }

//public string Description { get; set; }

//public byte[]? LogoImage { get; set; }

//public virtual ICollection<User> Owners { get; set; }

