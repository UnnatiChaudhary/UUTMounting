using Microsoft.EntityFrameworkCore;
using SpikeDemo.EFCore;
using UUTMounting.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UutMountingContext>(
                o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db"))
            );
// Add services to the container.

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
app.UseApplication();
app.UseAuthorization();

app.MapControllers();

app.Run();
