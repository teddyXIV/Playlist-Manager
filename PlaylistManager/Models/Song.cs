namespace PlaylistManager.Models;
using System.ComponentModel.DataAnnotations;
public class Song
{
    public int SongId { get; set; }
    [Required(ErrorMessage = "You must provide the song name!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "You must provide the artist name!")]
    public string Artist { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public List<PlaylistSong> JoinEntities { get; }
}