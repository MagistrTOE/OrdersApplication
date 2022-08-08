using System.Reflection;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using MyOrders.Domain;
using MyOrders.Infrastructure;
using MyOrders.Web.Api.ExtensionsForProgram;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
const string CorsName = nameof(MyOrders);


// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy(name:CorsName, policy =>
 {
     policy.AllowAnyOrigin()
     .AllowAnyHeader()
     .AllowAnyMethod();
 }));

builder.Services.AddDbContext<MyOrdersContext>(opt => opt
    .UseNpgsql(builder.Configuration.GetConnectionString("MyOrdersContext")));
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

var assemblies = DependencyContext.Default.RuntimeLibraries
    .SelectMany(assembly => assembly.GetDefaultAssemblyNames(DependencyContext.Default)
    .Where(assemblyName => assemblyName.FullName.StartsWith(nameof(MyOrders)))
    .Select(Assembly.Load))
    .ToArray();

builder.Services.AddMediatR(assemblies);
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblies(assemblies));

var mapper = new Mapper(new MapperConfiguration(ctx => ctx.AddMaps(assemblies)));
builder.Services.AddSingleton<IMapper>(mapper);

builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options =>
{
    options.UseCentralRoutePrefix("orders");
});

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseDeveloperExceptionPage();


app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI();

app.UseStaticFiles();

app.UseRouting();

app.UseCors(CorsName);

app.UseAuthorization();

app.MapControllers();

app.Run();
