using MiniCqrs.Models;
using MiniCqrs.Infrastructure.Persistence;

namespace MiniCqrs.Commands.CreateLead;

public class CreateLeadHandler
{
    private readonly MiniCqrsDbContext _dbContext;

    public CreateLeadHandler(MiniCqrsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle(CreateLeadCommand command)
    {
        var lead = new Lead
        {
            Name = command.Name,
            Email = command.Email,
            Phone = command.Phone
        };

        _dbContext.Leads.Add(lead);
        _dbContext.SaveChanges();
    }
}
