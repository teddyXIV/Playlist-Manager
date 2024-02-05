namespace PlaylistManager.Models;

public class Playlist
{
    public int PlaylistId { get; set; }
    public string Name { get; set; }
    public List<PlaylistSong> JoinEntities { get; }
}