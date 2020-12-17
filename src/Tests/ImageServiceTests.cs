using AutoMapper;
using Data;
using Mapping;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Services.ImageService;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class ImageServiceTests
    {
        [Fact]
        public async Task GetIndexImagesShouldReturnCollection()
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
            var imageService = new ImageService(db, mapper);

            var image = new Image
            {
                Description = "d1",
                Type = ImageType.Index,
                Url = "URL"
            };
            var image2 = new Image
            {
                Description = "d2",
                Type = ImageType.Index,
                Url = "URL2"
            };
            await db.Images.AddAsync(image);
            await db.Images.AddAsync(image2);
            var models = imageService.GetIndexImages();

            //assert
            Assert.False(models == null);
        }
    }
}
