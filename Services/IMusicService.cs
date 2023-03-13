using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Models.MusicModel;
namespace MyWebApp.Services;
public interface IMusicService {
    Task<BaseResponse> Create(Music musicRequest);
    Task<List<Music>> Get();
    Task<IActionResult> Update();
    Task<IActionResult> Delete();
}