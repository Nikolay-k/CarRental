using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class ClientAppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}