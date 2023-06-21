using BlogManagementAPI.Repositories.DTO;
using BlogManagementAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLibraryBlog;
using System.Data;

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
        [HttpPost("test")]
  //      [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePost([FromBody] PostEditDTO post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Post newPost = new Post()
            {
                Title = post.Title,
                Content = post.Content,
                DatePosted = DateTime.Now,
                CategoryID = post.CategoryID,
                ImageUrls = post.ImageUrls?.Select(url => new ImageUrl { Url = url }).ToList(),
                UserID = post.UserID,
                YoutubeUrl = post.YoutubeUrl

            };
            var createdPost = await _db.Add(newPost);

            return CreatedAtAction(nameof(GetPostById), new { id = newPost.PostID }, newPost);
        }

        // PUT: api/post/{id}
        [HttpPut("{id:int}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostEditDTO post)
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

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.DatePosted = existingPost.DatePosted;
            existingPost.ImageUrls = post.ImageUrls?.Select(url => new ImageUrl { Url = url }).ToList();
            existingPost.UserID = post.UserID;
            existingPost.YoutubeUrl = post.YoutubeUrl;

            await _db.Update(existingPost);
            return NoContent(); 
        }

        // DELETE: api/post/{id}
        [Authorize(Roles = "Admin")]
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
