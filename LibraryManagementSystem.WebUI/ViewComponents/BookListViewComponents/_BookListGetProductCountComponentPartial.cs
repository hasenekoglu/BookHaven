using LibraryManagementSystem.Dto.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryManagementSystem.WebUI.ViewComponents.BookListViewComponents
{
    public class _BookListGetProductCountComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _BookListGetProductCountComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/Books");
            if (responseMessage != null)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookDetailsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
 
}
