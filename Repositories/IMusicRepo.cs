using MyWebApp.Models;
using MyWebApp.Models.MusicModel;

namespace MyWebApp.Repositories;
public interface IMusicRepo {
    Task<BaseResponse> CreateAsync(Music musicRequest);
    Task<List<Music>> GetAsync();
    Task UpdateAsync();
    Task<BaseResponse> DeleteAsync(int id);

}