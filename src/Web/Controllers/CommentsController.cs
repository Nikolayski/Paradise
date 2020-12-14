﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Services.Comments;
using Services.PostService;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IPostService postService;

        public CommentsController(ICommentService commentService, IPostService postService)
        {
            this.commentService = commentService;
            this.postService = postService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Comment(string name, string message)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;


                await this.commentService.AddCommentAsync(userId, name, message);
                return this.Redirect("/Recipes/Recipe");
          }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CommentBlog(string name, string message, string id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.commentService.AddCommentToPostAsync(userId, name, message,id);
            return this.Redirect($"/Blogs/Details/{id}");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove(string id)
        {
            await  this.commentService.RemoveByIdAsync(id);
            var value = this.Request.Headers["referer"];
            if (value[0].Contains("recipe") || value[0].Contains("Recipe"))
            {
                return this.Redirect("/Recipes/Recipe");
            }
            else
            {
                return this.Redirect("/Blogs/BlogPage");
            }
            
        }

        
    }
}

