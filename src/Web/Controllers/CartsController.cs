using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using Services.CartService;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AddFromDetails(string productId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await UpdatingDataAsync(productId, userId);
            return this.Redirect($"/Restaurant/Product/{productId}");
       }

        private async Task UpdatingDataAsync(string productId, string userId)
        {
            if (!this.cartService.IsUserConnectedWithCart(userId))
            {
                await this.cartService.AddCartToUserAsync(userId);
            }
            await this.cartService.AddProductsToCartAsync(productId, userId);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string productId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await UpdatingDataAsync(productId, userId);
            return this.Redirect("/Restaurant/Paging");

        }

        public IActionResult MyCart()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = this.cartService.GetCartProducts(userId);
            return this.View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string productId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
          await  this.cartService.RemoveProductAsync(productId, userId);
            return this.Redirect("/Carts/MyCart");
        }
    }
}
