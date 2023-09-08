using Mc2.CrudTest.Infrastructure.Extensions;
using Mc2.CrudTest.Web.Host.Extensions;
using Mc2.CrudTest.Application.Features.Commands.Customer.Create;
using System.Reflection;
using FluentValidation;

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


//builder.Services.AddMediatR(cfg =>
//{
//    cfg.RegisterServicesFromAssemblyContaining(typeof(Program));
//    //cfg.RegisterServicesFromAssemblyContaining(typeof(CustomerMapping));
//    //cfg.AddOpenBehavior(typeof(ExceptionBehavior<,>));
//    //cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
//    //cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
//    //cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
//});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCustomerCommandValidator));

//builder.Services.AddSingleton<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
builder.Services
    .ConfigureAppSettings()
    .AddInfrastructure()
    .AddWriteDbContext()
    .AddWriteOnlyRepositories();
//.AddReadDbContext()
//.AddReadOnlyRepositories()

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
