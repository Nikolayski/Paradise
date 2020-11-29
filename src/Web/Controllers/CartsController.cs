using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using Services.CartService;

namespace Web.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;

        public CartsController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost]
        public IActionResult AddFromDetails(string productId)
        {


            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            UpdatingData(productId, userId);
            return this.Redirect($"/Restaurant/Product/{productId}");

        }

        private void UpdatingData(string productId, string userId)
        {
            if (!this.cartService.IsUserConnectedWithCart(userId))
            {
                this.cartService.AddCartToUser(userId);
            }
            this.cartService.AddProductsToCart(productId, userId);
        }

        [HttpPost]
        public IActionResult Add(string productId)
        {


            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            UpdatingData(productId, userId);
            return this.Redirect("/Restaurant/Paging");

        }

        public IActionResult MyCart()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = this.cartService.GetCartProducts(userId);

            return this.View(user);
        }

        [HttpPost]
        public IActionResult Remove(string productId)
        {
            ;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            this.cartService.RemoveProduct(productId, userId);
            return this.Redirect("/Cart/MyCart");
        }
    }
}
