using Services.Comments;
using Services.RecipeService;
using ViewModels.Recipes;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService recipeService;
        private readonly ICommentService commentService;

        public RecipesController(IRecipeService recipeService, ICommentService commentService)
        {
            this.recipeService = recipeService;
            this.commentService = commentService;
        }

        [Authorize]
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
                return this.View(addRecipeViewModel);
            }
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var recipeId = await this.recipeService.AddRecipeAsync(addRecipeViewModel, userId);
            this.TempData["Success"] = "True";
            return this.Redirect($"/Recipes/Details/{recipeId}");
        }

        public async Task<IActionResult> All(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 8;
            var allRecipes = await this.recipeService.GetAllAsync(pageNumber, pageSize);
            return this.View(allRecipes);
        }

        [Authorize]
        public IActionResult Recipe()
        {
            var comments = this.commentService.GetAllAsync();
            return this.View(comments);
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var recipeModel = this.recipeService.GetRecipeById(id);
            if (recipeModel == null)
            {
                return this.NotFound();
            }
            return this.View(recipeModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.recipeService.RemoveRecipe(id);
            return this.Redirect("/Recipes/All");
        }

        [Authorize]
        public async Task<IActionResult> MyRecipes(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 8;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userRecipes = await this.recipeService.GetUserRecipes(pageNumber, pageSize, userId);
            return this.View(userRecipes);
        }

        [Authorize]
        public async Task<IActionResult> Remove(string id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.recipeService.RemoveRecipeFromUserCollection(id, userId);
            return this.RedirectToAction("MyRecipes");
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            var recipe = this.recipeService.GetRecipeForEdit(id);
            if (recipe == null)
            {
                return this.NotFound();
            }
            return this.View(recipe);
        }

        [Authorize]
        [HttpPost]
        public async  Task<IActionResult> Edit(RecipeEditViewModel recipeEditViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(recipeEditViewModel);
            }
            await this.recipeService.ApplyEditRecipe(recipeEditViewModel);
            return this.Redirect($"/Recipes/Details/{recipeEditViewModel.Id}");
        }
    }
}
