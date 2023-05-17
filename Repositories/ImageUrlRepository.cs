using BlogManagementAPI.Data;
using ModelsLibraryBlog;

namespace BlogManagementAPI.Repositories
{
    public class ImageUrlRepository : Repository<ImageUrl>
    {
        private Context _db;
        public ImageUrlRepository(Context db) : base(db)
        {
            _db = db;
        }
    }
}
