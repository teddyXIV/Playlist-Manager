namespace PlaylistManager.Models;
using System.ComponentModel.DataAnnotations;

public class Genre
{
    public int GenreId { get; set; }
    [Required(ErrorMessage = "You must give the genre a name!")]
    public string Name { get; set; }
    public List<Song> Songs { get; set; }
}