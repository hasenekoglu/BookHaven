using System.Text;
using LibraryManagementSystem.Application.Features.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryManagementSystem.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateUserCommandRequest createRegiserDto)
        {
            if (ModelState.IsValid)
            {
                if (createRegiserDto.Password == createRegiserDto.PasswordConfirm)
                {
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(createRegiserDto);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:5001/api/Users", stringContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Default");//Default yerine login olacak
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Passwords do not match");
                }
            }
            return View();
        }
    }
}