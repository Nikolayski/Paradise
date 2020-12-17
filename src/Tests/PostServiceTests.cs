using AutoMapper;
using Data;
using Mapping;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.PostService;
using System;
using System.Threading.Tasks;
using ViewModels.Posts;
using Xunit;

namespace Tests
{
    public class PostServiceTests
    {
        [Fact]
        public async Task AddPostAsyncShouldWorkCorrectly()
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
            var postService = new PostService(db, mapper);

            var user = new ApplicationUser
            {
                UserName = "koko@abv.bg",
                Email = "koko@abv.bg"
            };
            await db.Users.AddAsync(user);

            var model = new PostInputViewModel
            {
                CreatedOn = DateTime.UtcNow,
                Description = "d1",
                ImageUrl = "URL",
                Title = "some title"
            };
            var id = await postService.AddPostAsync(model, user.Id);

            //assert
            Assert.False(string.IsNullOrEmpty(id));
        }

        [Fact]
        public async Task GetAllPostShouldReturnCollection()
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
            var postService = new PostService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "koko@abv.bg",
                Email = "koko@abv.bg"
            };
            await db.Users.AddAsync(user);
            var model = new PostInputViewModel
            {
                CreatedOn = DateTime.UtcNow,
                Description = "d1",
                ImageUrl = "URL",
                Title = "some title"
            };
            await postService.AddPostAsync(model, user.Id);
            var models = await postService.GetAllPosts(1, 2);

            //assert
            Assert.True(models != null);
        }

        [Fact]
        public async Task GetPostByIdShouldReturnModel()
        {
            // Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var postService = new PostService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "koko@abv.bg",
                Email = "koko@abv.bg"
            };
            await db.Users.AddAsync(user);
            var model = new PostInputViewModel
            {
                CreatedOn = DateTime.UtcNow,
                Description = "d1",
                ImageUrl = "URL",
                Title = "some title"
            };
            var id = await postService.AddPostAsync(model, user.Id);
            var modelOutput = postService.GetPostById(id);

            //assert
            Assert.Equal(modelOutput.Id, id);

        }
        [Fact]
        public async Task RemoveByIdShouldWorkCorrectlyIfIdIsValid()
        {
            // Arange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Act
            var db = new ApplicationDbContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
            });
            var mapper = new Mapper(config);
            var postService = new PostService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "koko@abv.bg",
                Email = "koko@abv.bg"
            };
            await db.Users.AddAsync(user);
            var model = new PostInputViewModel
            {
                CreatedOn = DateTime.UtcNow,
                Description = "d1",
                ImageUrl = "URL",
                Title = "some title"
            };
            var id = await postService.AddPostAsync(model, user.Id);
            await postService.RemovePostById(id);

            var post = await db.Posts.FirstOrDefaultAsync();
            //assert
            Assert.True(post.IsDeleted);
        }
    }
}
