using MoneyShare.Infrastructure;
using MoneyShare.Application;
using MoneyShare.API;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
