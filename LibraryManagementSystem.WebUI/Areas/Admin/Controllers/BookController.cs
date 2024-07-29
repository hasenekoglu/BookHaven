using LibraryManagementSystem.Dto.BookDtos;
using LibraryManagementSystem.Dto.BookDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using LibraryManagementSystem.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Book")]
    public class BookController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kitaplar";
            ViewBag.v3 = "Kitap Listesi";
            ViewBag.v0 = "Kitap İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/Books");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateBook")]
        public async Task<IActionResult> CreateBook()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kitaplar";
            ViewBag.v3 = "Kitap Listesi";
            ViewBag.v0 = "Kitap İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValues = (from x in values
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateBook")]
        public async Task<IActionResult> CreateBook(CreateBookDto createBookDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:5001/api/Books", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Book", new { area = "Admin" });
            }
            return View();
        }
        
        [Route("DeleteBook/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteBook(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:5001/api/Books/{id}");
            //if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Book", new { area = "Admin" });
           // return View();
        }

        [Route("UpdateBook/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBook(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kitaplar";
            ViewBag.v3 = "Kitap Güncelleme Sayfası";
            ViewBag.v0 = "Kitap İşlemleri";

            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:5001/api/Categories");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
            IEnumerable<SelectListItem> categoryValues1 = (from x in values1
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            ViewBag.CategoryValues = categoryValues1;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/Books/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookDto>(jsonData);
                return View(values);
            }
            return View();

        }
        [Route("UpdateBook/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBook(UpdateBookDto updateBookDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:5001/api/Books/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Book", new { area = "Admin" });
            }
            return View();
        }
    }
}
