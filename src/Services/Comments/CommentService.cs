using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Models;
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
            wantedUser.Comments.Add(new Comment { UserId = userId, Message = message, CreatedOn = DateTime.UtcNow });
            await this.db.SaveChangesAsync();
        }

        public List<CommentAllViewModel> GetAllAsync()
        {
            return this.db.Comments.ProjectTo<CommentAllViewModel>(this.mapper.ConfigurationProvider).ToList();
        }
    }
}
