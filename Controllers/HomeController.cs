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

    public async Task<IActionResult> Index()
    {
        var allMusic = await _musicService.Get();
        return View(allMusic.OrderBy(music => music.Id));
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
        if(ModelState.IsValid){
            var result = await _musicService.Create(musicRequest);
            if(result.StatusCode == 200){
                return RedirectToAction("Index");
            }
        }
        return View();
    }

    public async Task<IActionResult> Edit(int id){
        System.Console.WriteLine($"Music Id {id}");
        var music = await _musicService.GetById(id);
        if(music != null){
            return View(music);
        }
        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Music musicRequest)
    {
        System.Console.WriteLine($"Request Parameter {JsonConvert.SerializeObject(musicRequest)}");
        if(ModelState.IsValid){
            System.Console.WriteLine($"Validate Model");
            var result = await _musicService.Update(musicRequest);
            if(result.StatusCode == 200){
                return RedirectToAction("Index");
            }
        }
        return View(musicRequest);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var result = await _musicService.Delete(id);
        if(result == null){
            return NotFound();
        }
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

