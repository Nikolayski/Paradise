using Data;
using Models;
using ViewModels.Products;

using X.PagedList;

using System.Linq;
using System.Threading.Tasks;

namespace Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext db;

        public CartService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddCartToUserAsync(string userId)
        {
            var wantedUser = this.db.Users.FirstOrDefault(X => X.Id == userId);
            wantedUser.Cart = new Cart();
            await this.db.SaveChangesAsync();
        }

        public async Task AddProductsToCartAsync(string productId, string userId)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == userId);
            var product = this.db.Products.FirstOrDefault(X => X.Id == productId);
            await this.db.CartProducts.AddAsync(new CartProduct { CartId = user.CartId, ProductId = productId });
            await this.db.SaveChangesAsync();
        }

        public UserCartAddProductViewModel GetCartProducts(string userId)
        {
            var user = this.db.Users.Where(x => x.Id == userId).Select(x => new UserCartAddProductViewModel
            {
                Id = x.Id,
                Products = x.Cart.CartProducts.Select(cp => new ProductToAddViewModel
                {
                    Id = cp.Product.Id,
                    Image = cp.Product.Image,
                    Name = cp.Product.Name,
                    Price = cp.Product.Price
                }).ToList()
            })
             .FirstOrDefault();
            return user;
        }

        public bool IsUserConnectedWithCart(string userId)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == userId);
            if (user.CartId == null)
            {
                return false;
            }
            return true;
        }

        public async Task RemoveProductAsync(string productId, string userId)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == userId);
            var productCart = this.db.CartProducts.FirstOrDefault(X => X.CartId == user.CartId && X.ProductId == productId);
            this.db.CartProducts.Remove(productCart);
            await this.db.SaveChangesAsync();
        }
    }
}
