using BlogManagementAPI.Data;
using BlogManagementAPI.Repositories.DTO;
using BlogManagementAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelsLibraryBlog;

namespace BlogManagementAPI.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository<PostGetDTO>
    {
        private readonly Context _db;
        public PostRepository(Context db) : base(db)
        {
            _db = db;
        }
        public async Task<List<PostGetDTO>> GetPosts()
        {
            var postDetails = from post in _db.Posts
                              join u in _db.Users on post.UserID equals u.UserID
                              join c in _db.Categorys on post.CategoryID equals c.CategoryID
                              join r in _db.Roles on u.RoleID equals r.RoleID
                              select new PostGetDTO
                              {
                                  PostID = post.PostID,
                                  Title = post.Title,
                                  Content = post.Content,
                                  UserID = post.UserID,
                                  RoleName = r.Name,
                                  UserName = u.UserName,
                                  ImageUrls = post.ImageUrls.Select(iu => iu.Url).ToList(),
                                  DatePosted = post.DatePosted,
                                  CategoryID = post.CategoryID,
                                  CategoryName = c.Name,
                                  YoutubeUrl = post.YoutubeUrl
                              };
            return postDetails.ToList();
        }
    }
}
