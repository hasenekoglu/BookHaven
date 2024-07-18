using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
