using DemoMercadoPago.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MercadoPago.Config;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;

namespace DemoMercadoPago.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }




        public async Task<IActionResult> Pago()
        {
            MercadoPagoConfig.AccessToken = "TEST-3462044254849055-082315-bfc04228bd5e2d225b29d800c26fd4d4__LC_LD__-116392764";
        
            List<PreferenceItemRequest> ListItems = new();

            PreferenceItemRequest Item1 = new();
            Item1.Id = "PROD00001";
            Item1.Title = "TV 32";
            Item1.Quantity = 1;
            Item1.CurrencyId = "ARS";
            Item1.UnitPrice = 120m;
            Item1.PictureUrl = "http://medias.musimundo.com/medias/00313067-141464-141464-01-141464-01.jpg-size515?context=bWFzdGVyfGltYWdlc3w4NDg0NXxpbWFnZS9qcGVnfGgzYy9oYmIvMTAzMjExNzU5Njk4MjIvMDAzMTMwNjctMTQxNDY0LTE0MTQ2NF8wMS0xNDE0NjRfMDEuanBnX3NpemU1MTV8NTAyYTFlMTcxMjhkNmVmYWQwYzg1ODJmZjA3Y2RiYjA5ZGU0OGY4MTVjNDY4NzVjZTY5ZjMwOGFlZDM1ZDhkZg";
           
            /* item 2, item3 */
            
            ListItems.Add(Item1);



            // Crea el objeto de request de la preference
            var request = new PreferenceRequest
            {
                Items = ListItems,
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Failure = "http://localhost:7071/home/fallo",
                    Pending = "http://localhost:7071/home/pendiente",
                    Success = "http://localhost:7071/home/exito"
                },
                NotificationUrl = "https://enioh9yum2wgpf9.m.pipedream.net",
                Payer = new PreferencePayerRequest()
                {
                    Email = "test@hotmail.com",
                }
            };

            // Crea la preferencia usando el client
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);

            ViewData["ID"] = preference.Id;
            // or
            ViewData["url"] = preference.InitPoint;
            return View();

        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}