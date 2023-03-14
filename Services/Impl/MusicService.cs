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
    public async Task<BaseResponse> Delete(int id)
    {
        var result = await _musicRepo.DeleteAsync(id);
        return result;
    }

    public async Task<IEnumerable<Music>> Get()
    {
        var result = await _musicRepo.GetAsync();
        return result;
    }

    public async Task<BaseResponse> Update(Music musicRequest)
    {
        try{
            var result = await _musicRepo.UpdateAsync(musicRequest);
            return result;
        }catch(Exception ex){
            throw ex;
        }
    }
    public async Task<Music> GetById(int id)
    {
        try{
            var result = await _musicRepo.GetByIdAsync(id);
            return result;
        }catch(Exception ex){
            throw ex;
        }
    }
}