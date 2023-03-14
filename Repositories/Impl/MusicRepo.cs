using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;
using MyWebApp.Models.MusicModel;
using MyWebApp.Repositories;
using Newtonsoft.Json;

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
            System.Console.WriteLine($"{JsonConvert.SerializeObject(ex.Message)}");
            throw new Exception(ex.Message);
        }
    }

    public async Task<BaseResponse> DeleteAsync(int id)
    {
        try{
            var result = await _dbContext.MusicTable.FindAsync(id);
            if(result == null){
                return new BaseResponse() {StatusCode = 404};
            }
            _dbContext.MusicTable.Remove(result);
            await _dbContext.SaveChangesAsync();
            return new BaseResponse() {StatusCode = 200};
        }catch(Exception ex){
            System.Console.WriteLine($"{JsonConvert.SerializeObject(ex.Message)}");
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Music>> GetAsync()
    {
        try{
            var music = await _dbContext.MusicTable.ToListAsync();
            return music;
        }
        catch(Exception ex){
            System.Console.WriteLine($"{JsonConvert.SerializeObject(ex.Message)}");
            throw new Exception(ex.Message);
        }

    }

    public async Task<Music> GetByIdAsync(int id)
    {
        try{
            var musicById = await _dbContext.MusicTable.FindAsync(id);
            if(musicById == null){
                return null;
            }
            return musicById;
        }
        catch(Exception ex){
            System.Console.WriteLine($"{JsonConvert.SerializeObject(ex.Message)}");
            throw new Exception(ex.Message);
        }
    }
    public async Task<BaseResponse> UpdateAsync(Music musicRequest)
    {
        try{
            _dbContext.MusicTable.Update(musicRequest);
            await _dbContext.SaveChangesAsync();
            return new BaseResponse() {StatusCode = 200};
        }
        catch(Exception ex){
            System.Console.WriteLine($"{JsonConvert.SerializeObject(ex.Message)}");
            throw new Exception(ex.Message);
        }
    }
}