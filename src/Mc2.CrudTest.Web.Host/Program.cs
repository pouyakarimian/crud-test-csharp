using Mc2.CrudTest.Infrastructure.Extensions;
using Mc2.CrudTest.Web.Host.Extensions;
using Mc2.CrudTest.Application.Features.Commands.Customer.Create;
using System.Reflection;
using FluentValidation;
using Mc2.CrudTest.Application.Features.Commands.Customer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(CreateCustomerCommand).GetTypeInfo().Assembly);
});

builder.Services
    .ConfigureAppSettings()
    .AddInfrastructure()
    .AddWriteDbContext()
    .AddWriteOnlyRepositories();

builder.Services.AddAutoMapper(typeof(CustomerMapping).Assembly, typeof(Program).Assembly);

builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCustomerCommandValidator));

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
