using System.ComponentModel.DataAnnotations;
namespace MyWebApp.Models.MusicModel;
public class Music {
    [Key]
    public int Id {get;set;}
    [Required]
    public string MusicName {get;set;}
    [Required]
    public string MusicGenre {get;set;}
    [Required]
    public double MusicDuration {get;set;}
}