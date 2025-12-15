using MiniCqrs.Data;
using MiniCqrs.Models;

namespace MiniCqrs.Commands;

public class CreateLeadHandler
{
    public int Handle(CreateLeadCommand command)
    {
        var lead = new Lead
        {
            Id = FakeDatabase.Leads.Count + 1,
            Name = command.Name
        };

        FakeDatabase.Leads.Add(lead);

        return lead.Id;
    }
}
