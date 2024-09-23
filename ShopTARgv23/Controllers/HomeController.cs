using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Data;
using ShopTARgv23.Models;
using System.Diagnostics;

namespace ShopTARgv23.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopTARgv23Context _context;

        public HomeController
            (
            ILogger<HomeController> logger,
            ShopTARgv23Context context
            )
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
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
