using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeadComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
