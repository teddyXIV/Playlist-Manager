using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlaylistManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlaylistManager.Controllers
{
    public class SongsController : Controller
    {
        private readonly PlaylistManagerContext _db;
        public SongsController(PlaylistManagerContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            return View(_db.Songs.ToList());
        }
        public ActionResult Details(int id)
        {
            Song thisSong = _db.Songs
                .Include(song => song.JoinEntities)
                .ThenInclude(join => join.Playlist)
                .FirstOrDefault(song => song.SongId == id);
            return View(thisSong);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Song song)
        {
            if (song.Name == null || song.Artist == null)
            {
                return View();
            }
            _db.Songs.Add(song);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Song song = _db.Songs.FirstOrDefault(song => song.SongId == id);
            return View(song);
        }

        [HttpPost]
        public ActionResult Edit(Song song)
        {
            _db.Songs.Update(song);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddPlaylist(int id)
        {
            Song song = _db.Songs.FirstOrDefault(song => song.SongId == id);
            ViewBag.PlaylistId = new SelectList(_db.Playlists, "PlaylistId", "Name");
            return View(song);
        }

        [HttpPost]
        public ActionResult AddPlaylist(Song song, int playlistId)
        {
            PlaylistSong? joinEntity = _db.PlaylistSongs.FirstOrDefault(join => (join.PlaylistId == playlistId && join.SongId == song.SongId));
            if (joinEntity == null && playlistId != 0)
            {
                _db.PlaylistSongs.Add(new PlaylistSong() { PlaylistId = playlistId, SongId = song.SongId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = song.SongId });
        }
        public ActionResult Delete(int id)
        {
            Song thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
            return View(thisSong);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Song thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
            _db.Songs.Remove(thisSong);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}