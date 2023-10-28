
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Lection20Program1.Repo;

namespace Lection20Program2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var config = new ConfigurationBuilder();
        config.AddJsonFile("appsettings.json");
        var cfg = config.Build();

        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        builder.Host.ConfigureContainer<ContainerBuilder>(contaierBuilder =>
        {
            contaierBuilder.RegisterType<LibraryRepo>().As<ILibraryRepo>();
            contaierBuilder.Register(c => new AppDbContext(cfg.GetConnectionString("db"))).InstancePerDependency();
        });



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
}

