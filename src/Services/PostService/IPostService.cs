using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Posts;
using X.PagedList;

namespace Services.PostService
{
    public   interface IPostService
    {
        Task AddPostAsync(PostInputViewModel postInputModel, string userId);
        Task<IPagedList<PostAllViewModel>> GetAllPosts(int pageNumber, int pageSize);
        PostsDetailsViewModel GetPostById(string id);
        Task RemovePostById(string id);
    }
}
