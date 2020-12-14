using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Comments;

namespace Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public CommentService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task AddCommentAsync(string userId, string name, string message)
        {
            var wantedUser = this.db.Users.FirstOrDefault(X => X.Id == userId);

            if (!string.IsNullOrEmpty(name))
            {
                wantedUser.FirstName = name;
            }
            wantedUser.Comments.Add(new Comment { UserId = userId, Message = message, CreatedOn = DateTime.UtcNow, CommentType = CommentType.Recipe });

            await this.db.SaveChangesAsync();
        }

        public async Task AddCommentToPostAsync(string userId, string name, string message, string postId)
        {
            var wantedUser = this.db.Users.FirstOrDefault(X => X.Id == userId);

            if (!string.IsNullOrEmpty(name))
            {
                wantedUser.FirstName = name;
            }
            var comment = new Comment { UserId = userId, Message = message, CreatedOn = DateTime.UtcNow, CommentType = CommentType.Post };
            this.db.Posts.FirstOrDefault(X => X.Id == postId).Comments.Add(comment);
            await this.db.SaveChangesAsync();
        }

        public IEnumerable<CommentAllViewModel> GetAllAsync()
        {
            return this.db.Comments.Where(x => x.CommentType == CommentType.Recipe).ProjectTo<CommentAllViewModel>(this.mapper.ConfigurationProvider).OrderByDescending(x => x.CreatedOn).ToList();
        }

        public async Task RemoveByIdAsync(string id)
        {
            var comment = this.db.Comments.FirstOrDefault(X => X.Id == id);
            this.db.Comments.Remove(comment);
            await this.db.SaveChangesAsync();
        }
    }
}
