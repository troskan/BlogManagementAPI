using BlogManagementAPI.Repositories;
using BlogManagementAPI.Repositories.DTO;
using Microsoft.AspNetCore.Mvc;
using ModelsLibraryBlog;
using Newtonsoft.Json;

namespace BlogManagementAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO userDto)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Convert DTO to User entity
            var user = new User
            {
                UserName = userDto.UserName,
                Password = userDto.Password, // you would hash this before saving
                Email = userDto.Email,
                RoleID = userDto.RoleID,
                DateRegistered = userDto.DateRegistered
            };

            // Register the user
            User registeredUser = await _userRepository.Register(user);
            if (registeredUser == null)
            {
                return BadRequest("Unable to register user.");
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO userDto)
        {
            // Find and authenticate the user
            User user = await _userRepository.Login(userDto.UserName, userDto.Password);
            if (user == null)
            {
                return BadRequest("Invalid username or password.");
            }

            // User is authenticated successfully
            // Serialize the User object to a JSON string
            string json = JsonConvert.SerializeObject(user);

            return new ContentResult
            {
                Content = json,
                ContentType = "application/json",
                StatusCode = 200
            };
        }


    }
}
