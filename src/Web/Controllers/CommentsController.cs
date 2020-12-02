using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Comments;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Comment(string name, string message)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.commentService.AddCommentAsync(userId, name, message);
            return this.Redirect("/Restaurant/Recipe");
        }
    }
}
