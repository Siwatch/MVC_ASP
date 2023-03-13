using MyWebApp.Data;
using MyWebApp.Models;
using MyWebApp.Models.MusicModel;
using MyWebApp.Repositories;

namespace NyWebApp.Repositories.Impl;
public class MusicRepo : IMusicRepo
{
    private readonly ApplicationDbContext _dbContext;
    public MusicRepo(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<BaseResponse> CreateAsync(Music musicRequest)
    {
        try{
            await _dbContext.MusicTable.AddAsync(musicRequest);
            await _dbContext.SaveChangesAsync();
            return new BaseResponse() {StatusCode = 200};
        }
        catch(Exception ex){
            return new BaseResponse() {StatusCode = 500};
        }
    }

    public async Task<BaseResponse> DeleteAsync(int id)
    {
        var music = await _dbContext.MusicTable.FindAsync(id);
        if(music != null){
            _dbContext.MusicTable.Remove(music);
            return new BaseResponse() {StatusCode = 200};
        }
        return new BaseResponse() {StatusCode = 400};
    }

    public async Task<List<Music>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync()
    {
        throw new NotImplementedException();
    }
}