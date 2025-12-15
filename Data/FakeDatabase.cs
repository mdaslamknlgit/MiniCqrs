using MiniCqrs.Models;

namespace MiniCqrs.Data;

public static class FakeDatabase
{
    public static List<Lead> Leads { get; } = new();
}
