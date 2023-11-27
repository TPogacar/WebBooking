using Microsoft.AspNetCore.Mvc;

namespace WebBooking.Controllers
{
    public class ImagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
