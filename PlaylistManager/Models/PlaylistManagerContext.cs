using Microsoft.EntityFrameworkCore;

namespace PlaylistManager.Models
{
    public class PlaylistManagerContext : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }

        public PlaylistManagerContext(DbContextOptions options) : base(options) { }
    }
}