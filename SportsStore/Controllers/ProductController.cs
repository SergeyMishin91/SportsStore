using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository; 
        }

        public ViewResult List() => View(repository.Products);
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}