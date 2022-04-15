using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TR.Domain;
using TR.Web.Models;

namespace TR.Web.Controllers
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
            Product product = new Product();
            product.Name = "Samsung";
            product.Description = "Smartphone dernière génération";
            return View(product);
        }

        public IActionResult Index2()
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product() { Name = "Apple", Description = "iPhone", Price = 4000 });
            products.Add(new Product() { Name = "Samsung", Description = "Smartphone", Price = 3900 });
            products.Add(new Product() { Name = "Huawei", Description = "Made in China", Price = 8000 });



            return View(products);
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