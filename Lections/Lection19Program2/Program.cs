
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Lection19Program2.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace Lection19Program2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        // Add services to the container.
        
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMemoryCache(options =>
        {
            options.TrackStatistics = true;
        });

        builder.Services.AddStackExchangeRedisCache(options =>
        {
            string server = "127.0.0.1";
            string port = "6379";
            string cnstring = $"{server}:{port}";
            options.Configuration = cnstring;
        });


        

        var config = new ConfigurationBuilder();
        config.AddJsonFile("appsettings.json");
        var cfg = config.Build();
        

        builder.Host.ConfigureContainer<ContainerBuilder>(contaierBuilder =>
        {
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

        var staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles");
        Directory.CreateDirectory(staticFilesPath);


        app.UseStaticFiles(new StaticFileOptions
        {
           
            FileProvider = new PhysicalFileProvider(
                staticFilesPath),
            RequestPath = "/static" 
        });

       

        app.MapControllers();

        app.Run();
    }
}

