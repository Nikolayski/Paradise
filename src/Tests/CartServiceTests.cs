using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Services.CartService;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class CartServiceTests
    {
        [Fact]
        public async Task AddCartToUserShouldWorkCorrectIfUserExist()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var cartservice = new CartService(db);
            var user = new ApplicationUser
            {
                UserName = "nikolayski@abv.bg",
                Email = "nikolayski@abv.bg",
                PasswordHash = "abcdefg1"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();
            await cartservice.AddCartToUserAsync(user.Id);
            var dbUser = db.Users.FirstOrDefaultAsync(X => X.UserName == user.UserName).GetAwaiter().GetResult();

            //Assert
            Assert.False(string.IsNullOrEmpty(dbUser.CartId));


        }
        [Fact]
        public async Task AddCartToUserShouldNotWorkWithWrongUserId()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var cartservice = new CartService(db);

            //Assert
            await Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await cartservice.AddCartToUserAsync("123");
            });
        }

        [Fact]
        public async Task AddProductsToCartAsyncShouldWorkCorrectWithValidIds()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var cartservice = new CartService(db);
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

            //assert
            Assert.True(db.CartProducts.FirstOrDefaultAsync().Id == 1);
        }

        [Fact]
        public async Task IsUserConnectedWithCartShouldReturnTrueIfDataIsVALID()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var cartservice = new CartService(db);
            var user = new ApplicationUser
            {
                UserName = "nikolayski@abv.bg",
                Email = "nikolayski@abv.bg",
                PasswordHash = "abcdefg1"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();
            await cartservice.AddCartToUserAsync(user.Id);

            //assert
            Assert.True(cartservice.IsUserConnectedWithCart(user.Id));
        }


        [Fact]
        public async Task IsUserConnectedWithCartShouldReturnFalseIfDadaIsINVALID()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var cartservice = new CartService(db);
            var user = new ApplicationUser
            {
                UserName = "nikolayski@abv.bg",
                Email = "nikolayski@abv.bg",
                PasswordHash = "abcdefg1"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();

            //assert
            Assert.False(cartservice.IsUserConnectedWithCart(user.Id));

        }

        [Fact]
        public async Task RemoveProductAsyncShouldWorkCorectWithValidData()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var cartservice = new CartService(db);
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
            await cartservice.RemoveProductAsync(product.Id, user.Id);

            //Assert
             Assert.True(await db.CartProducts.CountAsync() == 0);
            
        }

        [Fact]
        public async Task GetCartProductsShouldReturnUserIfTheIdIsValid()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var cartservice = new CartService(db);
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
            var userModel = cartservice.GetCartProducts(user.Id);

            //assert
            Assert.True(userModel != null);
        }

    }

}

