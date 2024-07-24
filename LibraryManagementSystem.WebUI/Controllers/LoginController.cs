using System.IdentityModel.Tokens.Jwt;
using System.Text;
using LibraryManagementSystem.Application.Features.Commands.LoginUser;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json.Serialization;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace LibraryManagementSystem.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginUserCommandRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:5001/api/Users/Login", content);

           
            if (responseMessage.IsSuccessStatusCode)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();

                // Log JSON yanıtı
                System.Diagnostics.Debug.WriteLine("JSON Response: " + json);

                // Newtonsoft.Json kullanarak deserialize işlemi
                var response = JsonConvert.DeserializeObject<LoginUserCommandResponse>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    SerializationBinder = new DefaultSerializationBinder()
                });

                // Log yanıt türü
                System.Diagnostics.Debug.WriteLine("Response Type: " + response.GetType().Name);

                if (response is LoginUserSuccessCommandResponse successResponse)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(successResponse.Token.AccessToken);
                    var claims = token.Claims.ToList();

                    // Kullanıcı bilgilerini session'a veya cookie'ye kaydedebilirsiniz
                    // Örneğin: HttpContext.Session.SetString("JWToken", successResponse.Token.AccessToken);

                    return RedirectToAction("Index", "Default"); // Default yerine login olacak
                }
                else if (response is LoginUserErrorCommandResponse errorResponse)
                {
                    // Hata mesajını view'a geçebilirsiniz
                    ModelState.AddModelError(string.Empty, errorResponse.Message);
                }
            }

            // Başarısız olursa tekrar login sayfasını döndürüyoruz.
            return View();
        }
    }
}
