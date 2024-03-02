using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Services;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddAutoMapper(typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly);

string connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(options=>
{
    options.UseSqlServer(connectionString);
});

//Ba�ka bir uygulamada controller'�n devam edece�ini yazd�k.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(
    CleanArchitecture.Presentation.AssemblyReference).Assembly);

builder.Services.AddMediatR(cfr=>
{
    cfr.RegisterServicesFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly);
});

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
