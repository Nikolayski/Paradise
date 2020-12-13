using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.PostService;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModels.Posts;

namespace Web.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IPostService postService;

        public BlogsController(IPostService postService)
        {
            this.postService = postService;
        }
        public async Task<IActionResult> BlogPage(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 6;
            var posts = await this.postService.GetAllPosts(pageNumber,pageSize);
            return this.View(posts);
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var post = this.postService.GetPostById(id);
            return this.View(post);
        } 
        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async  Task<IActionResult> Add(PostInputViewModel postInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(postInputModel);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var postId =  await this.postService.AddPostAsync(postInputModel, userId);
            return this.Redirect($"/Blogs/Details/{postId}");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove(string id)
        {
          await  this.postService.RemovePostById(id);
            return this.Redirect("/Blogs/BlogPage");
        }
    }
}
