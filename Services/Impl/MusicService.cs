using MyWebApp.Repositories;
using MyWebApp.Services;
using MyWebApp.Models.MusicModel;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using Newtonsoft.Json;

namespace MyWebApp.Service.Impl;
public class MusicService : IMusicService {
    private readonly IMusicRepo _musicRepo;
    public MusicService(IMusicRepo musicRepo)
    {
        _musicRepo = musicRepo;
    }
    public async Task<BaseResponse> Create(Music musicRequest)
    {
        var result = await _musicRepo.CreateAsync(musicRequest);
        System.Console.WriteLine($"Status {JsonConvert.SerializeObject(result)}");
        return result;
    }
    public Task<IActionResult> Delete()
    {
        throw new NotImplementedException();
    }

    public Task<List<Music>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Update()
    {
        throw new NotImplementedException();
    }

}