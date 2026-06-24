using ExpenseTracker.Models;
using ExpenseTracker.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ExpenseService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapGet("/", () => Results.Ok(new
{
    message = "ExpenseTracker API is running.",
    swagger = "/swagger"
}));
app.MapControllers();

app.Run();
