using Microsoft.AspNetCore.Mvc;

namespace PlaylistManager.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

    }
}