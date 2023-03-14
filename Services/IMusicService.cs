using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Models.MusicModel;
namespace MyWebApp.Services;
public interface IMusicService {
    Task<BaseResponse> Create(Music musicRequest);
    Task<IEnumerable<Music>> Get();
    Task<Music> GetById(int id);
    Task<BaseResponse> Update(Music musicRequest);
    Task<BaseResponse> Delete(int id);
}