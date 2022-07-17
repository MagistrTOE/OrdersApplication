using System.Reflection;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using MyOrders.Domain;
using MyOrders.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

builder.Services.AddControllers();

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI();

app.UseRouting();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
