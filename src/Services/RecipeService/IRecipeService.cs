using ViewModels.Recipes;

using X.PagedList;

using System.Threading.Tasks;

namespace Services.RecipeService
{
    public  interface IRecipeService
    {
        Task<string> AddRecipeAsync(AddRecipeInputViewModel addRecipeViewModel, string userId);

        Task<IPagedList<RecipeAllViewModel>> GetAllAsync(int pageNumber, int pageSize);

        RecipeDetailsViewModel GetRecipeById(string id);

        Task<IPagedList<UserRecipesViewModel>> GetUserRecipes(int pageNumber, int pageSize, string userid);

        Task RemoveRecipeFromUserCollection(string id, string userId);

        Task RemoveRecipe(string id);

        RecipeEditViewModel GetRecipeForEdit(string id);
        Task ApplyEditRecipe(RecipeEditViewModel recipeEditViewModel);
    }
}
