using LibraryManagementSystem.Dto.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryManagementSystem.WebUI.Controllers
{
    
    public class BookListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
       //[Route("Index/{id}")]
      
        public async Task<IActionResult> BookDetail()
        {
            //ViewBag.bookid = id;
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:5001/api/Books/?id="+id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<ResultBookDetailsDto>(jsonData);
            //    return View(values);
            //}
            return View();
        }
    }
}
