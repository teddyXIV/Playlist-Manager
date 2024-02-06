namespace PlaylistManager.Models;
using System.ComponentModel.DataAnnotations;

public class Playlist
{
    public int PlaylistId { get; set; }
    [Required(ErrorMessage = "You must give the playlist a name!")]
    public string Name { get; set; }
    public List<PlaylistSong> JoinEntities { get; }
}