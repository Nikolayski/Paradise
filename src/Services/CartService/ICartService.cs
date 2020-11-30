using ViewModels.Products;
using X.PagedList;

namespace Services.CartService
{
    public  interface ICartService
    {
        void AddCartToUser(string userId);

        bool IsUserConnectedWithCart(string userId);

        void AddProductsToCart(string productId, string userId);

        UserCartAddProductViewModel GetCartProducts(string userId);
        

        void RemoveProduct(string productId, string userId);
    }
}
