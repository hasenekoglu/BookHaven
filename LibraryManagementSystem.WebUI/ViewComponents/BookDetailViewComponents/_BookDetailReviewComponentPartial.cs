using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebUI.ViewComponents.BookDetailViewComponents
{
    public class _BookDetailReviewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
