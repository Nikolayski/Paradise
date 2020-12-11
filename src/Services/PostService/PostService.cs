using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Posts;
using X.PagedList;

namespace Services.PostService
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public PostService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task AddPostAsync(PostInputViewModel postInputModel, string userId)
        {
            var post = this.mapper.Map<Post>(postInputModel);
            post.CreatorId = userId;
            await this.db.Posts.AddAsync(post);
            await this.db.SaveChangesAsync();
        }

        public async  Task<IPagedList<PostAllViewModel>> GetAllPosts(int pageNumber, int pageSize)
        {
            return await this.db.Posts
                        .ProjectTo<PostAllViewModel>(this.mapper.ConfigurationProvider)
                        .ToPagedListAsync(pageNumber,pageSize);
        }

        public PostsDetailsViewModel GetPostById(string id)
        {
            return this.db.Posts.Where(x => x.Id == id)
                       .ProjectTo<PostsDetailsViewModel>(this.mapper.ConfigurationProvider)
                       .FirstOrDefault();
        }

        public async Task RemovePostById(string id)
        {
            var post = this.db.Posts.FirstOrDefault(X => X.Id == id);
            this.db.Posts.Remove(post);
          await  this.db.SaveChangesAsync();
        }
    }
}
