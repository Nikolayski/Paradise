using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Moq;
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
            var provider = new Mock<IServiceProvider>();
            provider.Setup(x=>x.GetRequiredService())
           
            var db = new ApplicationDbContext(options);
            
               
        }
    }
}
