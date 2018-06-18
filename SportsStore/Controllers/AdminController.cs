using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    //Контроллер для управления каталогом товаров
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult Index() => View(repository.Products);

        //Ищем товар с идентиф-м, соответств-м знач-ю параметра prodId
        //и передаем его как объект модели представления View()
        public ViewResult Edit(int productId) =>
            View(repository.Products
                .FirstOrDefault(p => p.ProductID == productId));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                //Использется TempData, т.к. ViewBag не удерживает данные 
                // дольше, чем длится НТТР-запрос
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}