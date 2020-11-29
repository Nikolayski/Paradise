using Models;
using Models.Enums;

using System.Collections.Generic;
using ViewModels.Products;
using X.PagedList;

namespace Services.ProductService
{
    public interface IProductService
    {
        IPagedList<Product> GetAll(int pageNumber, int pageSize);

        SingleProductViewModel GetProductById(string productId);

        IEnumerable<RandomProductsViewComponentViewModel> GetRandomProducts();

        IPagedList<ProductsAllViewModel> GetFoodListByCategory(int pageNumber, int pageSize, ProductCountry category);

        IEnumerable<ProductsAllViewModel> GetProductsByName(string name);

        IEnumerable<ProductsAllViewModel> GetProductsByType(ProductType type);
    }
}
