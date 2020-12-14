﻿using Models.Enums;
using Services.ProductService;
using Services.UserService;
using ViewModels.Products;
using ViewModels.Users;

using Microsoft.AspNetCore.Mvc;
using X.PagedList;

using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IProductService productsService;
        private readonly IUsersService usersService;
      
        public RestaurantController(IProductService productsService,
                                    IUsersService usersService)
        {
            this.productsService = productsService;
            this.usersService = usersService;
        }

        public async Task<IActionResult> Paging(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 6;
            var singlePageOfProducts = await this.productsService.GetAllAsync(pageNumber, pageSize);
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

        public async Task<IActionResult> Italian(int? page)
        {
            var italiansDishes =await GetProductsByCountryAsync(page, ProductCountry.Italian);
            return this.PartialView("_CountryFood", italiansDishes);
        }

        public async Task<IActionResult> Bulgarian(int? page)
        {
            var bulgariansDishes =await GetProductsByCountryAsync(page, ProductCountry.Bulgarian);
            return this.PartialView("_CountryFood", bulgariansDishes);
        }

        public async Task<IActionResult> Traditional(int? page)
        {
            var traditionalDishes = await GetProductsByCountryAsync(page, ProductCountry.Traditional);
            return this.PartialView("_CountryFood", traditionalDishes);
        }

        public async Task<IActionResult> Indian(int? page)
        {
            var indianDishes =  await GetProductsByCountryAsync(page, ProductCountry.Indian);
            return this.PartialView("_CountryFood", indianDishes);
        }

        public async Task<IActionResult> Spanish(int? page)
        {
            var spanishDishes = await GetProductsByCountryAsync(page, ProductCountry.Spanish);
            return this.PartialView("_CountryFood", spanishDishes);
        }

        private async Task<IPagedList<ProductsAllViewModel>> GetProductsByCountryAsync(int? page, ProductCountry type)
        {
            int pageNumber = page ?? 1;
            int pageSize = 6;
            var wantedProducts = await this.productsService.GetFoodListByCategoryAsync(pageNumber, pageSize, type);
            return wantedProducts;
        }

        private Task<IPagedList<ProductsAllViewModel>> GetProductsByCategoryAsync(int? page, ProductType type)
        {
            int pageNumber = page ?? 1;
            int pageSize = 6;
            var wantedProducts = this.productsService.GetProductsByTypeAsync(pageNumber, pageSize, type);
            return wantedProducts;
        }

        public IActionResult Search(string name)
        {
            var wantedModels = this.productsService.GetProductsByName(name);
            return this.View(wantedModels);
        }

        public async Task<IActionResult> Salads(int? page)
        {
            var allSaladsModel = await GetProductsByCategoryAsync(page, ProductType.Salad);
            return this.PartialView("_CountryFood", allSaladsModel);
        }

        public async Task<IActionResult> Mains(int? page)
        {
            var allMainDishesModel = await GetProductsByCategoryAsync(page, ProductType.Main);
            return this.PartialView("_CountryFood", allMainDishesModel);
        }

        public async Task<IActionResult> Desserts(int? page)
        {
            var allDessertsModel = await GetProductsByCategoryAsync(page, ProductType.Dessert);
            return this.PartialView("_CountryFood", allDessertsModel);
        }

        public IActionResult Order()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var orderModel = this.productsService.GetOrderProductsInfo(userId);
            return this.View(orderModel);
        }

        [HttpPost]
        public async Task<IActionResult> Order(UserOrderInputViewModel orderViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Restaurant/Order");
            }
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
          await  this.usersService.DeleteCartCollectionAsync(userId);
            return this.Redirect("/Carts/MyCart");
        }
    }
}

            
