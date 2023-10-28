using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lection18Program1.Models;

namespace Lection18Program1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        this.ViewData["Text"] = "Hello World";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult HelloWorld()
    {
        return Content("HelloWorld");
    }

    public IActionResult Exception()
    {
        throw new Exception("Привет! Я ошибка!");
    }


    public IActionResult ErrorProduction()
    {
        return Content("Произошла, ошибка, в случае повтроения свяжитесь с нами по те");
    }
    

}

