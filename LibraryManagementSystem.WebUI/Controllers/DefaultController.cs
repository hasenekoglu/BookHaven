using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
