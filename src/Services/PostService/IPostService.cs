using ViewModels.Posts;

using X.PagedList;

using System.Threading.Tasks;

namespace Services.PostService
{
    public   interface IPostService
    {
        Task<string> AddPostAsync(PostInputViewModel postInputModel, string userId);

        Task<IPagedList<PostAllViewModel>> GetAllPosts(int pageNumber, int pageSize);

        PostsDetailsViewModel GetPostById(string id);

        Task RemovePostById(string id);
    }
}
