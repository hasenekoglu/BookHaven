using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialBookDefaultComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
