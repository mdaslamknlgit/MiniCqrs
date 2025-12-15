using Microsoft.EntityFrameworkCore;
using MiniCqrs.Models;

namespace MiniCqrs.Infrastructure.Persistence;

public class MiniCqrsDbContext : DbContext
{
    public MiniCqrsDbContext(DbContextOptions<MiniCqrsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Lead> Leads => Set<Lead>();
}
