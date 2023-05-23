using BlogManagementAPI.Repositories.DTO;
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
        private readonly IPostRepository<PostGetDTO> _postRepository;

        public PostController(IRepository<Post> db, IPostRepository<PostGetDTO> postRepository)
        {
            _db = db;
            _postRepository = postRepository;
        }
        // GET: api/post
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postRepository.GetPosts();
            return Ok(posts);
        }

        // GET: api/post/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _db.Get(id);
            return post == null ? NotFound() : Ok(post);
        }

        // POST: api/post
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPost = await _db.Add(post);
            return CreatedAtAction(nameof(GetPostById), new { id = createdPost.PostID }, createdPost);
        }

        // PUT: api/post/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPost = await _db.Get(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            post.PostID = existingPost.PostID;
            await _db.Update(post);
            return NoContent(); 
        }

        // DELETE: api/post/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var postToDelete = await _db.Get(id);
            if (postToDelete == null)
            {
                return NotFound();
            }

            await _db.Delete(id);
            return NoContent();
        }
    }
}
