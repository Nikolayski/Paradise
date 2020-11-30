using Data;
using Models;
using ViewModels.Products;

using System.Linq;
using X.PagedList;

namespace Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext db;

        public CartService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCartToUser(string userId)
        {
            var wantedUser = this.db.Users.FirstOrDefault(X => X.Id == userId);
            wantedUser.Cart = new Cart();
            this.db.SaveChanges();

        }

        public void AddProductsToCart(string productId, string userId)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == userId);
            var product = this.db.Products.FirstOrDefault(X => X.Id == productId);
            this.db.CartProducts.Add(new CartProduct { CartId = user.CartId, ProductId = productId });
            this.db.SaveChanges();
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

        public void RemoveProduct(string productId, string userId)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == userId);
            var productCart = this.db.CartProducts.FirstOrDefault(X => X.CartId == user.CartId && X.ProductId == productId);
            this.db.CartProducts.Remove(productCart);
            this.db.SaveChanges();
        }
    }
}
