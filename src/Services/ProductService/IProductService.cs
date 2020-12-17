using Models.Enums;
using ViewModels.Products;
using ViewModels.Users;

using X.PagedList;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ProductService
{
    public interface IProductService
    {
        Task<IPagedList<ProductPagingViewModel>> GetAllAsync(int pageNumber, int pageSize);

        SingleProductViewModel GetProductById(string productId);

        IEnumerable<RandomProductsViewComponentViewModel> GetRandomProducts();

        Task<IPagedList<ProductsAllViewModel>> GetFoodListByCategoryAsync(int pageNumber, int pageSize, ProductCountry category);

        IEnumerable<ProductsAllViewModel> GetProductsByName(string name);

        Task<IPagedList<ProductsAllViewModel>> GetProductsByTypeAsync(int pageNumber, int pageSize, ProductType type);

        UserOrderViewModel GetOrderProductsInfo(string userId);
    }
}
