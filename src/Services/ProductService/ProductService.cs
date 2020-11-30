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

        public IPagedList<Product> GetAll(int pageNumber, int pageSize)
        {
            return this.db.Products.ToPagedList(pageNumber, pageSize);
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

        public IPagedList<ProductsAllViewModel> GetFoodListByCategory(int pageNumber, int pageSize,ProductCountry type)
        {
            return this.db.Products.Where(x => x.Nationality == type)
                                  .ProjectTo<ProductsAllViewModel>(this.mapper.ConfigurationProvider)
                                  .ToPagedList(pageNumber, pageSize);
        }

       public IEnumerable<ProductsAllViewModel> GetProductsByName(string name)
        {
            return this.db.Products.Where(x => x.Name.Contains(name))
                                 .ProjectTo<ProductsAllViewModel>(this.mapper.ConfigurationProvider)
                                 .ToList();
        }

        public IPagedList<ProductsAllViewModel> GetProductsByType(int pageNumber, int pageSize, ProductType type)
        {
            return this.db.Products.Where(x => x.Type == type)
                          .ProjectTo<ProductsAllViewModel>(this.mapper.ConfigurationProvider)
                          .ToPagedList(pageNumber, pageSize);
        }
    }
}
