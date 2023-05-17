using BlogManagementAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelsLibraryBlog;

namespace BlogManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IRepository<Post> _db;

        public PostController(IRepository<Post> db)
        {
            _db = db;
        }
        [HttpGet("GetPostById/{id:int}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _db.Get(id);
            return post == null ? NotFound() : Ok(post);
        }

    }
}
