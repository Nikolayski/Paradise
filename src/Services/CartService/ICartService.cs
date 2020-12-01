﻿using System.Threading.Tasks;
using ViewModels.Products;
using X.PagedList;

namespace Services.CartService
{
    public  interface ICartService
    {
        Task AddCartToUserAsync(string userId);

       bool IsUserConnectedWithCart(string userId);

        Task AddProductsToCartAsync(string productId, string userId);

       UserCartAddProductViewModel GetCartProducts(string userId);
        

        Task RemoveProductAsync(string productId, string userId);
    }
}
