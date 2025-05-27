using EmployerPortal.API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/api/users", async (string username, ApplicationDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(username))
    {
        return Results.BadRequest(new { message = "Username is required." });
    }

    try
    {
        var user = await db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
            return Results.NotFound(new { message = "User not found." });
        }

        return Results.Ok(new { message = $"Hello, {user.Name}" });
    }
    catch
    {
        return Results.Problem("An unexpected error occurred.");
    }
});

app.Run();