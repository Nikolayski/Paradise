using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class ProductsInCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return this.View();
        }
    }
}
