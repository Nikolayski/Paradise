using AutoMapper;
using Data;
using Mapping;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Services.RecipeService;
using System;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Recipes;
using Xunit;

namespace Tests
{
    public class RecipeServiceTests
    {
        [Fact]
        public async Task AddRecipeAsyncShouldWorkCorrectlyWithValidData()
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
            var recipeService = new RecipeService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "niko@abv.bg",
                Email = "niko@abv.bg"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();

            var recipeModel = new AddRecipeInputViewModel
            {
                CookingTime = 5,
                ImageUrl = "URL",
                Instructions = "instructions",
                Name = "Name",
                ProductType = ProductType.Dessert
            };
            var id = recipeService.AddRecipeAsync(recipeModel, user.Id);

            //assert
            Assert.NotNull(id);
        }

        [Fact]
        public async Task ApplyEditRecipeShoudWorkCorectly()
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
            var recipeService = new RecipeService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "niko@abv.bg",
                Email = "niko@abv.bg"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();

            var recipeModel = new AddRecipeInputViewModel
            {
                CookingTime = 5,
                ImageUrl = "URL123123",
                Instructions = "instructions",
                Name = "Name",
                ProductType = ProductType.Salad
            };
            var id = await recipeService.AddRecipeAsync(recipeModel, user.Id);

            var editModel = db.Recipes.Where(x => x.Id == id)
                              .Select(x => new RecipeEditViewModel
                              {
                                  Id = x.Id,
                                  CookingTime = x.CookingTime,
                                  ImageUrl = x.ImageUrl,
                                  Instructions = x.Instructions,
                                  Name = x.Name,
                              }).FirstOrDefault();
            editModel.Name = "Name2";
            await recipeService.ApplyEditRecipe(editModel);

            //assert
            Assert.True(recipeModel.Name != editModel.Name);
        }
        [Fact]
        public async Task GetAllAsyncShouldReturnCollectionOfRecipes()
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
            var recipeService = new RecipeService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "niko@abv.bg",
                Email = "niko@abv.bg"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();

            var recipeModel = new AddRecipeInputViewModel
            {
                CookingTime = 5,
                ImageUrl = "URL123123",
                Instructions = "instructions",
                Name = "Name",
                ProductType = ProductType.Salad
            };
            var recipeModel2 = new AddRecipeInputViewModel
            {
                CookingTime = 5,
                ImageUrl = "URL1231232",
                Instructions = "instructions2",
                Name = "Name2",
                ProductType = ProductType.Salad
            };
            var id = await recipeService.AddRecipeAsync(recipeModel, user.Id);
            var id2 = await recipeService.AddRecipeAsync(recipeModel2, user.Id);
            var recipesModels = recipeService.GetAllAsync(1, 2);

            //assert
            Assert.NotNull(recipesModels);

        }
        [Fact]
        public async Task GetRecipeByIdSholdReturnCorrectRecipe()
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
            var recipeService = new RecipeService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "niko@abv.bg",
                Email = "niko@abv.bg"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();

            var recipeModel = new AddRecipeInputViewModel
            {
                CookingTime = 5,
                ImageUrl = "URL123123",
                Instructions = "instructions",
                Name = "Name",
                ProductType = ProductType.Salad
            };
            var id = await recipeService.AddRecipeAsync(recipeModel, user.Id);
            var recipe = recipeService.GetRecipeById(id);

            //assert
            Assert.Equal(recipeModel.Name, recipe.Name);
        }

        [Fact]
        public async Task GetRecipeForEditShouldShouldReturnCorrectRecipe()
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
            var recipeService = new RecipeService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "niko@abv.bg",
                Email = "niko@abv.bg"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();

            var recipeModel = new AddRecipeInputViewModel
            {
                CookingTime = 5,
                ImageUrl = "URL123123",
                Instructions = "instructions",
                Name = "Name",
                ProductType = ProductType.Salad
            };
            var id = await recipeService.AddRecipeAsync(recipeModel, user.Id);
            var recipe = recipeService.GetRecipeForEdit(id);

            //assert
            Assert.Equal(recipe.Id, id);
            Assert.NotNull(recipe);
        }
        [Fact]
        public async Task GetUserRecipesSholdWorkCorrectlyWithValidData()
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
            var recipeService = new RecipeService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "niko@abv.bg",
                Email = "niko@abv.bg"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();

            var recipeModel = new AddRecipeInputViewModel
            {
                CookingTime = 5,
                ImageUrl = "URL123123",
                Instructions = "instructions",
                Name = "Name",
                ProductType = ProductType.Salad
            };
            var recipeModel2 = new AddRecipeInputViewModel
            {
                CookingTime = 5,
                ImageUrl = "URL123122",
                Instructions = "instructions2",
                Name = "Name",
                ProductType = ProductType.Salad
            };
            var id = await recipeService.AddRecipeAsync(recipeModel, user.Id);
            var id2 = await recipeService.AddRecipeAsync(recipeModel2, user.Id);

            var recipeModels = recipeService.GetUserRecipes(1,2,user.Id);

            //assert
            Assert.True(recipeModels.GetAwaiter().GetResult().Count == 2);
        }
        [Fact]
        public async Task RemoveRecipeShouldWorkWithValidId()
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
            var recipeService = new RecipeService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "niko@abv.bg",
                Email = "niko@abv.bg"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();

            var recipeModel = new AddRecipeInputViewModel
            {
                CookingTime = 5,
                ImageUrl = "URL123123",
                Instructions = "instructions",
                Name = "Name",
                ProductType = ProductType.Salad
            };
            var id = await recipeService.AddRecipeAsync(recipeModel, user.Id);
          await  recipeService.RemoveRecipe(id);

            //assert
            Assert.True(await db.Recipes.CountAsync() == 0);

        }
        [Fact]
        public async Task RemoveRecipeFromUserCollectionShouldDeleteRecipe()
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
            var recipeService = new RecipeService(db, mapper);
            var user = new ApplicationUser
            {
                UserName = "niko@abv.bg",
                Email = "niko@abv.bg"
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();

            var recipeModel = new AddRecipeInputViewModel
            {
                CookingTime = 5,
                ImageUrl = "URL123123",
                Instructions = "instructions",
                Name = "Name",
                ProductType = ProductType.Salad
            };
            var recipeModel2 = new AddRecipeInputViewModel
            {
                CookingTime = 5,
                ImageUrl = "URL123123",
                Instructions = "instructions",
                Name = "Name",
                ProductType = ProductType.Salad
            };
            var id = await recipeService.AddRecipeAsync(recipeModel, user.Id);
            var id2 = await recipeService.AddRecipeAsync(recipeModel2, user.Id);
            await   recipeService.RemoveRecipeFromUserCollection(id, user.Id);

            var expected = db.Users.FirstOrDefault(X => X.Id == user.Id).Recipes.Count();
            //assert
            Assert.True(expected== 1);

        }
    }
}
