using Microsoft.AspNetCore.Authentication.Google;

namespace Lection21Program;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();


        builder.Services.AddAuthentication(o =>
        {
            o.DefaultScheme = "Application";
            o.DefaultSignInScheme = "External";
        })
            .AddCookie("Application")
            .AddCookie("External")
        .AddGoogle(googleOptions =>
        {
                googleOptions.ClientId = "348804087638-2emnlk87kh7c2dsbuge65vq96nionuqi.apps.googleusercontent.com";
                googleOptions.ClientSecret = "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";
            });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

