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

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Song song)
        {
            _db.Songs.Add(song);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}