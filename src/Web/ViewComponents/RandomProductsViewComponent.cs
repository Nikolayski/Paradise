using Microsoft.AspNetCore.Mvc;
using Services.ProductService;

namespace Web.ViewComponents
{
    public class RandomProductsViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public RandomProductsViewComponent(IProductService productService)
        {
            this.productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var randomDishes = this.productService.GetRandomProducts();
            return this.View(randomDishes);
        }
    }
}
