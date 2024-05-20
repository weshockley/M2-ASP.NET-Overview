using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
