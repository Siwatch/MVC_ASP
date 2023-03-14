using Microsoft.EntityFrameworkCore;
using MyWebApp.Models.MusicModel;

namespace MyWebApp.Data;
public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    public DbSet<Music> MusicTable {get;set;}
}