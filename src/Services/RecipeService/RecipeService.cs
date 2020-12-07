using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Models;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Recipes;
using X.PagedList;

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
        public async Task AddRecipeAsync(AddRecipeInputViewModel addRecipeViewModel, string userId)
        {
            var recipe = this.mapper.Map<Recipe>(addRecipeViewModel);
            recipe.CreatorId = userId;
            await this.db.Recipes.AddAsync(recipe);
            await this.db.SaveChangesAsync();
        }

        public Task<IPagedList<RecipeAllViewModel>> GetAllAsync(int pageNumber, int pageSize)
        {
           return this.db.Recipes
                                .ProjectTo<RecipeAllViewModel>(this.mapper.ConfigurationProvider)
                                .ToPagedListAsync(pageNumber, pageSize);
        }

        public RecipeDetailsViewModel GetRecipeById(string id)
        {
            return this.db.Recipes.Where(x => x.Id == id)
                                        .ProjectTo<RecipeDetailsViewModel>(this.mapper.ConfigurationProvider)
                                        .FirstOrDefault();
        }

        public Task<IPagedList<UserRecipesViewModel>> GetUserRecipes(int pageNumber, int pageSize, string userid)
        {
            return this.db.Recipes.Where(x => x.CreatorId == userid)
                                  .ProjectTo<UserRecipesViewModel>(this.mapper.ConfigurationProvider)
                                  .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task RemoveRecipe(string id, string userId)
        {
            //  var recipe = this.db.Recipes.FirstOrDefault(X => X.Id == id);
            //  this.db.Recipes.Remove(recipe);
            //await  this.db.SaveChangesAsync();

             var user = this.db.Users.FirstOrDefault(X => X.Id == userId);
            var recipe = this.db.Recipes.FirstOrDefault(X => X.Id == id);
            user.Recipes.Remove(recipe);
          await  this.db.SaveChangesAsync();
        }
    }
}
