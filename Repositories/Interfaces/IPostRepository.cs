using ModelsLibraryBlog;

namespace BlogManagementAPI.Repositories.Interfaces
{
    public interface IPostRepository<T>
    {
        Task<IEnumerable<T>> GetPosts();
        Task<T> GetPost(int id);
    }
}
