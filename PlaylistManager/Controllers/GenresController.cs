using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlaylistManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlaylistManager.Controllers;

public class GenresController : Controller
{
    private readonly PlaylistManagerContext _db;
    public GenresController(PlaylistManagerContext db)
    {
        _db = db;
    }
    public ActionResult Index()
    {
        List<Genre> model = _db.Genres.ToList();
        ViewBag.PageTitle = "View all genres";
        return View(model);
    }

    public ActionResult Create()
    {
        ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
        return View();
    }

    [HttpPost]
    public ActionResult Create(Genre genre)
    {
        if (genre.Name == null)
        {
            return View();
        }
        _db.Genres.Add(genre);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Genre genre = _db.Genres
            .Include(genre => genre.Songs)
            .ThenInclude(song => song.JoinEntities)
            .ThenInclude(join => join.Playlist)
            .FirstOrDefault(genre => genre.GenreId == id);

        return View(genre);
    }

    public ActionResult Edit(int id)
    {
        Genre genre = _db.Genres.FirstOrDefault(genre => genre.GenreId == id);
        return View(genre);
    }

    [HttpPost]
    public ActionResult Edit(Genre genre)
    {
        _db.Genres.Update(genre);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Genre genre = _db.Genres.FirstOrDefault(g => g.GenreId == id);
        return View(genre);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Genre genre = _db.Genres.FirstOrDefault(g => g.GenreId == id);
        _db.Genres.Remove(genre);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    // public ActionResult AddSong(int id)
    // {
    //     Playlist playlist = _db.Playlists.FirstOrDefault(playlist => playlist.PlaylistId == id);
    //     ViewBag.SongId = new SelectList(_db.Songs, "SongId", "Name");
    //     return View(playlist);
    // }

    // [HttpPost]
    // public ActionResult AddSong(Playlist playlist, int songId)
    // {
    //     PlaylistSong? joinEntity = _db.PlaylistSongs.FirstOrDefault(join => (join.SongId == songId && join.PlaylistId == playlist.PlaylistId));
    //     if (joinEntity == null && songId != 0)
    //     {
    //         _db.PlaylistSongs.Add(new PlaylistSong() { SongId = songId, PlaylistId = playlist.PlaylistId });
    //         _db.SaveChanges();
    //     }
    //     return RedirectToAction("Details", new { id = playlist.PlaylistId });
    // }

    // [HttpPost]
    // public ActionResult DeleteJoin(int joinId)
    // {
    //     PlaylistSong joinEntry = _db.PlaylistSongs.FirstOrDefault(entry => entry.PlaylistSongId == joinId);
    //     _db.PlaylistSongs.Remove(joinEntry);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }
}