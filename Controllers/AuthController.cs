using BlogManagementAPI.Data;
using BlogManagementAPI.Repositories.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ModelsLibraryBlog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BlogManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private Context _db;
        private readonly IConfiguration _configuration;

        public AuthController(Context context, IConfiguration configuration)
        {
            _db = context;
            _configuration = configuration;
        }


        [HttpPost("register")]


        public async Task<ActionResult<User>> Register(UserRegisterDTO request)
        {
            if (request == null)
            {
                return BadRequest("Request is null");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var roleUser = await _db.Roles.FirstOrDefaultAsync(r => r.Name == "User");


            if (roleUser == null)
            {
                return BadRequest("Role not found.");
            }
            var user = new User
            {
                UserName = request.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = request.Email,
                DateRegistered = DateTime.Now,
                Role = roleUser,
                RoleID = roleUser.RoleID

            };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            return Ok(user);

        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO request)
        {
            var user = await _db.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user => user.UserName == request.UserName);

            if(user == null)
            {
                return BadRequest("User not found.");
            }

            if (user.UserName != request.UserName)
            {
                return NotFound("Username was not found");
            }
            if(!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            var token = CreateToken(user);
            return Ok(token);
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration
                .GetSection("AppSettings:Token")
                .Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[]passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
