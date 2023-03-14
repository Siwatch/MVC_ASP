using System.ComponentModel.DataAnnotations;
namespace MyWebApp.Models.MusicModel;
public class Music {
    [Key]
    public int Id {get;set;}

    [Required(ErrorMessage="Insert MusicName")]
    public string MusicName {get;set;}

    [Required(ErrorMessage="Insert MusicGenre")]
    public string MusicGenre {get;set;}
    
    [Required(ErrorMessage="Please insert an integer 0-5")]
    [Range(1,5)]
    public int MusicDuration {get;set;}
}