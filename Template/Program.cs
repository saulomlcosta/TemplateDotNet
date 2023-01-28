using Microsoft.EntityFrameworkCore;
using Template.Data.Context;
using Template.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("TemplateDB");
builder.Services.AddDbContext<TemplateContext>(opt => opt.UseSqlServer(connectionString).EnableSensitiveDataLogging());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Applying migrations on start project
DatabaseManagementService.MigrateOnInit(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
