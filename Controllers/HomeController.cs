using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Models.MusicModel;
using MyWebApp.Services;
using Newtonsoft.Json;

namespace MyWebApp.Controllers;

public class HomeController : Controller
{
    private readonly IMusicService _musicService;

    public HomeController(IMusicService musicService)
    {
        _musicService = musicService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Music musicRequest)
    {
        System.Console.WriteLine($"Request Parameter {JsonConvert.SerializeObject(musicRequest)}");
        var result = await _musicService.Create(musicRequest);
        if(result.StatusCode == 200){
            return RedirectToAction("Index");
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

