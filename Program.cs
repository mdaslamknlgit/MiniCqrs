using Microsoft.EntityFrameworkCore;
using MiniCqrs.Infrastructure.Persistence;
using MiniCqrs.Commands.CreateLead;
using MiniCqrs.Queries;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core + SQLite
builder.Services.AddDbContext<MiniCqrsDbContext>(options =>
{
    options.UseSqlite("Data Source=App_Data/minicqrs.db");
});

// CQRS handlers (DI)
builder.Services.AddScoped<CreateLeadHandler>();
builder.Services.AddScoped<GetLeadByIdHandler>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
