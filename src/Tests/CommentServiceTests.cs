using AutoMapper;
using Data;
using Mapping;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Comments;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class CommentServiceTests
    {
        [Fact]
        public async Task AddCommentAsyncShouldWorkCorrectIfParametersAreValid()
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
            var commentService = new CommentService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "nikolayski@abv.bg",
                Email = "nikolayski@abv.bg",
                PasswordHash = "abcdefg1"
            };
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            await commentService.AddCommentAsync(user.Id, "Niko", "Hello!");

            //assert
            Assert.True(await db.Comments.CountAsync() == 1);

        }

        [Fact]
        public async Task AddCommentToPostAsyncShouldWorkCorrectWithValidData()
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
            var commentService = new CommentService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "nikolayski@abv.bg",
                Email = "nikolayski@abv.bg",
                PasswordHash = "abcdefg1"
            };
            var post = new Post
            {
                ImageUrl = "https://media.istockphoto.com/vectors/set-of-round-minus-and-plus-sign-icons-buttons-flat-negative-and-on-vector-id1189799128?b=1&k=6&m=1189799128&s=612x612&w=0&h=Dh3OKJ30k2hJj8948AU4MpNHfDL6Au3YrtcKD_UpMK8=",
                Title = "Some Post",
                Description = "Some Description",
                CreatedOn = DateTime.UtcNow
            };
            await db.Users.AddAsync(user);
            await db.Posts.AddAsync(post);
            await db.SaveChangesAsync();
            await commentService.AddCommentAsync(user.Id, "Niko", "Hello!");
            var postModel = await db.Posts.FirstOrDefaultAsync();
            await commentService.AddCommentToPostAsync(user.Id, "Niksan", "Hi", post.Id);

            //assert
            Assert.True(await db.Comments.CountAsync() == 2);
        }

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
            var commentService = new CommentService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "nikolayski@abv.bg",
                Email = "nikolayski@abv.bg",
                PasswordHash = "abcdefg1"
            };
            var post = new Post
            {
                ImageUrl = "https://media.istockphoto.com/vectors/set-of-round-minus-and-plus-sign-icons-buttons-flat-negative-and-on-vector-id1189799128?b=1&k=6&m=1189799128&s=612x612&w=0&h=Dh3OKJ30k2hJj8948AU4MpNHfDL6Au3YrtcKD_UpMK8=",
                Title = "Some Post",
                Description = "Some Description",
                CreatedOn = DateTime.UtcNow
            };
            await db.Users.AddAsync(user);
            await db.Posts.AddAsync(post);
            await db.SaveChangesAsync();
            await commentService.AddCommentAsync(user.Id, "Niko", "Hello!");
            var postModel = await db.Posts.FirstOrDefaultAsync();
            await commentService.AddCommentToPostAsync(user.Id, "Niksan", "Hi", post.Id);
            var models = commentService.GetAllAsync();

            //assert
            Assert.True(models != null);
        }

        [Fact]
        public async Task RemoveByIdAsyncShoulWorkCorrectlyWithValidParameters()
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
            var commentService = new CommentService(db, mapper);
            var comment = new Comment();
            await db.Comments.AddAsync(comment);
            await db.SaveChangesAsync();
            await commentService.RemoveByIdAsync(comment.Id);

            //asssert
            Assert.True(await db.Comments.CountAsync() == 0);
        }
    }
}
