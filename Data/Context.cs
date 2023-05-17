using Microsoft.EntityFrameworkCore;
using ModelsLibraryBlog;

namespace BlogManagementAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleID = 1,
                    Name = "User"
                },
                new Role
                {
                    RoleID = 2,
                    Name = "Moderator"
                },
                new Role
                {
                    RoleID = 3,
                    Name = "Admin"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    UserName = "Alvin",
                    Password = "Billyidol96",
                    RoleID = 3,
                    Email = "alvin.strandberg@proton.me",
                    DateRegistered = DateTime.Now
                },
                new User
                {
                    UserID = 2,
                    UserName = "Maja",
                    Password = "TrollHealer96",
                    RoleID = 2,
                    Email = "majanilsson8131@gmail.se",
                    DateRegistered = DateTime.Now
                }
            );


            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    Name = "Programming",
                    Description = "Everything about regarding programming and technology."

                },
                new Category
                {
                    CategoryID = 2,
                    Name = "Hobby",
                    Description = "Non-programming stuff, activites"
                },
                 new Category
                 {
                    CategoryID = 3,
                    Name = "News",
                    Description = "General news regarding the blog, website and programming."

                }
                );
                modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    PostID = 1,
                    Title = "Wood splitting",
                    Content = "Splitting some wood.",
                    UserID = 1,
                    DatePosted = DateTime.Now,
                    CategoryID = 1,

                }
                );
        }

    }
}
