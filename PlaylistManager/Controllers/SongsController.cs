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
    }
}