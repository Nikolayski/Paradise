using Data;
using Models;
using Models.Enums;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Products;
using X.PagedList;
using ViewModels.Users;
using System.Threading.Tasks;

namespace Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ProductService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public Task<IPagedList<Product>> GetAllAsync(int pageNumber, int pageSize)
        {
            return  this.db.Products.ToPagedListAsync(pageNumber, pageSize);
        }

        public SingleProductViewModel GetProductById(string productId)
        {
            return this.db.Products.Where(x => x.Id == productId)
                          .ProjectTo<SingleProductViewModel>(this.mapper.ConfigurationProvider)
                          .FirstOrDefault();
        }

        public IEnumerable<RandomProductsViewComponentViewModel> GetRandomProducts()
        {
            var dishes = this.db.Products
                             .ProjectTo<RandomProductsViewComponentViewModel>(this.mapper.ConfigurationProvider)
                             .ToList();

            var rnd = new Random();
            var randomDishes = new List<RandomProductsViewComponentViewModel>();
            while (true)
            {
                var random = rnd.Next(0, dishes.Count);
                if (!randomDishes.Contains(dishes[random]))
                {
                    randomDishes.Add(dishes[random]);
                }
                if (randomDishes.Count == 4)
                {
                    break;
                }
            }

            return randomDishes;
        }

        public Task<IPagedList<ProductsAllViewModel>> GetFoodListByCategoryAsync(int pageNumber, int pageSize,ProductCountry type)
        {
            return this.db.Products.Where(x => x.Nationality == type)
                                  .ProjectTo<ProductsAllViewModel>(this.mapper.ConfigurationProvider)
                                  .ToPagedListAsync(pageNumber, pageSize);
        }

       public IEnumerable<ProductsAllViewModel> GetProductsByName(string name)
        {
            return this.db.Products.Where(x => x.Name.Contains(name))
                                 .ProjectTo<ProductsAllViewModel>(this.mapper.ConfigurationProvider)
                                 .ToList();
        }

        public Task<IPagedList<ProductsAllViewModel>> GetProductsByTypeAsync(int pageNumber, int pageSize, ProductType type)
        {
            return this.db.Products.Where(x => x.Type == type)
                          .ProjectTo<ProductsAllViewModel>(this.mapper.ConfigurationProvider)
                          .ToPagedListAsync(pageNumber, pageSize);
        }

        public UserOrderViewModel GetOrderProductsInfo(string userId)
        {
            return this.db.Users.Where(x => x.Id == userId)
                                .Select(x => new UserOrderViewModel
                                {
                                    Id = x.Id,
                                    UserName = x.UserName,
                                    FirstName = x.FirstName,
                                    LastName = x.LastName,
                                    Address = x.Address,
                                    PhoneNumber = x.PhoneNumber,
                                    Products = x.Cart.CartProducts.Select(cp => new ProductsUserOrderViewModel
                                    {
                                        Id = cp.Product.Id,
                                        Image = cp.Product.Image,
                                        Name = cp.Product.Name,
                                        Price = cp.Product.Price
                                    })
                                        .ToList()
                                })
                                .FirstOrDefault();
        }
    }
}
