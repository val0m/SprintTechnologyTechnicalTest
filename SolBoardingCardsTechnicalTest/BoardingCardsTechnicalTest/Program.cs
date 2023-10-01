using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => {
            Assembly assembly = typeof(Program).Assembly;
            RegisterClassWithSuffix(containerBuilder, assembly, "Service");
            containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.IsClosedTypeOf(typeof(IValidator<>))).AsImplementedInterfaces();
        });

        builder.Services.AddMediatR(cfg =>
             cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

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
    }

    private static void RegisterClassWithSuffix(ContainerBuilder builder, Assembly infrastructureAssembly, string suffix)
    {
        builder.RegisterAssemblyTypes(infrastructureAssembly)
        .Where(t => t.Name.EndsWith(suffix))
        .AsImplementedInterfaces();
    }
}