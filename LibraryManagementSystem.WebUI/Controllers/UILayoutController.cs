using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
