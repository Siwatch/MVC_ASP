using MyWebApp.Models;
using MyWebApp.Models.MusicModel;

namespace MyWebApp.Repositories;
public interface IMusicRepo {
    Task<BaseResponse> CreateAsync(Music musicRequest);
    Task<IEnumerable<Music>> GetAsync();
    Task<Music> GetByIdAsync(int id);
    Task<BaseResponse> UpdateAsync(Music musicRequest);
    Task<BaseResponse> DeleteAsync(int id);

}