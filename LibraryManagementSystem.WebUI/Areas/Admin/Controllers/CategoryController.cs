using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
