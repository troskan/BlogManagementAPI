using BlogManagementAPI.Data;
using ModelsLibraryBlog;

namespace BlogManagementAPI.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private Context _db;
        public PostRepository(Context db) : base(db)
        {
            _db = db;
        }
    }
}
