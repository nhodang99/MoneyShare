using Microsoft.EntityFrameworkCore;
using MoneyShare.API.Services;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseLazyLoadingProxies()
            .UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"),
                b => b.MigrationsAssembly("MoneyShare.Infrastructure"));
    }
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<BillsService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
