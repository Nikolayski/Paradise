using AutoMapper;
using Data;
using Mapping;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Services.CartService;
using Services.UserService;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public    class UserServiceTests
    {
        [Fact]
        public async Task GetUserShouldReturnValidUser()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var usersService = new UsersService(db, mapper);

            //Act
            var user = new ApplicationUser
            {
                UserName = "niko@abv.bg",
                Email = "niko@abv.bg"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();
            var modelUser = usersService.GetUser(user.Id);

            //assert
            Assert.Equal(modelUser.Id, user.Id);

        }
        [Fact]
        public async Task DeleteCartCollectionAsyncShouldDeleteProductsInWantedCart()
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
            var usersService = new UsersService(db, mapper);
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
            db.Users.Add(user);
            db.Products.Add(product);
            await db.SaveChangesAsync();
            await cartservice.AddCartToUserAsync(user.Id);
            await cartservice.AddProductsToCartAsync(product.Id, user.Id);
         await   usersService.DeleteCartCollectionAsync(user.Id);

            //assert
            Assert.True(await db.CartProducts.CountAsync() == 0);

        }
    }
}
