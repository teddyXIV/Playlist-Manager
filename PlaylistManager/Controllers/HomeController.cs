using Microsoft.AspNetCore.Mvc;
using PlaylistManager.Models;
using System.Linq;

namespace PlaylistManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly PlaylistManagerContext _db;
        public HomeController(PlaylistManagerContext db)
        {
            _db = db;
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            Playlist[] play = _db.Playlists.ToArray();
            Song[] songs = _db.Songs.ToArray();
            Dictionary<string, object[]> model = new Dictionary<string, object[]>();
            model.Add("playlists", play);
            model.Add("songs", songs);
            return View(model);
        }
    }
}