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
        // if (playlist.PlaylistId == 0)
        // {
        //     return RedirectToAction("Create");
        // }
        _db.Playlists.Add(playlist);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}