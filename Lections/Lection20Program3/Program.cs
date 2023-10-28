using Autofac;
using Autofac.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Lection20Program3;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var config = new ConfigurationBuilder();
        config.AddJsonFile("appsettings.json");
        var cfg = config.Build();

        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        builder.Host.ConfigureContainer<ContainerBuilder>(contaierBuilder =>
        {
            contaierBuilder.RegisterType<ClientBookRepo>().As<IClientBookRepo>();
            contaierBuilder.Register(c => new AppDbContext(cfg.GetConnectionString("db"))).InstancePerDependency();
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            //app.UseSwaggerUI();

            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

