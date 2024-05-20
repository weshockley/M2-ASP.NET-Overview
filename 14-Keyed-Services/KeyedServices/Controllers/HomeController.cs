using KeyedServices.Models;
using KeyedServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KeyedServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShoppingCartService _shoppingCartService;

        public HomeController(ILogger<HomeController> logger, IShoppingCartService shoppingCartService)
        {
            _logger = logger;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            _shoppingCartService.AddToCart("Item 1");
            _shoppingCartService.AddToCart("Item 2");
            _shoppingCartService.ClearCart();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
