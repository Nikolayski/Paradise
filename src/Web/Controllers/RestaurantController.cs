using Data;
using Models.Enums;
using Services.ProductService;

using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using ViewModels.Products;

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
            var italiansDishes = GetCategoryProducts(page, ProductCountry.Italian);
            return this.PartialView("_CountryFood", italiansDishes);
        }

        public IActionResult Bulgarian(int? page)
        {
            var bulgariansDishes = GetCategoryProducts(page, ProductCountry.Bulgarian);
            return this.PartialView("_CountryFood", bulgariansDishes);
        }

        public IActionResult Traditional(int? page)
        {
            var traditionalDishes = GetCategoryProducts(page, ProductCountry.Traditional);
            return this.PartialView("_CountryFood", traditionalDishes);
        }

        public IActionResult Indian(int? page)
        {
            var indianDishes = GetCategoryProducts(page, ProductCountry.Indian);
            return this.PartialView("_CountryFood", indianDishes);
        }

        public IActionResult Spanish(int? page)
        {
            var spanishDishes = GetCategoryProducts(page, ProductCountry.Spanish);
            return this.PartialView("_CountryFood", spanishDishes);
        }

        private IPagedList<ProductsAllViewModel> GetCategoryProducts(int? page, ProductCountry type)
        {
            int pageNumber = page ?? 1;
            int pageSize = 6;
            var wantedProducts = this.productsService.GetFoodListByCategory(pageNumber, pageSize, type);
            return wantedProducts;
        }

        public IActionResult Search(string name)
        {
            var wantedModels = this.productsService.GetProductsByName(name);
            return this.View(wantedModels);
        }


        public IActionResult Salads()
        {
            var allSaladsModel = this.productsService.GetProductsByType(ProductType.Salad);
            return this.PartialView("_CountryFood", allSaladsModel);
        }


        public IActionResult Mains()
        {
            var allMainDishesModel = this.productsService.GetProductsByType(ProductType.Main);
            return this.PartialView("_CountryFood", allMainDishesModel);
        }


        public IActionResult Desserts()
        {
            var allDessertsModel = this.productsService.GetProductsByType(ProductType.Dessert);
            return this.PartialView("_CountryFood", allDessertsModel);
        }
    }
}
