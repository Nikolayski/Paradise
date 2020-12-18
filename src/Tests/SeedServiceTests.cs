using Data;
using Microsoft.EntityFrameworkCore;
using Services.SeedService;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public   class SeedServiceTests
    {
        [Fact]
        public async Task AddProductsAsyncShouldAdd39Products()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
           
            var db = new ApplicationDbContext(options);
            var seedProductsService = new SeedProductsService(db);

            //act
            await seedProductsService.AddProductsAsync();

            //assert
            Assert.True(await db.Products.CountAsync() == 39);
            Assert.True(await db.Images.CountAsync() == 17);
               
        }
    }
}
