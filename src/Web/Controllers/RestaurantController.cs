using Data;
using Models.Enums;
using Services.ProductService;
using ViewModels.Products;

using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using System.Security.Claims;
using ViewModels.Users;

namespace Web.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IProductService productsService;
        private readonly ApplicationDbContext db;

        public RestaurantController(IProductService productsService, ApplicationDbContext db)
        {
            this.productsService = productsService;
            this.db = db;
        }

        public IActionResult Paging(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 6;
            var singlePageOfProducts = this.productsService.GetAll(pageNumber, pageSize);
            return this.View(singlePageOfProducts);
        }

       public IActionResult Product(string id)
        {
            var singleProduct = this.productsService.GetProductById(id);
            return this.View(singleProduct);
        }

        public IActionResult Blog()
        {
            return this.View();
        }

        public IActionResult Recipe()
        {
            return this.View();
        }
        public IActionResult Italian(int? page)
        {
            var italiansDishes = GetProductsByCountry(page, ProductCountry.Italian);
            return this.PartialView("_CountryFood", italiansDishes);
        }

        public IActionResult Bulgarian(int? page)
        {
            var bulgariansDishes = GetProductsByCountry(page, ProductCountry.Bulgarian);
            return this.PartialView("_CountryFood", bulgariansDishes);
        }

        public IActionResult Traditional(int? page)
        {
            var traditionalDishes = GetProductsByCountry(page, ProductCountry.Traditional);
            return this.PartialView("_CountryFood", traditionalDishes);
        }

        public IActionResult Indian(int? page)
        {
            var indianDishes = GetProductsByCountry(page, ProductCountry.Indian);
            return this.PartialView("_CountryFood", indianDishes);
        }

        public IActionResult Spanish(int? page)
        {
            var spanishDishes = GetProductsByCountry(page, ProductCountry.Spanish);
            return this.PartialView("_CountryFood", spanishDishes);
        }

        private IPagedList<ProductsAllViewModel> GetProductsByCountry(int? page, ProductCountry type)
        {
            int pageNumber = page ?? 1;
            int pageSize = 6;
            var wantedProducts = this.productsService.GetFoodListByCategory(pageNumber, pageSize, type);
            return wantedProducts;
        }

        private IPagedList<ProductsAllViewModel> GetProductsByCategory(int? page, ProductType type)
        {
            int pageNumber = page ?? 1;
            int pageSize = 6;
            var wantedProducts = this.productsService.GetProductsByType(pageNumber, pageSize, type);
            return wantedProducts;
        }

        public IActionResult Search(string name)
        {
            var wantedModels = this.productsService.GetProductsByName(name);
            return this.View(wantedModels);
        }

        public IActionResult Salads(int? page)
        {

            var allSaladsModel = GetProductsByCategory(page, ProductType.Salad);
            return this.PartialView("_CountryFood", allSaladsModel);
        }

        public IActionResult Mains(int? page)
        {
            var allMainDishesModel = GetProductsByCategory(page, ProductType.Main);
            return this.PartialView("_CountryFood", allMainDishesModel);
        }

        public IActionResult Desserts(int? page)
        {
            var allDessertsModel = GetProductsByCategory(page, ProductType.Dessert);
            return this.PartialView("_CountryFood", allDessertsModel);
        }

        public IActionResult Order()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var orderModel = this.productsService.GetOrderProductsInfo(userId);
            return this.View(orderModel);
        }

        [HttpPost]
        public IActionResult Order(UserOrderInputViewModel orderViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Restaurant/Order");
            }
            return this.Redirect("/");
        }
    }
}

            
