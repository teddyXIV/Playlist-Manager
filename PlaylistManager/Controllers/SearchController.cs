using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlaylistManager.Models;

namespace PlaylistManager.Controllers;

public class SearchController : Controller
{
    private readonly PlaylistManagerContext _db;
    public SearchController(PlaylistManagerContext db)
    {
        _db = db;
    }

    public async Task<ActionResult> Index(string searchType, string searchTerm)
    {
        switch (searchType)
        {
            case "songs":
                List<Song> songResults = await _db.Songs
                    .Where(song => song.Name.Contains(searchTerm))
                    .ToListAsync();
                return View(songResults);
            default:
                List<Playlist> playlistResults = await _db.Playlists
                    .Where(p => p.Name.Contains(searchTerm))
                    .ToListAsync();
                return View(playlistResults);
        }
    }
}