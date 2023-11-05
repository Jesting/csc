﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lection21Program.Models;
using System.Security.Claims;

namespace Lection21Program.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var name = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);

        if (name == null)
        {
            ViewBag.UserName = "Unknown";
        }
        else
        {
            ViewBag.UserName = name.Value;
        }
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
}

