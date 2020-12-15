using Data;
using Models;
using ViewModels.Recipes;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using X.PagedList;

using System.Linq;
using System.Threading.Tasks;

namespace Services.RecipeService
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public RecipeService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<string> AddRecipeAsync(AddRecipeInputViewModel addRecipeViewModel, string userId)
        {
            var recipe = this.mapper.Map<Recipe>(addRecipeViewModel);
            recipe.CreatorId = userId;
            await this.db.Recipes.AddAsync(recipe);
            await this.db.SaveChangesAsync();
            return recipe.Id;
        }

        public async Task ApplyEditRecipe(RecipeEditViewModel recipeEditViewModel)
        {
            var recipe = this.db.Recipes.FirstOrDefault(X => X.Id == recipeEditViewModel.Id);
            recipe.Name = recipeEditViewModel.Name;
            recipe.ImageUrl = recipeEditViewModel.ImageUrl;
            recipe.CookingTime = recipeEditViewModel.CookingTime;
            recipe.Instructions = recipeEditViewModel.Instructions;
            await this.db.SaveChangesAsync();
        }

        public async Task<IPagedList<RecipeAllViewModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await this.db.Recipes
                                 .ProjectTo<RecipeAllViewModel>(this.mapper.ConfigurationProvider)
                                 .ToPagedListAsync(pageNumber, pageSize);
        }

        public RecipeDetailsViewModel GetRecipeById(string id)
        {
            return this.db.Recipes.Where(x => x.Id == id)
                                        .ProjectTo<RecipeDetailsViewModel>(this.mapper.ConfigurationProvider)
                                        .FirstOrDefault();
        }

        public RecipeEditViewModel GetRecipeForEdit(string id)
        {
            var recipe = this.db.Recipes.FirstOrDefault(X => X.Id == id);
            var recipeEditModel = this.mapper.Map<RecipeEditViewModel>(recipe);
            return recipeEditModel;
        }

        public async Task<IPagedList<UserRecipesViewModel>> GetUserRecipes(int pageNumber, int pageSize, string userid)
        {
            return await this.db.Recipes.Where(x => x.CreatorId == userid)
                                  .ProjectTo<UserRecipesViewModel>(this.mapper.ConfigurationProvider)
                                  .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task RemoveRecipe(string id)
        {
            var wantedRecipe = this.db.Recipes.FirstOrDefault(X => X.Id == id);
            this.db.Recipes.Remove(wantedRecipe);
            await this.db.SaveChangesAsync();
        }

        public async Task RemoveRecipeFromUserCollection(string id, string userId)
        {

            var user = this.db.Users.FirstOrDefault(X => X.Id == userId);
            var recipe = this.db.Recipes.FirstOrDefault(X => X.Id == id);
            user.Recipes.Remove(recipe);
            await this.db.SaveChangesAsync();
        }
    }
}
