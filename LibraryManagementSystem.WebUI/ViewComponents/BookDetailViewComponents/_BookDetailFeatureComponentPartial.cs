using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebUI.ViewComponents.BookDetailViewComponents
{
    public class _BookDetailFeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
