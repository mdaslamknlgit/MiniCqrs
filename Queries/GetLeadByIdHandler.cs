using MiniCqrs.Data;
using MiniCqrs.Models;

namespace MiniCqrs.Queries;

public class GetLeadByIdHandler
{
    public Lead? Handle(GetLeadByIdQuery query)
    {
        return FakeDatabase.Leads
            .FirstOrDefault(x => x.Id == query.Id);
    }
}
