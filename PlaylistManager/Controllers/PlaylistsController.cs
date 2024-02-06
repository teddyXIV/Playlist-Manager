using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlaylistManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlaylistManager.Controllers;

public class PlaylistsController : Controller
{
    private readonly PlaylistManagerContext _db;
    public PlaylistsController(PlaylistManagerContext db)
    {
        _db = db;
    }
    public ActionResult Index()
    {
        List<Playlist> model = _db.Playlists.ToList();
        ViewBag.PageTitle = "View all playlists";
        return View(model);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Playlist playlist)
    {
        if (playlist.Name == null)
        {
            return View();
        }
        _db.Playlists.Add(playlist);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Playlist playlist = _db.Playlists
            .Include(playlist => playlist.JoinEntities)
            .ThenInclude(join => join.Song)
            .FirstOrDefault(playlist => playlist.PlaylistId == id);

        return View(playlist);
    }

    public ActionResult Edit(int id)
    {
        Playlist playlist = _db.Playlists.FirstOrDefault(playlist => playlist.PlaylistId == id);
        return View(playlist);
    }

    [HttpPost]
    public ActionResult Edit(Playlist playlist)
    {
        _db.Playlists.Update(playlist);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult AddSong(int id)
    {
        Playlist playlist = _db.Playlists.FirstOrDefault(playlist => playlist.PlaylistId == id);
        ViewBag.SongId = new SelectList(_db.Songs, "SongId", "Name");
        return View(playlist);
    }

    [HttpPost]
    public ActionResult AddSong(Playlist playlist, int songId)
    {
        PlaylistSong? joinEntity = _db.PlaylistSongs.FirstOrDefault(join => (join.SongId == songId && join.PlaylistId == playlist.PlaylistId));
        if (joinEntity == null && songId != 0)
        {
            _db.PlaylistSongs.Add(new PlaylistSong() { SongId = songId, PlaylistId = playlist.PlaylistId });
            _db.SaveChanges();
        }
        return RedirectToAction("Details", new { id = playlist.PlaylistId });
    }
}
