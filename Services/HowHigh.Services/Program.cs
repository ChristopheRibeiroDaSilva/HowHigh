using HowHigh.Models.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Connection bdd
builder.Services.AddDbContext<dbContext>(delegate (DbContextOptionsBuilder options)
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PgSQLConnection"));
});


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
