using BlogManagementAPI.Repositories.DTO;
using ModelsLibraryBlog;

namespace BlogManagementAPI.Repositories.Interfaces
{
    public interface IPostRepository<T>
    {
        Task<List<PostGetDTO>> GetPosts();
        //Task<T> GetPost(int id);
    }
}
