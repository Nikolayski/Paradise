using Services.ProductService;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace Web.ViewComponents
{
    public class IndexMealsViewComponent : ViewComponent
    {
        private readonly IProductService productsService;

        public IndexMealsViewComponent(IProductService productsService)
        {
            this.productsService = productsService;
        }

        public IViewComponentResult Invoke()
        {
            var products = this.productsService.GetRandomProducts()
                                               .Take(3)
                                               .ToList();
            return this.View(products);
        }
    }
}
