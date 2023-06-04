using BlogManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using ModelsLibraryBlog;

namespace BlogManagementAPI.Repositories
{
    public class UserRepository : Repository<User>
    {
        private Context _db;
        public UserRepository(Context db) : base(db)
        {
            _db = db;
        }

        //public async Task<User> Register(User user)
        //{
        //    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        //    _db.Users.Add(user);
        //    await _db.SaveChangesAsync();
        //    return user;
        //}

        //public async Task<User> Login(string username, string password)
        //{
        //    var user = await _db.Users.SingleOrDefaultAsync(x => x.UserName == username);
        //    if (user == null)
        //        return null;

        //    if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        //        return null;

        //    // Auth success
        //    // Return a new User object without the hash        ed password
        //    return new User
        //    {
        //        UserID = user.UserID,
        //        UserName = user.UserName,
        //        Email = user.Email,
        //        RoleID = user.RoleID,
        //        DateRegistered = user.DateRegistered
        //        // Exclude the Password field
        //    };
        //}
    }
}
