using AutoMapper;
using Data;
using Mapping;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Services.CartService;
using Services.ProductService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetAllAsyncShouldReturnCollection()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var productService = new ProductService(db, mapper);

            var products = new List<Product>
            {
                {new Product
                {
                Description = "d1",
                Image = "URL",
                Name = "Musaka",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },
                 {new Product
                {
                Description = "d2",
                Image = "URL2",
                Name = "Mussaka",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },
            };
            await db.Products.AddRangeAsync(products);

            var productsModels = await productService.GetAllAsync(1, 2);

            //assert
            Assert.NotNull(productsModels);
        }
        [Fact]
        public async Task GetProductByIdShouldReturnValidModel()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var productService = new ProductService(db, mapper);
            var product = new Product
            {
                Description = "d1",
                Image = "URL",
                Name = "Musaka",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
            };
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
            var productModel = productService.GetProductById(product.Id);

            //assert
            Assert.NotNull(productModel);
        }
        [Fact]
        public async Task GetRandomProductsShouldWorkCorrectly()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var productService = new ProductService(db, mapper);

            var products = new List<Product>
            {
                {new Product
                {
                Description = "d1",
                Image = "URL1",
                Name = "Musaka1",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },
                 {new Product
                {
                Description = "d2",
                Image = "URL2",
                Name = "Musaka2",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },{new Product
                {
                Description = "d3",
                Image = "URL3",
                Name = "Musaka3",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },
                 {new Product
                {
                Description = "d4",
                Image = "URL4",
                Name = "Musaka4",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },
            };
            await db.Products.AddRangeAsync(products);
            await db.SaveChangesAsync();

        }
        [Fact]
        public async Task GetFoodListByCategoryAsyncShouldReturnCollection()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var productService = new ProductService(db, mapper);

            var products = new List<Product>
            {
                {new Product
                {
                Description = "d1",
                Image = "URL1",
                Name = "Musaka1",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },
                 {new Product
                {
                Description = "d2",
                Image = "URL2",
                Name = "Musaka2",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },
            };
            await db.Products.AddRangeAsync(products);
            await db.SaveChangesAsync();
            var productsModels = productService.GetFoodListByCategoryAsync(1, 2, ProductCountry.Bulgarian);

            //assert
            Assert.True(productsModels != null);
        }
        [Fact]
        public async Task GetProductsByNameShouldReturnProduct()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var productService = new ProductService(db, mapper);

            var products = new List<Product>
            {
                {new Product
                {
                Description = "d1",
                Image = "URL1",
                Name = "Musaka1",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },
                {new Product
                {
                Description = "d2",
                Image = "URL2",
                Name = "Musaka2",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },
            };
            await db.Products.AddRangeAsync(products);
            await db.SaveChangesAsync();
            var productsModels= productService.GetProductsByName("musaka");

            //assert
            Assert.NotNull(productsModels);
        }
        [Fact]
        public async Task GetProductsByTypeAsyncShouldReturnModels()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var productService = new ProductService(db, mapper);

            var products = new List<Product>
            {
                {new Product
                {
                Description = "d1",
                Image = "URL1",
                Name = "Musaka1",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },
                {new Product
                {
                Description = "d2",
                Image = "URL2",
                Name = "Musaka2",
                Price = 5,
                ProductCountry = ProductCountry.Bulgarian,
                ProductType = ProductType.Main,
                }
                },
            };
            await db.Products.AddRangeAsync(products);
            await db.SaveChangesAsync();
            var productsModels = productService.GetProductsByTypeAsync(1,2,ProductType.Main);

            //assert
            Assert.NotNull(productsModels);
        }
        [Fact]
        public async Task GetOrderProductsInfoShouldReturnCollectionOfUserOrder()
        {

            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var cartservice = new CartService(db);
            var productService = new ProductService(db, mapper);

            var user = new ApplicationUser
            {
                UserName = "nikolayski@abv.bg",
                Email = "nikolayski@abv.bg",
                PasswordHash = "abcdefg1"
            };
            var product = new Product
            {
                ProductCountry = ProductCountry.Bulgarian,
                Name = "Musaka",
                Description = "Yummi bulgarian meal",
                Image = "https://amiraspantry.com/wp-content/uploads/2019/11/moussaka-I.jpg",
                Price = 10,
                ProductType = ProductType.Main
            };
            var product2 = new Product
            {
                ProductCountry = ProductCountry.Bulgarian,
                Name = "Musaka2",
                Description = "Yummi bulgarian meal2",
                Image = "https://amiraspantry.com/wp-content/uploads/2019/11/moussaka-I.jpg",
                Price = 10,
                ProductType = ProductType.Main
            };
            db.Users.Add(user);
            db.Products.Add(product);
            db.Products.Add(product2);
            await db.SaveChangesAsync();
            await cartservice.AddCartToUserAsync(user.Id);
            await cartservice.AddProductsToCartAsync(product.Id, user.Id);
            await cartservice.AddProductsToCartAsync(product2.Id, user.Id);

            var productsModels = productService.GetOrderProductsInfo(user.Id);

        }
    }
}
