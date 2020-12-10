using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.RecipeService;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModels.Recipes;

namespace Web.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }
        public IActionResult Add()
        {
            var model = new AddRecipeInputViewModel();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddRecipeInputViewModel addRecipeViewModel)
        {
            ;
            if (!this.ModelState.IsValid)
            {
                //return this.Redirect("/Recipes/Add");
                return this.View(addRecipeViewModel);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.recipeService.AddRecipeAsync(addRecipeViewModel, userId);

            return this.RedirectToAction("All");
        }
       public async Task<IActionResult> All(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 8;
            var allRecipes = await this.recipeService.GetAllAsync(pageNumber,pageSize);
            ;
            return this.View(allRecipes);
        }

        public IActionResult Details(string id)
        {
            var recipeModel = this.recipeService.GetRecipeById(id);
            return this.View(recipeModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.recipeService.RemoveRecipe(id);
            return this.Redirect("/Recipes/All");
        }

        [Authorize]
        public async Task<IActionResult>  MyRecipes(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 8;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userRecipes = await this.recipeService.GetUserRecipes(pageNumber, pageSize, userId);
            return this.View(userRecipes);
        }
       public async Task<IActionResult> Remove(string id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await  this.recipeService.RemoveRecipeFromUserCollection(id,userId);
            return this.RedirectToAction("MyRecipes");
        }
    }
}
